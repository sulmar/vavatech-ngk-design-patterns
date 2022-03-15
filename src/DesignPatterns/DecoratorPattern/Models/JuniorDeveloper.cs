namespace DecoratorPattern
{
    // Concrete Component
    public class JuniorDeveloper : Employee
    {
        public override decimal GetSalary()
        {
            return 1000;
        }
    }

}
