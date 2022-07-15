using FacadePattern.Models;
using FacadePattern.Repositories;
using FacadePattern.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FacadePattern.UnitTests
{
    [TestClass]
    public class TicketServiceTests
    {
        [TestMethod]
        public void BuyTicket_ValidRailwayConnection_ShouldReturnsTicket()
        {
            // Arrange
            string from = "Bydgoszcz";
            string to = "Warszawa";
            DateTime when = DateTime.Parse("2022-07-15");
            byte numberOfPlaces = 3;

            RailwayConnectionRepository railwayConnectionRepository = new RailwayConnectionRepository();
            TicketCalculator ticketCalculator = new TicketCalculator();
            ReservationService reservationService = new ReservationService();
            PaymentService paymentService = new PaymentService();
            EmailService emailService = new EmailService();

            TicketService ticketService = new TicketService(railwayConnectionRepository, ticketCalculator, reservationService, paymentService, emailService);

            // Act
            Ticket ticket = ticketService.BuyTicket(from, to, when, numberOfPlaces);

            // Assert           
            Assert.AreEqual("Bydgoszcz", ticket.RailwayConnection.From);
            Assert.AreEqual("Warszawa", ticket.RailwayConnection.To);
            Assert.AreEqual(DateTime.Parse("2022-07-15"), ticket.RailwayConnection.When);
            Assert.AreEqual(3, ticket.NumberOfPlaces);            
        }

        [TestMethod]
        public void CancelTicket()
        {
            // Arrange
            string from = "Bydgoszcz";
            string to = "Warszawa";
            DateTime when = DateTime.Parse("2022-07-15");
            byte numberOfPlaces = 3;

            RailwayConnectionRepository railwayConnectionRepository = new RailwayConnectionRepository();
            TicketCalculator ticketCalculator = new TicketCalculator();
            ReservationService reservationService = new ReservationService();
            PaymentService paymentService = new PaymentService();
            EmailService emailService = new EmailService();

            TicketService ticketService = new TicketService(railwayConnectionRepository, ticketCalculator, reservationService, paymentService, emailService);

            Ticket ticket = ticketService.BuyTicket(from, to, when, numberOfPlaces);

            // Act
            ticketService.CancelTicket(ticket);



        }
            
    }

}
