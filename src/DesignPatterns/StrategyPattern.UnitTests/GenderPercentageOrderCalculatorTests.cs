using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StrategyPattern.UnitTests
{
    [TestClass]
    public class BlackFridayFixedOrderCalculatorTests
    {
        private OrderCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            ICanDiscountStrategy canDiscountStrategy = new BlackFridayCanDiscountStrategy(DateTime.Parse("2022-03-16"));
            IDiscountStrategy discountStrategy = new FixedDiscountStrategy(10m);

            calculator = new OrderCalculator(canDiscountStrategy, discountStrategy);
        }

        [TestMethod]
        public void CalculateDiscount_BlackFriday_ShouldDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.Parse("2022-03-16"), new Customer { Gender = Gender.Female }, 100);

            // Act
            decimal discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(10, discount);

        }

        [TestMethod]
        public void CalculateDiscount_NotBlackFriday_ShouldNotDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.Parse("2022-03-17"), new Customer { Gender = Gender.Female }, 100);

            // Act
            decimal discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(0, discount);

        }
    }


    [TestClass]
    public class GenderPercentageOrderCalculatorTests
    {
        private OrderCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            ICanDiscountStrategy canDiscountStrategy = new GenderCanDiscountStrategy(Gender.Female);
            IDiscountStrategy discountStrategy = new PercentageDiscountStrategy(0.1m);

            calculator = new OrderCalculator(canDiscountStrategy, discountStrategy);
        }

        [TestMethod]
        public void CalculateDiscount_Female_ShouldDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.MinValue, new Customer { Gender = Gender.Female }, 100);

            // Act
            decimal discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(10, discount);

        }

        [TestMethod]
        public void CalculateDiscount_Male_ShouldNotDiscount()
        {
            // Arrange
            Order order = new Order(DateTime.MinValue, new Customer { Gender = Gender.Male }, 100);

            // Act
            decimal discount = calculator.CalculateDiscount(order);

            // Assert
            Assert.AreEqual(0, discount);

        }

    }
}
