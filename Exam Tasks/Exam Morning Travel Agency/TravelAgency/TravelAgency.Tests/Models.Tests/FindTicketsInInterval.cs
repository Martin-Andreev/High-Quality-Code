using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TravelAgency.Tests.Models.Tests
{
    [TestClass]
    public class FindTicketsInInterval
    {
        private TravelAgencyRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tickets = new TravelAgencyRepository();
        }

        [TestMethod]
        public void Test_FindTicketsInIntervalWithOneTicket_ShouldReturnTheCorrectTicket()
        {
            tickets.AddAirTicket(
                "FX215",
                "Sofia",
                "Varna",
                "Bulgaria Air",
                new DateTime(2015, 1, 17, 12, 20, 0),
                200M);

            string message = this.tickets.FindTicketsInInterval(
                new DateTime(2015, 1, 17, 0, 0, 0),
                new DateTime(2015, 1, 18, 0, 0, 0));
            Assert.AreEqual("[17.01.2015 12:20; air; 200.00]", message);
        }

        [TestMethod]
        public void Test_FindTicketsInInterval_ShouldReturnOnlyTheCorrectTickets()
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
                100.20M);
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

            string message = this.tickets.FindTicketsInInterval(
                new DateTime(2015, 3, 09, 0, 0, 0),
                new DateTime(2015, 3, 11, 0, 0, 0));
            Assert.AreEqual("[10.03.2015 11:00; bus; 100.20]", message);
        }

        [TestMethod]
        public void Test_FindTicketsInIntervalInEmptyCatalog_ShouldReturnErrorMessage()
        {
            string message = this.tickets.FindTicketsInInterval(
                new DateTime(2015, 1, 17, 0, 0, 0),
                new DateTime(2015, 1, 18, 0, 0, 0));
            Assert.AreEqual("Not found", message);
        }

        [TestMethod]
        public void Test_FindWrongTicketsInInterval_ShouldReturnNoTickets()
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
                100.20M);
            this.tickets.AddTrainTicket(
                "Plovdiv",
                "Pernik",
                new DateTime(2012, 10, 11, 12, 00, 0),
                70M,
                30M);

            string message = this.tickets.FindTicketsInInterval(
                new DateTime(2004, 1, 1, 0, 0, 0),
                new DateTime(2004, 12, 31, 0, 0, 0));
            Assert.AreEqual("Not found", message);
        }

        [TestMethod]
        public void Test_FindTickets_ShouldSortProperly()
        {
            this.tickets.AddAirTicket(
                 "FX215",
                 "Sofia",
                 "Plovdiv",
                 "Bulgaria Air",
                 new DateTime(2015, 4, 15, 20, 00, 0),
                 350M);
            this.tickets.AddTrainTicket(
                "Sofia",
                "Plovdiv",
                new DateTime(2015, 4, 15, 21, 00, 0),
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
                "Sofia",
                "Varna",
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
              "Sofia",
              "Varna",
              "Biomet",
              new DateTime(2015, 4, 15, 20, 00, 0),
              150M);

            string realMessage = this.tickets.FindTicketsInInterval(
                new DateTime(2015, 4, 15, 17, 0, 0),
                new DateTime(2015, 4, 15, 22, 0, 0));
            string expectedMessage = "[15.04.2015 20:00; air; 350.00] [15.04.2015 20:00; bus; 150.00] [15.04.2015 21:00; train; 70.00]";
            Assert.AreEqual(expectedMessage, realMessage);
        }
    }
}