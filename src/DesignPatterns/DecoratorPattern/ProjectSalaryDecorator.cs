namespace DecoratorPattern
{
    public class ProjectSalaryDecorator : SalaryDecorator
    {
        private readonly decimal bonusPerProject;

        public ProjectSalaryDecorator(decimal bonus, Employee employee) : base(employee)
        {
            this.bonusPerProject = bonus;
        }

        public override decimal GetSalary()
        {
            return base.GetSalary() + bonusPerProject * employee.NumberOfProjects;
        }
    }
}
