using FacadePattern.Models;

namespace FacadePattern.Services
{

    public class TicketCalculator
    {
        private readonly decimal amount = 1.99m;

        public decimal Calculate(RailwayConnection railwayConnection, byte numberOfPlaces)
        {
            return railwayConnection.Distance * amount * numberOfPlaces;
        }

    }

    public class PaymentService
    {
        public Payment CreateActivePayment(Ticket ticket)
        {
            return new Payment { TotalAmount = ticket.Price };
        }

        public void RefundPayment(Payment payment)
        {

        }
    }

   
}
