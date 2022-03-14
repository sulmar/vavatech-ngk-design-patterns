using System;

namespace AbstractFactoryPattern
{
    // Fabryka abstrakcyjna
    public interface IVisitFactory
    {
        Visit Create(string kind, TimeSpan duration, decimal pricePerHour);
    }

    // Fabryka konkretna 
    public class VisitFactory : IVisitFactory
    {
        public Visit Create(string kind, TimeSpan duration, decimal pricePerHour)
        {
            switch(kind)
            {
                case "N": return new NFZVisit(duration, pricePerHour);
                case "P": return new PrivateVisit(duration, pricePerHour);
                case "F": return new CompanyVisit(duration, pricePerHour);
                case "T": return new TeleVisit(duration, pricePerHour);

                default:
                    throw new NotSupportedException();
            }
        }
    }

    // Konkretny produkt
    public class NFZVisit : Visit
    {
        public NFZVisit(TimeSpan duration, decimal pricePerHour) 
            : base(duration, 0)
        {

        }
    }

    // Konkretny produkt
    public class PrivateVisit : Visit
    {
        public PrivateVisit(TimeSpan duration, decimal pricePerHour) 
            : base(duration, pricePerHour)
        {
        }
    }

    // Konkretny produkt
    public class CompanyVisit : Visit
    {
        private const decimal companyDiscountPercentage = 0.9m;

        public CompanyVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return base.CalculateCost() * companyDiscountPercentage;
        }

    }

    public class TeleVisit : Visit
    {
        public TeleVisit(TimeSpan duration, decimal pricePerHour) : base(duration, pricePerHour)
        {
        }

        public override decimal CalculateCost()
        {
            return 100;
        }
    }

    // Abstrakcyjny produkt
    public abstract class Visit
    {
        public DateTime VisitDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal PricePerHour { get; set; }

        public Visit(TimeSpan duration, decimal pricePerHour)
        {
            VisitDate = DateTime.Now;
            Duration = duration;
            PricePerHour = pricePerHour;
        }

        public virtual decimal CalculateCost()
        {
            return (decimal)Duration.TotalHours * PricePerHour;
        }
    }
}
