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

}
