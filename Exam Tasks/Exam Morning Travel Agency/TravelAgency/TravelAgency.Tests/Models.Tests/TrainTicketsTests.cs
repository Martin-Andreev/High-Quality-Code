namespace TravelAgency.Tests.Models.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TravelAgency.Models;

    [TestClass]
    public class TrainTicketsTests
    {
        private TravelAgencyRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tickets = new TravelAgencyRepository();
        }

        [TestMethod]
        public void Test_AddTrainTicket_ShouldAddNewTrainTicket()
        {
            var message = this.tickets.AddTrainTicket(
                "Sofia",
                "Varna",
                new DateTime(2015, 1, 17, 12, 20, 0),
                100M,
                50M);

            Assert.AreEqual("Ticket added", message);
        }

        [TestMethod]
        public void Test_AddExistingTrainTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddTrainTicket(
                "Sofia",
                "Varna",
                new DateTime(2015, 1, 17, 12, 20, 0),
                100M,
                50M);
            var message = this.tickets.AddTrainTicket(
                "Sofia",
                "Varna",
                new DateTime(2015, 1, 17, 12, 20, 0),
                100M,
                50M);

            Assert.AreEqual("Duplicate ticket", message);
        }

        [TestMethod]
        public void Test_AddSeveralTrainTickets_ShouldSuccessfullyAddNewTrainTickets()
        {
            this.tickets.AddTrainTicket(
                "Sofia",
                "Varna",
                new DateTime(2015, 1, 17, 12, 20, 0),
                100M,
                50M);
            this.tickets.AddTrainTicket(
                "Plovdiv",
                "Pernik",
                new DateTime(2012, 10, 11, 12, 00, 0),
                70M,
                30M);
            this.tickets.AddTrainTicket(
                "Madrid",
                "Paris",
                new DateTime(2015, 3, 14, 06, 30, 0),
                500M,
                300M);

            Assert.AreEqual(3, this.tickets.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void Test_DeleteTrainTicket_ShouldDeleteTheCorrectTicket()
        {
            this.tickets.AddTrainTicket(
                "Madrid",
                "Paris",
                new DateTime(2015, 3, 14, 06, 30, 0),
                500M,
                300M);
            var message = this.tickets.DeleteTrainTicket("Madrid", "Paris", new DateTime(2015, 3, 14, 06, 30, 0));

            Assert.AreEqual("Ticket deleted", message);
            Assert.AreEqual(0, this.tickets.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void Test_DeleteNonExistingTrainTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddTrainTicket(
                "Madrid",
                "Paris",
                new DateTime(2015, 3, 14, 06, 30, 0),
                500M,
                300M);
            var message = this.tickets.DeleteTrainTicket("Manchester", "Athens", new DateTime(2015, 02, 10, 15, 00, 0));

            Assert.AreEqual("Ticket does not exist", message);
        }
    }
}