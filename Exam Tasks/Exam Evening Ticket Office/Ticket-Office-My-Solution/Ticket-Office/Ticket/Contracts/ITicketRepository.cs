namespace Ticket.Contracts
{
    using System;
    using Enums;

    // TODO: document this interface
    public interface ITicketRepository
    {
        /// <summary>
        /// Adds an air ticket with the specified properties to the ticket database.
        /// </summary>
        /// <param name="flightNumber">The flight number of the ticket</param>
        /// <param name="departureAirport">The departure airport of the ticket</param>
        /// <param name="arrivalAirport">The arrival airport of the ticket</param>
        /// <param name="airlineCompany">The airline company of the ticket</param>
        /// <param name="departureDateAndTime">The departure date and time of the ticket</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>Returns a success message ("Ticket added") if the ticket has been added successfully added,
        ///  and an error message ("Duplicate ticket") if the ticket already exists.</returns>
        string AddAirTicket(string flightNumber, string departureAirport, string arrivalAirport, string airlineCompany, DateTime departureDateAndTime, decimal price);
        
        string DeleteAirTicket(string flightNumber);
    
        string AddTrainTicket(string departureTown, string arrivalTown, DateTime departureDateTime, decimal regularPrice, decimal studentPrice);
    
        string DeleteTrainTicket(string departureTown, string arrivalTown, DateTime departureDateTime);
    
        string AddBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateAndTime, decimal price);

        // TODO: document this method
        string DeleteBusTicket(string departureTown, string arrivalTown, string travelCompany, DateTime departureDateTime);

        // TODO: document this method
        string FindTickets(string departureTown, string arrivalTown);

        // TODO: document this method
        string FindTicketsInInterval(DateTime departureDateTime, DateTime arrivalDateTime);
    
        int GetTicketsCount(TicketType ticketType);
    }
}