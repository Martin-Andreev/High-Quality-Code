using System.Linq;

namespace Ticket
{
    using System;
    using System.Globalization;
    using Contracts;

    public static class TicketOffice
    {
        private static ITicketRepository ticketRepository = new TicketRepository();

        private static DateTime ParseDateTime(string dateAndTime)
        {
            DateTime result = DateTime.ParseExact(dateAndTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            return result;
        }

        public static string ProcessCommand(string commandLine)
        {
            var firstSpaceIndex = commandLine.IndexOf(' ');

            if (firstSpaceIndex == -1)
            {
                return null;
            }

            var commandType = commandLine.Substring(0, firstSpaceIndex);
            string allParameters = commandLine.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            string commandResult;
            switch (commandType)
            {
                case "CreateBus":
                    commandResult = ProcessCreateBussCommand(parameters);
                    break;
                case "DeleteBus":
                    commandResult = ProcessDeleteBusTicketCommand(parameters);
                    break;
                case "CreateTrain":
                    commandResult = ProccessCreateTrainCommand(parameters);
                    break;
                case "DeleteTrain":
                    commandResult = ProcessDeleteTrainTicketCommand(parameters);
                    break;
                case "CreateFlight":
                    commandResult = ProcessCreateFlightCommand(parameters);
                    break;
                case "DeleteFlight":
                    commandResult = ProcessDeleteAirTicketCommand(parameters);
                    break;
                case "FindTickets":
                    commandResult = ProcessFindTicketsCommand(parameters);
                    break;
                case "FindByDates":
                    commandResult = ProcessFindTicketsInIntervalCommand(parameters);
                    break;
                default:
                    commandResult = Constants.NoMatchedTicketMessage;
                    break;
            }

            return commandResult;
        }

        private static string ProcessFindTicketsInIntervalCommand(string[] parameters)
        {
            DateTime startDate = ParseDateTime(parameters[0]);
            DateTime endTime = ParseDateTime(parameters[1]);
            string commandResult = ticketRepository.FindTicketsInInterval(startDate, endTime);

            return commandResult;
        }

        private static string ProcessFindTicketsCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            string commandResult = ticketRepository.FindTickets(departureTown, arrivalTown);

            return commandResult;
        }

        private static string ProcessDeleteTrainTicketCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            DateTime departureDateAndTime = ParseDateTime(parameters[2]);
            string commandResult = ticketRepository.DeleteTrainTicket(departureTown, arrivalTown, departureDateAndTime);

            return commandResult;
        }

        private static string ProccessCreateTrainCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            DateTime departureDateAndTime = ParseDateTime(parameters[2]);
            decimal regularPrice = decimal.Parse(parameters[3]);
            decimal studentPrice = decimal.Parse(parameters[4]);
            string commandResult = 
                ticketRepository.AddTrainTicket(departureTown, arrivalTown, departureDateAndTime, regularPrice, studentPrice);

            return commandResult;
        }

        private static string ProcessDeleteBusTicketCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            string travelCompany = parameters[2];
            DateTime departureDateAndTime = ParseDateTime(parameters[3]);
            string commandResult = 
                ticketRepository.DeleteBusTicket(departureTown, arrivalTown, travelCompany, departureDateAndTime);
            
            return commandResult;
        }

        private static string ProcessCreateBussCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            string travelCompany = parameters[2];
            DateTime departureDateAndTime = ParseDateTime(parameters[3]);
            decimal price = decimal.Parse(parameters[4]);
            string commandResult = 
                ticketRepository.AddBusTicket(departureTown, arrivalTown, travelCompany, departureDateAndTime, price);

            return commandResult;
        }

        private static string ProcessDeleteAirTicketCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string commandResult = ticketRepository.DeleteAirTicket(flightNumber);
            
            return commandResult;
        }

        private static string ProcessCreateFlightCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string departureAirport = parameters[1];
            string arrivalAirport = parameters[2];
            string airlineCompany = parameters[3];
            DateTime departureDateAndTime = ParseDateTime(parameters[4]);
            decimal price = decimal.Parse(parameters[5]);
            string commandResult = ticketRepository.AddAirTicket(
                flightNumber, 
                departureAirport,
                arrivalAirport, 
                airlineCompany,
                departureDateAndTime,
                price);

            return commandResult;
        }
    }
}