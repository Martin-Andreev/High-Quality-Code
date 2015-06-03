namespace TravelAgency.Tests.Models.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindTicketsTests
    {
        private TravelAgencyRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tickets = new TravelAgencyRepository();
        }

        [TestMethod]
        public void Test_FindTicketsWithOneTicket_ShouldReturnTheCorrectTicket()
        {
            this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);

            string message = this.tickets.FindTickets("Sofia", "Varna");
            Assert.AreEqual("[17.01.2015 12:20; air; 200.00]", message);
        }

        [TestMethod]
        public void Test_FindTicketsWithSeveralTickets_ShouldReturnTheCorrectTickets()
        {
            this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);
            this.tickets.AddBusTicket(
               "Sofia",
               "Varna",
               "Biomet",
               new DateTime(2015, 3, 10, 11, 00, 0),
               100M);
            this.tickets.AddTrainTicket(
                "Plovdiv",
                "Pernik",
                new DateTime(2012, 10, 11, 12, 00, 0),
                70M,
                30M);
            this.tickets.AddAirTicket(
                "PU",
                "Plovdiv",
                "Burgas",
                "Bulgaria Air",
                new DateTime(2014, 10, 17, 10, 30, 0),
                200M);
            string message = this.tickets.FindTickets("Sofia", "Varna");
            Assert.AreEqual("[17.01.2015 12:20; air; 200.00] [10.03.2015 11:00; bus; 100.00]", message);
        }

        [TestMethod]
        public void Test_FindNonExistingTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);

            string message = this.tickets.FindTickets("Sozopol", "Sunny Beach");
            Assert.AreEqual("Not found", message);
        }

        [TestMethod]
        public void Test_FindTicketsInEmptyCatalog_ShouldReturnErrorMessage()
        {
            string message = this.tickets.FindTickets("Sofia", "Plovdiv");
            Assert.AreEqual("Not found", message);
        }

        [TestMethod]
        public void Test_FindTickets_ShouldSortProperlyTheCorrectTickets()
        {
            this.tickets.AddAirTicket(
                "FX215",
                "London",
                "Plovdiv",
                "Bulgaria Air",
                new DateTime(2015, 6, 10, 10, 45, 0),
                200M);
            this.tickets.AddTrainTicket(
                "Plovdiv",
                "Pernik",
                new DateTime(2012, 10, 11, 12, 00, 0),
                70M,
                30M);
            this.tickets.AddAirTicket(
                "PU200",
                "London",
                "Plovdiv",
                "Bulgaria Air",
                new DateTime(2015, 6, 10, 10, 30, 0),
                200M);
            this.tickets.AddTrainTicket(
                "London",
                "Plovdiv",
                new DateTime(2015, 6, 10, 10, 30, 0),
                70M,
                30M);
            this.tickets.AddAirTicket(
                "PU",
                "Sofia",
                "Burgas",
                "Bulgaria Air",
                new DateTime(2014, 10, 17, 10, 30, 0),
                200M);
            this.tickets.AddAirTicket(
                "TU101",
                "London",
                "Plovdiv",
                "London Air",
                new DateTime(2015, 6, 10, 10, 45, 0),
                300M);
            this.tickets.AddBusTicket(
              "London",
              "Plovdiv",
              "Biomet",
              new DateTime(2015, 6, 29, 15, 00, 0),
              150M);

            string realMessage = this.tickets.FindTickets("London", "Plovdiv");
            string expectedMessage =
                "[10.06.2015 10:30; air; 200.00] [10.06.2015 10:30; train; 70.00] [10.06.2015 10:45; air; 200.00] [10.06.2015 10:45; air; 300.00] [29.06.2015 15:00; bus; 150.00]";

            Assert.AreEqual(expectedMessage, realMessage);
        }
    }
}