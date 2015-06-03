namespace Ticket
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Enums;
    using Models;
    using Wintellect.PowerCollections;

    public class TicketRepository : ITicketRepository
    {
        private Dictionary<string, Ticket> ticketsByKey = new Dictionary<string, Ticket>();
        private MultiDictionary<string, Ticket> ticketsFromTo = new MultiDictionary<string, Ticket>(true);
        private OrderedMultiDictionary<DateTime, Ticket> ticketsByDate = new OrderedMultiDictionary<DateTime, Ticket>(true);
        private Dictionary<TicketType, int> ticketCountByType = new Dictionary<TicketType, int>();

        public TicketRepository()
        {
            this.ticketCountByType[TicketType.Bus] = 0;
            this.ticketCountByType[TicketType.Flight] = 0;
            this.ticketCountByType[TicketType.Train] = 0;
        }

        public string FindTickets(string departureTown, string arrivalTown)
        {
            string fromToKey = CreateFromToKey(departureTown, arrivalTown);
            if (this.ticketsFromTo.ContainsKey(fromToKey))
            {
                var ticketsFound = this.ticketsFromTo[fromToKey];
                string ticketsResult = FormatTicketsForPrinting(ticketsFound);

                return ticketsResult;
            }

            return Constants.NoMatchedTicketMessage;
        }

        public string FindTicketsInInterval(DateTime departureDateTime, DateTime arrivalDateTime)
        {
            var ticketsFound = this.ticketsByDate.Range(departureDateTime, true, arrivalDateTime, true).Values;
            if (ticketsFound.Count > 0)
            {
                var ticketsAsString = FormatTicketsForPrinting(ticketsFound);

                return ticketsAsString;
            }

            return Constants.NoMatchedTicketMessage;
        }

        public int GetTicketsCount(TicketType ticketType)
        {
            return this.ticketCountByType[ticketType];
        }

        public string AddAirTicket(string flightNumber, string departureAirport, string arrivalAirport, string airlineCompany, DateTime departureDateAndTime, decimal price)
        {
            var ticket = new AirTicket(
                flightNumber, departureAirport, arrivalAirport, airlineCompany, departureDateAndTime, price);
            var result = this.AddTicket(ticket);

            return result;
        }

        public string DeleteAirTicket(string flightNumber)
        {
            Ticket ticket = new AirTicket(flightNumber);
            string uniqueKey = ticket.TicketKey;
            var result = this.DeleteTicket(TicketType.Flight, uniqueKey);
            
            return result;
        }

        public string AddTrainTicket(string departureTown, string arrivalTown, DateTime departureDateTime, decimal regularPrice, decimal studentPrice)
        {
            var ticket = new TrainTicket(departureTown, arrivalTown, departureDateTime, regularPrice, studentPrice);
            var result = this.AddTicket(ticket);
           
            return result;
        }

        public string DeleteTrainTicket(string departureTown, string arrivalTown, DateTime departureDateTime)
        {
            var ticket = new TrainTicket(departureTown, arrivalTown, departureDateTime);
            string uniqueKey = ticket.TicketKey;
            var result = this.DeleteTicket(TicketType.Train, uniqueKey);
           
            return result;
        }

        public string AddBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateAndTime, decimal price)
        {
            var ticket = new BusTicket(departureTown, arrivalTown, travelCompany, departureDateAndTime, price);
            var result = this.AddTicket(ticket);
            
            return result;
        }

        public string DeleteBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateTime)
        {
            var ticket = new BusTicket(departureTown, arrivalTown, travelCompany, departureDateTime);
            string uniqueKey = ticket.TicketKey;
            var result = this.DeleteTicket(TicketType.Bus, uniqueKey);
            
            return result;
        }

        private static string FormatTicketsForPrinting(ICollection<Ticket> tickets)
        {
            string result = string.Join(" ", tickets.OrderBy(t => t));

            return result;
        }

        private static string CreateFromToKey(string from, string to)
        {
            return string.Format("{0};{1}", from, to);
        }

        private string DeleteTicket(TicketType ticketType, string uniqueKey)
        {
            if (this.ticketsByKey.ContainsKey(uniqueKey))
            {
                Ticket ticketToDelete = this.ticketsByKey[uniqueKey];
                this.ticketsByKey.Remove(uniqueKey);
                string fromToKey = CreateFromToKey(ticketToDelete.DepartureTown, ticketToDelete.ArrivalTown);
                this.ticketsFromTo.Remove(fromToKey, ticketToDelete);
                this.ticketsByDate.Remove(ticketToDelete.DepartureDateAndTime, ticketToDelete);
                this.ticketCountByType[ticketToDelete.Type]--;

                return ticketToDelete.Type + Constants.DeletedMessage;
            }

            return ticketType + Constants.DoesNotExistMessage;
        }

        private string AddTicket(Ticket ticket)
        {
            var key = ticket.TicketKey;
            if (this.ticketsByKey.ContainsKey(key))
            {
                return Constants.DuplicatedMessage + ticket.Type.ToString().ToLower();
            }

            this.ticketsByKey.Add(key, ticket);
            var fromToKey = CreateFromToKey(ticket.DepartureTown, ticket.ArrivalTown);
            this.ticketsFromTo.Add(fromToKey, ticket);
            this.ticketsByDate.Add(ticket.DepartureDateAndTime, ticket);
            this.ticketCountByType[ticket.Type]++;

            return ticket.Type + Constants.CreatedMessage;
        }
    }
}