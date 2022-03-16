using System;

namespace StrategyPattern
{
    public class BlackFridayCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly DateTime date;

        public BlackFridayCanDiscountStrategy(DateTime date)
        {
            this.date = date;
        }

        public bool CanDiscount(Order order)
        {
            return order.OrderDate.Date == date;
        }
    }
}
