namespace TravelAgency.Contracts
{
    using System;
    using Models;

    public interface ITicketCatalog
    {
        /// <summary>
        /// Adds an air ticket with the specified properties to the ticket database.
        /// </summary>
        /// <param name="flightNumber">The flight number of the ticket</param>
        /// <param name="departureAirline">The departure airline of the ticket</param>
        /// <param name="arrivalAiriline">The arrival airline of the ticket</param>
        /// <param name="airlineCompany">The airline company of the ticket</param>
        /// <param name="departureDateTime">The departure date and time of the ticket</param>
        /// <param name="price">The price of the ticket</param>
        /// <returns>Returns a success message ("Ticket added") if the ticket has been successfully added
        ///  and an error message ("Duplicate ticket") if the ticket already exists.</returns>
        string AddAirTicket(string flightNumber, string departureAirline, string arrivalAiriline, string airlineCompany, DateTime departureDateTime, decimal price);
        
        string DeleteAirTicket(string flightNumber);
        
        string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);
        
        string DeleteTrainTicket(string from, string to, DateTime dateTime);
        
        string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);
        
        /// <summary>
        /// Remove a bus ticket with the specified properties from the ticket database
        /// </summary>
        /// <param name="from">The departure town of the ticket</param>
        /// <param name="to">The arrival town of the ticket</param>
        /// <param name="travelCompany">The travel company of the ticket</param>
        /// <param name="dateTime">The departure date and time of the ticket</param>
        /// <returns>Returns a success message ("Ticket deleted") if the ticket has been successfully deleted
        ///  and an error message ("Ticket does not exist") if the ticket does not exist in the database.</returns>
        string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);
        
        /// <summary>
        /// Find tickets in specific date and time
        /// </summary>
        /// <param name="from">From when the departure starts</param>
        /// <param name="to">To when the departure starts</param>
        /// <returns>Returns all matching tickets on a single line, separated by spaces in format 
        /// [date and time; type; price] ordered by date and time(ascending), then by type(ascending)
        ///  and then by price(ascending). If no tickets are found returns error message ("Not found"). </returns>
        string FindTickets(string from, string to);

        string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);
        
        int GetTicketsCount(TicketType type);
    }
}