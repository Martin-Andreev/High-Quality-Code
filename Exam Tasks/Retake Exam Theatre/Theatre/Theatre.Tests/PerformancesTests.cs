using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theatre.Contracts;
using Theatre.Exceptions;

namespace Theatre.Tests
{
    [TestClass]
    public class PerformancesTests
    {
        private IPerformanceDatabase theatreDatabase;

        [TestInitialize]
        public void InitializeTest()
        {
            theatreDatabase = new PerformanceDatabase();
        }

        [TestMethod]
        public void Test_AddPerformance_ShouldAddThePerformance()
        {
            theatreDatabase.AddTheatre("Theatre Sofia");
            theatreDatabase.AddPerformance(
                "Theatre Sofia", 
                "Bella Donna",
                new DateTime(2015, 01, 20, 20, 30, 00),
                new TimeSpan(0, 1, 0, 0),
                12);
            string expectedOutput = "(Bella Donna, Theatre Sofia, 20.01.2015 20:30)" ;
            string actualOutput = string.Join(", ", theatreDatabase.ListAllPerformances());
            
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Test_AddSeveralPerformances_ShouldAddCorrectlyThePerformances()
        {
            theatreDatabase.AddTheatre("Theatre Sofia");
            theatreDatabase.AddPerformance(
                "Theatre Sofia",
                "Bella Donna",
                new DateTime(2015, 01, 20, 20, 30, 00),
                new TimeSpan(0, 1, 0, 0),
                12);
            theatreDatabase.AddPerformance(
              "Theatre Sofia",
              "Ali Raza",
              new DateTime(2015, 01, 25, 10, 00, 00),
              new TimeSpan(0, 2, 0, 0),
              12);
            string expectedOutput = 
                "(Bella Donna, Theatre Sofia, 20.01.2015 20:30), (Ali Raza, Theatre Sofia, 25.01.2015 10:00)";
            string actualOutput = string.Join(", ", theatreDatabase.ListAllPerformances());

            Assert.AreEqual(expectedOutput, actualOutput);
            Assert.AreEqual(2, theatreDatabase.ListAllPerformances().Count());
        }
        
        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void Test_AddPerformanceAtNonExistingTheatre_ShouldThrowException()
        {
            theatreDatabase.AddPerformance(
                "Theatre Sofia", 
                "Bella Donna",
                new DateTime(2015, 01, 20, 20, 30, 00),
                new TimeSpan(0, 1, 0, 0),
                12);
        }
        
        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void Test_AddOverlappingPerformanceAt_ShouldThrowException()
        {
            theatreDatabase.AddTheatre("Theatre Sofia");
            theatreDatabase.AddPerformance(
                "Theatre Sofia", 
                "Bella Donna",
                new DateTime(2015, 01, 20, 20, 30, 00),
                new TimeSpan(0, 1, 0, 0),
                12);
            theatreDatabase.AddPerformance(
                "Theatre Sofia",
                "Ali Raza",
                new DateTime(2015, 01, 20, 21, 00, 00),
                new TimeSpan(0, 2, 0, 0),
                12);
        }

        [TestMethod]
        public void Test_PrintPerformancesAtDefinedTheatre_ShouldReturnMessageWithAllPerformances()
        {
            theatreDatabase.AddTheatre("Theatre Sofia");
            theatreDatabase.AddTheatre("Theatre 199");
            theatreDatabase.AddPerformance(
                "Theatre Sofia",
                "Bella Donna",
                new DateTime(2015, 01, 20, 22, 00, 00),
                new TimeSpan(0, 1, 0, 0),
                12);
            theatreDatabase.AddPerformance(
             "Theatre 199",
             "Baba Vuna",
             new DateTime(2015, 11, 5, 10, 00, 00),
             new TimeSpan(0, 2, 0, 0),
             12);
            theatreDatabase.AddPerformance(
             "Theatre Sofia",
             "Ali Raza",
             new DateTime(2015, 01, 20, 20, 00, 00),
             new TimeSpan(0, 1, 0, 0),
             12);
            string expectedOutput =
               "(Ali Raza, Theatre Sofia, 20.01.2015 20:00), (Bella Donna, Theatre Sofia, 20.01.2015 22:00)";
            string actualOutput = string.Join(", ", theatreDatabase.ListPerformances("Theatre Sofia"));

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void Test_PrintPerformancesAtDefinedNonExistingTheatre_ShouldThrowException()
        {
            theatreDatabase.AddPerformance(
                "Theatre Sofia",
                "Bella Donna",
                new DateTime(2015, 01, 20, 22, 00, 00),
                new TimeSpan(0, 1, 0, 0),
                12);
        }
    }
}
