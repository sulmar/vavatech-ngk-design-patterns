namespace StrategyPattern
{
    public class FixedDiscountStrategy : IDiscountStrategy
    {
        private readonly decimal amount;

        public FixedDiscountStrategy(decimal amount)
        {
            this.amount = amount;
        }

        public decimal Discount(Order order)
        {
            return amount;
        }

        public decimal NoDiscount()
        {
            return decimal.Zero;
        }
    }
}
