namespace TravelAgency.Tests.Models.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Models;

    [TestClass]
    public class BusTicketsTests
    {
        private TravelAgencyRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tickets = new TravelAgencyRepository();
        }

        [TestMethod]
        public void Test_AddBusTicket_ShouldAddNewBusTicket()
        {
            string message = this.tickets.AddBusTicket(
                "Sofia",
                "Varna",
                "Biomet",
                new DateTime(2015, 1, 17, 12, 20, 0),
                100M);

            Assert.AreEqual("Ticket added", message);
        }

        [TestMethod]
        public void Test_AddExistingBusTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddBusTicket(
               "Sofia",
               "Varna",
               "Biomet",
               new DateTime(2015, 1, 17, 12, 20, 0),
               100M);
            string message = this.tickets.AddBusTicket(
               "Sofia",
               "Varna",
               "Biomet",
               new DateTime(2015, 1, 17, 12, 20, 0),
               100M);

            Assert.AreEqual("Duplicate ticket", message);
        }

        [TestMethod]
        public void Test_AddAirSeveralBusTickets_ShouldSuccessfullyAddNewBusTickets()
        {
            this.tickets.AddBusTicket(
               "Sofia",
               "Varna",
               "Biomet",
               new DateTime(2015, 1, 17, 12, 20, 0),
               200M);
            this.tickets.AddBusTicket(
               "Burgas",
               "Varna",
               "Biomet",
               new DateTime(2014, 5, 13, 12, 00, 0),
               100M);
            this.tickets.AddBusTicket(
               "Sofia",
               "Rio",
               "Aurubis",
               new DateTime(2013, 10, 12, 1, 40, 0),
               300M);

            Assert.AreEqual(3, this.tickets.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_DeleteBusTicket_ShouldDeleteTheCorrectTicket()
        {
            this.tickets.AddBusTicket(
               "Sofia",
               "Rio",
               "Aurubis",
               new DateTime(2013, 10, 12, 1, 40, 0),
               300M);
            this.tickets.AddBusTicket(
               "Burgas",
               "Varna",
               "Biomet",
               new DateTime(2015, 1, 2, 10, 00, 0),
               100M);
            this.tickets.AddBusTicket(
               "Burgas",
               "Varna",
               "Biomet",
               new DateTime(2014, 5, 13, 12, 00, 0),
               100M);
            string message = this.tickets.DeleteBusTicket("Burgas", "Varna", "Biomet", new DateTime(2014, 5, 13, 12, 00, 0));

            Assert.AreEqual("Ticket deleted", message);
            Assert.AreEqual(2, this.tickets.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void Test_DeleteNonExistingBusTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddBusTicket(
               "Burgas",
               "Varna",
               "Biomet",
               new DateTime(2014, 5, 13, 12, 00, 0),
               100M);
            string message = this.tickets.DeleteBusTicket("Plovdiv", "Kaspichan", "Biomet", new DateTime(2010, 5, 13, 12, 00, 0));

            Assert.AreEqual("Ticket does not exist", message);
        }
    }
}
