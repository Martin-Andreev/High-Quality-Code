namespace Ticket.Models
{
    using System;
    using Enums;

    public class BusTicket : Ticket
    {
        public BusTicket(
            string departureTown,
            string arrivalTown,
            string travelCompany,
            DateTime departureDateTime,
            decimal price)
            : base(departureTown, arrivalTown, departureDateTime, price)
        {
            this.TravelCompany = travelCompany;
        }

        public BusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateTime)
            : this(departureTown, arrivalTown, travelCompany, departureDateTime, 0M)
        {
        }

        public string TravelCompany { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Bus;
            }
        }

        public override string TicketKey
        {
            get
            {
                return string.Format("{0};;{1};{2};{3};{4};", this.Type, this.DepartureTown, this.ArrivalTown, this.TravelCompany, this.DepartureDateAndTime);
            }
        }
    }
}