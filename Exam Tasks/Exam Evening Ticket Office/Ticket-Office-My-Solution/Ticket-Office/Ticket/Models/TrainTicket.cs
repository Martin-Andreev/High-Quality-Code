namespace Ticket.Models
{
    using System;
    using Enums;

    internal class TrainTicket : Ticket
    {
        public TrainTicket(string departureTown, string arrivalTown, DateTime departureDateTime, decimal regularPrice, decimal studentPrice) : base(departureTown, arrivalTown, departureDateTime, regularPrice)
        {
            this.StudentPrice = studentPrice;
        }

        public TrainTicket(string departureTown, string arrivalTown, DateTime departureDateTime)
            : this(departureTown, arrivalTown, departureDateTime, 0M, 0M)
        {
        }

        public decimal StudentPrice { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Train;
            }
        }

        public override string TicketKey
        {
            get
            {
                return string.Format("{0};;{1};{2};{3};", this.Type, this.DepartureTown, this.ArrivalTown, this.DepartureDateAndTime);
            }
        }
    }
}