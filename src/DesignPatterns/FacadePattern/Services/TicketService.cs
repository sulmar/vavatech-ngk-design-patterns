using FacadePattern.Models;
using FacadePattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Services
{
    public class TicketService
    {
        private readonly RailwayConnectionRepository railwayConnectionRepository;
        private readonly TicketCalculator ticketCalculator;
        private readonly ReservationService reservationService;
        private readonly PaymentService paymentService;
        private readonly EmailService emailService;

        public TicketService(RailwayConnectionRepository railwayConnectionRepository, TicketCalculator ticketCalculator, ReservationService reservationService, PaymentService paymentService, EmailService emailService)
        {
            this.railwayConnectionRepository = railwayConnectionRepository;
            this.ticketCalculator = ticketCalculator; 
            this.reservationService = reservationService;
            this.paymentService = paymentService;
            this.emailService = emailService;
            
        }

        public Ticket BuyTicket(string from, string to, DateTime when, byte numberOfPlaces)
        {
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(from, to, when);
            decimal price = ticketCalculator.Calculate(railwayConnection, numberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, numberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;
        }

        public void CancelTicket(Ticket ticket)
        {
            reservationService.CancelReservation(ticket.RailwayConnection, ticket.NumberOfPlaces);
            paymentService.RefundPayment(new Payment { TotalAmount = -ticket.Price });
        }
    }
}
