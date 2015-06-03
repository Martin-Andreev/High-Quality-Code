namespace Ticket.Models
{
    using System;
    using Enums;

    public class AirTicket : Ticket
    {
        public AirTicket(string flightNumber, string departureAirport, string arrivalAirport, string airlineCompany, DateTime departureDateAndTime, decimal price) : base(departureAirport, arrivalAirport, departureDateAndTime, price)
        {
            this.FlightNumber = flightNumber;
            this.AirlineCompany = airlineCompany;
        }

        public AirTicket(string flightNumber)
            : this(flightNumber, null, null, null, default(DateTime), 0M)
        {
        }

        public string AirlineCompany { get; set; }

        public string FlightNumber { get; set; }

        public override TicketType Type
        {
            get
            {
                return TicketType.Flight;
            }
        }

        public override string TicketKey
        {
            get
            {
                return string.Format("{0};;{1}", this.Type, this.FlightNumber);
            }
        }
    }
}