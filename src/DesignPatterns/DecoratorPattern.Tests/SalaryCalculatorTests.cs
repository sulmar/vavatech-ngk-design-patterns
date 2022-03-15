using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DecoratorPattern.UnitTests
{

    [TestClass]
    public class NameAttributeTests
    {
        [TestMethod]
        public void Female_NameAttribute_ShouldBeReturnsDescription()
        {
            // Arrange
            Female female = new Female();

            // Act
            NameAttribute nameAttribute = (NameAttribute) Attribute.GetCustomAttribute(typeof(Female), typeof(NameAttribute));

            // Assert
            Assert.AreEqual("Kobieta", nameAttribute.Description);

        }

        [TestMethod]
        public void Gender_NameAttribute_ShouldBeReturnsDescription()
        {
            // Arrange
            Gender gender = new Gender();

            // Act
            var attributes = typeof(Gender).GetCustomAttributes(false);

            // Assert
            // Assert.AreEqual("Kobieta", nameAttribute.Description);

        }

    }

    [TestClass]
    public class SalaryCalculatorTests
    { 
    
        [TestMethod]
        public void CalculateSalary_Junior_ShouldCalculateBonus()
        {
            // Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator(50, 1000);

            Employee employee = new JuniorDeveloper { OvertimeSalary = TimeSpan.FromHours(2), NumberOfProjects = 1};

            // Act
            decimal salary = salaryCalculator.CalculateSalary(employee);

            // Assert
            Assert.AreEqual(2100, salary);
        }

        [TestMethod]
        public void CalculateSalary_Senior_ShouldCalculateBonus()
        {
            // Arrange
            SalaryCalculator salaryCalculator = new SalaryCalculator(50, 1000);

            Employee employee = new SeniorDeveloper { OvertimeSalary = TimeSpan.FromHours(2), NumberOfProjects = 2 };

            // Act
            decimal salary = salaryCalculator.CalculateSalary(employee);

            // Assert
            Assert.AreEqual(4100, salary);
        }
    }
}
