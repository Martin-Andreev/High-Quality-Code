using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Theatre.Contracts;
using Theatre.Exceptions;

namespace Theatre.Tests
{
    [TestClass]
    public class TheatresTests
    {
        private IPerformanceDatabase theatreDatabase;

        [TestInitialize]
        public void InitializeTest()
        {
             theatreDatabase = new PerformanceDatabase();
        }

        [TestMethod]
        public void Test_AddTheatre_ShouldAddTheTheatre()
        {
            string theatreName = "Theatre Sofia";
            theatreDatabase.AddTheatre(theatreName);
            string[] expectedOutput = new[] { "Theatre Sofia" };
            var actualOutput = theatreDatabase.ListTheatres().ToList();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }
        
        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException))]
        public void Test_AddExistingTheatre_ShouldThrowException()
        {
            string theatreName = "Theatre Sofia";
            theatreDatabase.AddTheatre(theatreName);
            theatreDatabase.AddTheatre(theatreName);
        }

        [TestMethod]
        public void Test_AddSeveralTheatres_ShouldAddCorrectlySeveralTheatres()
        {
            theatreDatabase.AddTheatre("Theatre Sofia");
            theatreDatabase.AddTheatre("Theatre Burgas");
            theatreDatabase.AddTheatre("Theatre Varna");
            var expectedOutput = new[] { "Theatre Burgas", "Theatre Sofia", "Theatre Varna" };
            var actualOutput = theatreDatabase.ListTheatres().ToList();

            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Test_NoTheatres_ShouldReturnEmptyList()
        {
            IPerformanceDatabase performanceDb = new PerformanceDatabase();

            var actualTheatres = performanceDb.ListTheatres().ToList();

            Assert.AreEqual(0, actualTheatres.Count());
        }
    }
}
