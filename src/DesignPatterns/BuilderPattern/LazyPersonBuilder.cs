using BuilderPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuilderPattern
{

    // Leniwy budowniczy - wersja generyczna
    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        public TSelf Do(Action<TSubject> action) => AddAction(action);

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(p => { action(p); return p; });

            return (TSelf)this;
        }

        public TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));

    }

    public class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
        public PersonBuilder WorksAs(string position) => Do(p => p.Position = position);
        public PersonBuilder HasSkill(string skill) => Do(p => p.AddSkill(skill));
    }

    public class SalesReportBuilder2 : FunctionalBuilder<SalesReport, SalesReportBuilder2>
    {
        public SalesReportBuilder2 AddHeader(string title) => Do(r => r.Title = title);
        public SalesReportBuilder2 AddOrders(IEnumerable<Order> orders) => Do(r => r.Orders = orders);

    }




    public class LazyPersonBuilder : IPersonBuilder
    {
        private List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        public IPersonBuilder Do(Action<Person> action)
        {
            return AddAction(action);
        }

        private IPersonBuilder AddAction(Action<Person> action)
        {
            actions.Add(p => { action(p); return p; });

            return this;
        }

        public IPersonBuilder Called(string name) => Do(p => p.Name = name);
        public IPersonBuilder WorksAs(string position) => Do(p => p.Position = position);
        public IPersonBuilder HasSkill(string skill) => Do(p => p.AddSkill(skill));

        public Person Build() => actions.Aggregate(new Person(), (p, action) => action(p));

        //public Person Build()
        //{
        //    Person p = new Person(); // akumulator
        //    foreach (var action in actions)
        //    {
        //        action.Invoke(p);
        //    }

        //    return p;
        //}
    }




}