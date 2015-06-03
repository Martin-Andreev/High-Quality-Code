namespace TravelAgency.Models
{
    using System;

    public class AirTicket : Ticket
    {
        public AirTicket(
            string flightNumber,
            string departureAirline,
            string arrivalAirline,
            string airlineCompany,
            DateTime departureDateTime, 
            decimal price)
            : base(
            departureAirline,
            arrivalAirline,
            airlineCompany,
            departureDateTime,
            price)
        {
            this.FlightNumber = flightNumber;
        }

        public AirTicket(string flightNumber)
            : this(flightNumber, null, null, null, new DateTime(), 0M)
        {
        }

        public string FlightNumber { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Air;
            }
        }

        public override string UniqueTicketKey
        {
            get
            {
                return string.Format("{0};;{1}", this.Type, this.FlightNumber);
            }
        }
    }
}