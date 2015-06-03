namespace TicketOffice.Tests.Models.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ticket;
    using Ticket.Contracts;

    [TestClass]
    public class TrainTicketTests
    {
        private ITicketRepository tickets;

        [TestInitialize]
        public void InitializeTest()
        {
            tickets = new TicketRepository();
        }

        [TestMethod]
        public void Test_AddTrainTicket_ShouldCreateNewTicket()
        {
            string message = this.tickets.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 17, 12, 20, 0), 6.6M, 2.4M);

            Assert.AreEqual("Train created", message);
        }

        [TestMethod]
        public void Test_AddExistTrainTicket_ShouldReturnErrorMessage()
        {
            this.tickets.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 17, 12, 20, 0), 6.6M, 2.4M);
            string message = this.tickets.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 17, 12, 20, 0), 6.6M, 2.4M);

            Assert.AreEqual("Duplicated train", message);
        }

        [TestMethod]
        public void Test_DeleteExistingTrainTicket_ShouldDeleteTicket()
        {
            this.tickets.AddTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 17, 12, 20, 0), 6.6M, 2.4M);
            string message = this.tickets.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 17, 12, 20, 0));

            Assert.AreEqual("Train deleted", message);
        }

        [TestMethod]
        public void Test_DeleteNotExistingTrainTicket_ShouldReturnErrorMessage()
        {
            string message = this.tickets.DeleteTrainTicket("Sofia", "Varna", new DateTime(2015, 1, 17, 12, 20, 0));

            Assert.AreEqual("Train does not exist", message);
        }
    }
}
