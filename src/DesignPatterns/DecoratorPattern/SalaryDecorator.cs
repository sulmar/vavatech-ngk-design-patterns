using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    // Abstract Decorator
    public abstract class SalaryDecorator : Employee // Abstract Component
    {
        public Employee employee;

        public SalaryDecorator(Employee employee)
        {
            this.employee = employee;
        }

        public override decimal GetSalary()
        {
            if (employee != null)
            {
                return employee.GetSalary();
            }
            else
                return decimal.Zero;
        }

    }
}
