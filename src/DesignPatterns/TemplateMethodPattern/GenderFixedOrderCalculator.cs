namespace TemplateMethodPattern
{
    public class GenderFixedOrderCalculator : TemplateOrderCalculator
    {
        private readonly Gender gender;

        private readonly decimal amount;

        public GenderFixedOrderCalculator(Gender gender, decimal amount)
        {
            this.gender = gender;
            this.amount = amount;
        }

        public override bool CanDiscount(Order order)
        {
            return order.Customer.Gender == gender;
        }

        public override decimal Discount(Order order)
        {
            return amount;
        }
    }
}
