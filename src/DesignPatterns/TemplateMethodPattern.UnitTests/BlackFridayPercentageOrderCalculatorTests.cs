using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TemplateMethodPattern.UnitTests
{
    [TestClass]
    public class BlackFridayPercentageOrderCalculatorTests
    {
        private BlackFridayPercentageOrderCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            calculator = new BlackFridayPercentageOrderCalculator(DateTime.Parse("2022-03-16"), 0.1m);
        }

        [TestMethod]
        public void CalculateDiscount_OnBlackFriday_ShouldReturnsDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.Parse("2022-03-16 10:02"), new Customer(), 100);

            // Act
            var discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(10, discount);
        }

        [TestMethod]
        public void CalculateDiscount_NotBlackFriday_ShouldReturnsNotDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.Parse("2022-03-17 10:02"), new Customer(), 100);

            // Act
            var discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(0, discount);
        }
    }
}
