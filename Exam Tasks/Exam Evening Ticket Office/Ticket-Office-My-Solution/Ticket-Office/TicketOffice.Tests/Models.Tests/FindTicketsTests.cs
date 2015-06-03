namespace TicketOffice.Tests.Models.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ticket;
    using Ticket.Contracts;

    [TestClass]
    public class FindTicketsTests
    {
        private ITicketRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            tickets = new TicketRepository();
        }

        [TestMethod]
        public void Test_FindTicketsWithOneTicket_ShouldReturnTheCorrectTicket()
        {
            this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M);
            string message = this.tickets.FindTickets("Sofia", "Varna");

            Assert.AreEqual("[15.01.2015 06:15|bus|25.00]", message);
        }
        
        [TestMethod]
        public void Test_FindTickets_ShouldReturnOnlyTheCorrectTickets()
        {
            this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M); 
            this.tickets.AddBusTicket("Pernik", "Burgas", "Chocho", new DateTime(2015, 4, 15, 06, 15, 0), 25M); 
            this.tickets.AddBusTicket("Melnik", "Sandanski", "Etap", new DateTime(2015, 1, 10, 07, 25, 0), 10M);
            string message = this.tickets.FindTickets("Melnik", "Sandanski");

            Assert.AreEqual("[10.01.2015 07:25|bus|10.00]", message);
        }
        
        [TestMethod]
        public void Test_FindNonExistingTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddBusTicket("Melnik", "Sandanski", "Etap", new DateTime(2015, 1, 10, 07, 25, 0), 10M);
            string message = this.tickets.FindTickets("Sofia", "Varna");

            Assert.AreEqual("No matches", message);
        }
    }
}
