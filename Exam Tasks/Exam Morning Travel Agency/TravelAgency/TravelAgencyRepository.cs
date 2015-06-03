namespace TravelAgency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;
    using Utilities;
    using Wintellect.PowerCollections;

    public class TravelAgencyRepository : ITicketCatalog
    {
        private MultiDictionary<string, Ticket> ticketsfromTo = new MultiDictionary<string, Ticket>(true);
        private Dictionary<string, Ticket> ticketsByKey = new Dictionary<string, Ticket>();
        private OrderedMultiDictionary<DateTime, Ticket> ticketsByTime = new OrderedMultiDictionary<DateTime, Ticket>(true);
        private Dictionary<TicketType, int> ticketsCountByType = new Dictionary<TicketType, int>();

        public TravelAgencyRepository()
        {
            this.ticketsCountByType[TicketType.Air] = 0;
            this.ticketsCountByType[TicketType.Bus] = 0;
            this.ticketsCountByType[TicketType.Train] = 0;
        }

        public string AddAirTicket(
           string flightNumber,
           string departureAirline,
           string arrivalAiriline,
           string airlineCompany,
           DateTime departureDateTime,
           decimal price)
        {
            Ticket ticket = new AirTicket(
                flightNumber,
                departureAirline, 
                arrivalAiriline, 
                airlineCompany,
                departureDateTime,
                price);
            var result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            Ticket ticket = new AirTicket(flightNumber);
            string result = this.DeleteTicket(ticket);

            return result;
        }

        public string AddTrainTicket(
           string departureTown,
           string arrivalTown,
           DateTime departureDateTime,
           decimal price,
           decimal studentPrice)
        {
            var ticket = new TrainTicket(departureTown, arrivalTown, departureDateTime, price, studentPrice);
            var result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteTrainTicket(string departureTown, string arrivalTown, DateTime departureDateTime)
        {
            var ticket = new TrainTicket(departureTown, arrivalTown, departureDateTime);
            var result = this.DeleteTicket(ticket);

            return result;
        }

        public string AddBusTicket(
           string departureTown,
           string arrivalTown,
           string travelCompany,
           DateTime departureDateTime,
           decimal price)
        {
            var ticket = new BusTicket(departureTown, arrivalTown, travelCompany, departureDateTime, price);
            string result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateTime)
        {
            var ticket = new BusTicket(departureTown, arrivalTown, travelCompany, departureDateTime);
            var result = this.DeleteTicket(ticket);

            return result;
        }

        public string FindTickets(string departureTown, string arrivalTown)
        {
            string fromToKey = Ticket.CreateFromToKey(departureTown, arrivalTown);
            if (this.ticketsfromTo.ContainsKey(fromToKey))
            {
                var ticketsFound = this.ticketsfromTo[fromToKey];
                string ticketsResult = FormatTicketsForPrinting(ticketsFound);

                return ticketsResult;
            }                
                
            return TravelAgencyConstants.NotFound;
        }

        public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
        {
            var ticketsFound = this.ticketsByTime.Range(startDateTime, true, endDateTime, true).Values;
            if (ticketsFound.Any())
            {
                var ticketsResult = FormatTicketsForPrinting(ticketsFound);
                return ticketsResult;
            }

            return TravelAgencyConstants.NotFound;
        }

        public int GetTicketsCount(TicketType type)
        {
            return this.ticketsCountByType[type];
        }

        private static string FormatTicketsForPrinting(IEnumerable<Ticket> tickets)
        {
            var result = string.Join(" ", tickets.OrderBy(t => t.DateAndTime).ThenBy(t => t.Type).ThenBy(t => t.Price));
            return result;
        }

        private string DeleteTicket(Ticket ticket)
        {
            var key = ticket.UniqueTicketKey;
            if (this.ticketsByKey.ContainsKey(key))
            {
                ticket = this.ticketsByKey[key];
                this.ticketsByKey.Remove(key);
                var fromToKey = ticket.FromToKey;
                this.ticketsfromTo.Remove(fromToKey, ticket);
                this.ticketsByTime.Remove(ticket.DateAndTime, ticket);
                this.ticketsCountByType[ticket.Type]--;

                return TravelAgencyConstants.SuccessfullyDeletedTicket;
            }

            return TravelAgencyConstants.TicketDoesNotExist;
        }

        private string AddTicket(Ticket ticket)
        {
            var key = ticket.UniqueTicketKey;
            if (this.ticketsByKey.ContainsKey(key))
            {
                return TravelAgencyConstants.DuplicatedTicket;
            }

            this.ticketsByKey.Add(key, ticket);
            var fromToKey = ticket.FromToKey;
            this.ticketsfromTo.Add(fromToKey, ticket);
            this.ticketsByTime.Add(ticket.DateAndTime, ticket);
            this.ticketsCountByType[ticket.Type]++;

            return TravelAgencyConstants.SuccessfullyAddedTicket;
        }
    }
}