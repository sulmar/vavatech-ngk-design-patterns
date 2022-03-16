namespace StrategyPattern
{
    public interface ICanDiscountStrategy
    {
        bool CanDiscount(Order order);
    }
}
