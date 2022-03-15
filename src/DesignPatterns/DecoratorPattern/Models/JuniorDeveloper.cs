namespace DecoratorPattern
{
    // Concrete Component
    
    // Młodszy programista
    public class JuniorDeveloper : Employee
    {
        public override decimal GetSalary()
        {
            return 1000;
        }
    }

}
