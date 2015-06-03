namespace TicketOffice.Tests.Models.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ticket;
    using Ticket.Contracts;

    [TestClass]
    public class FindTicketsInIntervalTests
    {
        private ITicketRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            tickets = new TicketRepository();
        }

        [TestMethod]
        public void Test_FindTicketsInIntervalWithOneTicket_ShouldReturnTheCorrectTicket()
        {
            this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M);
            string message = this.tickets.FindTicketsInInterval(
                new DateTime(2015, 1, 10, 06, 15, 0),
                new DateTime(2015, 1, 17, 06, 15, 0));

            Assert.AreEqual("[15.01.2015 06:15|bus|25.00]", message);
        }

        [TestMethod]
        public void Test_FindTicketsInInterval_ShouldReturnOnlyTheCorrectTickets()
        {
            this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2016, 1, 15, 06, 15, 0), 25M);
            this.tickets.AddBusTicket("Pernik", "Burgas", "Chocho", new DateTime(2015, 4, 15, 06, 15, 0), 25M);
            this.tickets.AddBusTicket("Melnik", "Sandanski", "Etap", new DateTime(2015, 1, 10, 07, 25, 0), 10M);
            string message = this.tickets.FindTicketsInInterval(
                new DateTime(2015, 1, 1, 06, 15, 0),
                new DateTime(2015, 2, 17, 06, 15, 0));

            Assert.AreEqual("[10.01.2015 07:25|bus|10.00]", message);
        }

        [TestMethod]
        public void Test_FindTicketsInIntervalInEpmtyRepository_ShouldReturnErrorMessage()
        {
            string message = this.tickets.FindTicketsInInterval(
                new DateTime(2010, 1, 1, 06, 15, 0),
                new DateTime(2015, 2, 17, 06, 15, 0));

            Assert.AreEqual("No matches", message);
        }
    }
}
