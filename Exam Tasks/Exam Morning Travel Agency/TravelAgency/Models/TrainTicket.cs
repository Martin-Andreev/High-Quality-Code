namespace TravelAgency.Models
{
    using System;

    public class TrainTicket : Ticket
    {
        public TrainTicket(
            string departureTown, 
            string arrivalTown,
            DateTime departureDateTime,
            decimal regularPrice, 
            decimal studentPrice) 
            : base(
            departureTown, 
            arrivalTown, 
            null,
            departureDateTime,
            regularPrice)
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

        public override string UniqueTicketKey
        {
            get
            {
                return string.Format("{0};;{1};{2};{3};", this.Type, this.DepartureTown, this.ArrivalTown, this.DateAndTime);
            }
        }
    }
}