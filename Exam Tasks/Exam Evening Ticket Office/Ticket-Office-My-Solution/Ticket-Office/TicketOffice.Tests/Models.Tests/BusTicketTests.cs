namespace TicketOffice.Tests.Models.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ticket;
    using Ticket.Contracts;

    [TestClass]
    public class BusTicketTests
    {
        private ITicketRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            tickets = new TicketRepository();
        }

        [TestMethod]
        public void Test_AddBusTicket_ShouldCreateNewTicket()
        {
            string message = this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M);

            Assert.AreEqual("Bus created", message);
        }

        [TestMethod]
        public void Test_AddExistBusTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M);
            string message = this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M);

            Assert.AreEqual("Duplicated bus", message);
        }

        [TestMethod]
        public void Test_DeleteExistingBusTicket_ShouldDeleteTicket()
        {
            this.tickets.AddBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0), 25M);
            string message = this.tickets.DeleteBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0));

            Assert.AreEqual("Bus deleted", message);
        }

        [TestMethod]
        public void Test_DeleteNotExistingBusTicket_ShouldReturnErrorMessage()
        {
            string message = this.tickets.DeleteBusTicket("Sofia", "Varna", "Etap", new DateTime(2015, 1, 15, 06, 15, 0));

            Assert.AreEqual("Bus does not exist", message);
        }
    }
}
