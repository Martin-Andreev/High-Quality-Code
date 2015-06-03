namespace TravelAgency.Tests.Models.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Models;

    [TestClass]
    public class AirTicketsTests
    {
        private TravelAgencyRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tickets = new TravelAgencyRepository();
        }

        [TestMethod]
        public void Test_AddAirTicket_ShouldAddNewAirTicket()
        {
            string message = this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);

            Assert.AreEqual("Ticket added", message);
        }

        [TestMethod]
        public void Test_AddExistingAirTicket_ShouldReturnErrorMessage()
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
                200M);

            Assert.AreEqual("Duplicate ticket", message);
        }

        [TestMethod]
        public void Test_AddAirSeveralAirTickets_ShouldSuccessfullyAddNewAirTickets()
        {
            this.tickets.AddAirTicket(
                "QA215",
                "Pomorie",
                "Vidin",
                "Bulgaria Air",
                new DateTime(2015, 2, 10, 11, 10, 0),
                220M);
            this.tickets.AddAirTicket(
                "PO201",
                "London",
                "Pirdop",
                "Pirdop Air",
                new DateTime(2020, 10, 1, 10, 20, 0),
                200M);
            this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);

            Assert.AreEqual(3, this.tickets.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void Test_DeleteAirTicket_ShouldDeleteTheCorrectTicket()
        {
            this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);
            this.tickets.AddAirTicket(
               "PO201",
               "London",
               "Pirdop",
               "Pirdop Air",
               new DateTime(2020, 10, 1, 10, 20, 0),
               200M);
            string message = this.tickets.DeleteAirTicket("PO201");

            Assert.AreEqual("Ticket deleted", message);
            Assert.AreEqual(1, this.tickets.GetTicketsCount(TicketType.Air));
        }

        [TestMethod]
        public void Test_DeleteNonExistingAirTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);
            string message = this.tickets.DeleteAirTicket("PO201");

            Assert.AreEqual("Ticket does not exist", message);
        }
    }
}
