using System;

namespace TemplateMethodPattern
{
    public class BlackFridayPercentageOrderCalculator : TemplateOrderCalculator
    {
        private readonly DateTime date;

        private readonly decimal percentage;

        public BlackFridayPercentageOrderCalculator(DateTime date, decimal percentage)
        {
            this.date = date;
            this.percentage = percentage;
        }

        public override bool CanDiscount(Order order)
        {
            return order.OrderDate.Date == date;
        }

        public override decimal Discount(Order order)
        {
            return order.Amount * percentage;
        }
        
    }


}
