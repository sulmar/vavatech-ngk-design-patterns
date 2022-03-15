using System;
using System.ComponentModel;

namespace DecoratorPattern
{
    // Concrete Component
    public class SeniorDeveloper : Employee
    {
        public override decimal GetSalary()
        {
            return 2000;
        }
    }

    [Name("Kobieta", 10)]
    public class Female
    {

    }

    public enum Gender
    {
        [Name("Kobieta", 10)]
        Male,

        [Name("Mężczyzna", 20)]
        Female
    }

    [AttributeUsage(AttributeTargets.All)]
    public class NameAttribute : Attribute
    {
        [Name("Opis", 0)]
        public string Description { get; set; }

        public NameAttribute(string description, int quantity)
        {
            Description = description;
        }
    }

    public class Checklist
    {        
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }

        [ReadOnly(true)]
        public bool Flag3 { get; set; }
        [ReadOnly(true)]
        public bool Flag4 { get; set; }
    }

}
