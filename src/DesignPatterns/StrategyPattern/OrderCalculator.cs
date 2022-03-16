namespace StrategyPattern
{
    public class OrderCalculator
    {
        private readonly ICanDiscountStrategy canDiscountStrategy;
        private readonly IDiscountStrategy discountStrategy;        

        public OrderCalculator(ICanDiscountStrategy canDiscountStrategy, IDiscountStrategy discountStrategy)
        {
            this.canDiscountStrategy = canDiscountStrategy;
            this.discountStrategy = discountStrategy;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (canDiscountStrategy.CanDiscount(order))      // Predikat
            {
                return discountStrategy.Discount(order);                                           // Upust
            }
            else
                return discountStrategy.NoDiscount();
        }
    }
}
