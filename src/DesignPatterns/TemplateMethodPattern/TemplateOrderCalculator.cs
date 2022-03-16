namespace TemplateMethodPattern
{
    // Szablon metody (Template Method)
    public abstract class TemplateOrderCalculator
    {
        public abstract bool CanDiscount(Order order);
        public abstract decimal Discount(Order order);
        public virtual decimal NotDiscount()
        {
            return decimal.Zero;
        }

        public decimal CalculateDiscount(Order order)
        {
            if (CanDiscount(order))                                        // warunek (predikat)
            {
                return Discount(order);                                     // obliczanie upustu
            }
            else
                return NotDiscount();                                            // brak upustu
        }
    }

}
