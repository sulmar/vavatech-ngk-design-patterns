using BuilderPattern.Models;

namespace BuilderPattern
{
    public interface IPersonBuilder
    {
        IPersonBuilder Called(string name);
        IPersonBuilder WorksAs(string position);
        IPersonBuilder HasSkill(string skill);

        Person Build();
    }




}