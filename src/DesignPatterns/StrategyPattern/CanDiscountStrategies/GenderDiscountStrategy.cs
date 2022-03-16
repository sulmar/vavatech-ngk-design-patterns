namespace StrategyPattern
{
    public class GenderCanDiscountStrategy : ICanDiscountStrategy
    {
        private readonly Gender gender;

        public GenderCanDiscountStrategy(Gender gender)
        {
            this.gender = gender;
        }

        public bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }
    }
}
