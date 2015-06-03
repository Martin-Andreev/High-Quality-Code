namespace TicketOffice.Tests.Models.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ticket;
    using Ticket.Contracts;
    using Ticket.Enums;

    [TestClass]
    public class GetTicketsCountTests
    {
        private ITicketRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            tickets = new TicketRepository();
        }

        [TestMethod]
        public void Test_GetTicketsCount_WithAirTickets_ShouldReturnTheCorrectCount()
        {
            this.tickets.AddAirTicket("FX215", "Sofia", "Varna", "Bulgaria Air", new DateTime(2015, 1, 17, 12, 20, 0), 200M);

            Assert.AreEqual(1, this.tickets.GetTicketsCount(TicketType.Flight));
            Assert.AreEqual(0, this.tickets.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual(0, this.tickets.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void Test_GetTicketsCount_WithBusTickets_ShouldReturnTheCorrectCount()
        {
            this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M);

            Assert.AreEqual(0, this.tickets.GetTicketsCount(TicketType.Flight));
            Assert.AreEqual(1, this.tickets.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual(0, this.tickets.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void Test_GetTicketsCount_WithTrainTickets_ShouldReturnTheCorrectCount()
        {
            this.tickets.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 17, 12, 20, 0), 6.6M, 2.4M);

            Assert.AreEqual(0, this.tickets.GetTicketsCount(TicketType.Flight));
            Assert.AreEqual(0, this.tickets.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual(1, this.tickets.GetTicketsCount(TicketType.Train));
        }
    }
}
