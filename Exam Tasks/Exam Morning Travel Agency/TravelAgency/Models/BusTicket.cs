namespace TravelAgency.Models
{
    using System;

    public class BusTicket : Ticket
    {
        public BusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateTime, decimal price)
            : base(departureTown, arrivalTown, travelCompany, departureDateTime, price)
        {
        }

        public BusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateTime)
            : base(departureTown, arrivalTown, travelCompany, departureDateTime, 0M)
        {
        }

        public override TicketType Type
        {
            get
            {
                return TicketType.Bus;
            }
        }

        public override string UniqueTicketKey
        {
            get
            {
                return string.Format(
                    "{0};;{1};{2};{3};", 
                    this.Type,
                    this.DepartureTown,
                    this.ArrivalTown, 
                    this.Company + this.DateAndTime);
            }
        }
    }
}