using BuilderPattern.Models;

namespace BuilderPattern
{
    public class EagerPersonBuilder : IPersonBuilder
    {
        private Person person;

        public EagerPersonBuilder()
        {
            person = new Person();
        }

        public IPersonBuilder Called(string name)
        {
            person.Name = name;

            return this;
        }

        public IPersonBuilder WorksAs(string position)
        {
            person.Position = position;

            return this;
        }

        public IPersonBuilder HasSkill(string skill)
        {
            person.AddSkill(skill);

            return this;
        }

        public Person Build()
        {
            return person;
        }
    }




}