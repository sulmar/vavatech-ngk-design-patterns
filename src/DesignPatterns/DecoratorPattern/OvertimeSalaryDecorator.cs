namespace DecoratorPattern
{
    // Concrete Decorator
    public class OvertimeSalaryDecorator : SalaryDecorator
    {
        private readonly decimal amountPerHour;

        public OvertimeSalaryDecorator(decimal amountPerHour, Employee employee) : base(employee)
        {
            this.amountPerHour = amountPerHour;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + (decimal) employee.OvertimeSalary.TotalHours * amountPerHour;
        }
    }
}
