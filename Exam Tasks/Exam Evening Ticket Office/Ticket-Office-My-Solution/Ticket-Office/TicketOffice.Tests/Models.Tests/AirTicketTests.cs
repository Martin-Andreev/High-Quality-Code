namespace TicketOffice.Tests.Models.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ticket;
    using Ticket.Contracts;

    [TestClass]
    public class AirTicketTests
    {
        private ITicketRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            tickets = new TicketRepository();
        }

        [TestMethod]
        public void Test_AddAirTicket_ShouldCreateNewTicket()
        {
            string message = this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);

            Assert.AreEqual("Flight created", message);
        }

        [TestMethod]
        public void Test_AddExistAirTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddAirTicket(
               "FX215",
               "Sofia",
               "Varna",
               "Bulgaria Air",
               new DateTime(2015, 1, 17, 12, 20, 0),
               200M);
            string message = this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);;

            Assert.AreEqual("Duplicated flight", message);
        }

        [TestMethod]
        public void Test_DeleteExistingAirTicket_ShouldDeleteTicket()
        {
            this.tickets.AddAirTicket(
               "FX215",
               "Sofia",
               "Varna",
               "Bulgaria Air",
               new DateTime(2015, 1, 17, 12, 20, 0),
               200M);
            string message = this.tickets.DeleteAirTicket("FX215");

            Assert.AreEqual("Flight deleted", message);
        }

        [TestMethod]
        public void Test_DeleteNotExistingAirTicket_ShouldReturnErrorMessage()
        {
            string message = this.tickets.DeleteAirTicket("FX215");

            Assert.AreEqual("Flight does not exist", message);
        }
    }
}
