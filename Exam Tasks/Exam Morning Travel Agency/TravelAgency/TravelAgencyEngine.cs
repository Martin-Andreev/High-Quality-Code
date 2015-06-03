namespace TravelAgency
{
    using System;
    using System.Globalization;
    using Utilities;

    public class TravelAgencyEngine
    {
        private readonly char[] semicolonSymbol = new[] { ';' };
     
        public TravelAgencyEngine(ConsoleOperator consoleOperator)
        {
            this.ConsoleOpearator = consoleOperator;
            this.TravelAgencyRepository = new TravelAgencyRepository();
        }

        public ConsoleOperator ConsoleOpearator { get; set; }

        private TravelAgencyRepository TravelAgencyRepository { get; set; }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.ConsoleOpearator.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                if (string.IsNullOrEmpty(commandLine))
                {
                    continue;
                }

                var commandResult = this.ProcessCommand(commandLine);
                this.ConsoleOpearator.WriteLine(commandResult);
            }
        }

        private static DateTime ParseDateTime(string dateAndTime)
        {
            DateTime result = DateTime.ParseExact(dateAndTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            return result;
        }

        private string ProcessCommand(string line)
        {
            if (string.IsNullOrEmpty(line))
            {
                return null;
            }

            int firstSpaceIndex = line.IndexOf(' ');
            if (firstSpaceIndex == -1)
            {
                return TravelAgencyConstants.InvalidCommand;
            }

            string commandName = line.Substring(0, firstSpaceIndex);
            string allParameters = line.Substring(firstSpaceIndex + 1);
            string[] parameters = allParameters.Split(this.semicolonSymbol, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }

            string commandResult;
            switch (commandName)
            {
                case "AddAir":
                    commandResult = this.ProcessAddAirCommand(parameters);
                    break;
                case "DeleteAir":
                    string flightNumber = parameters[0];
                    commandResult = this.ProcessDeleteAirCommand(flightNumber);
                    break;
                case "AddTrain":
                    commandResult = this.ProcessAddTrainCommand(parameters);
                    break;
                case "DeleteTrain":
                    commandResult = this.ProcessDeleteTrainCommand(parameters);
                    break;
                case "AddBus":
                    commandResult = this.ProcessAddBussCommand(parameters);
                    break;
                case "DeleteBus":
                    commandResult = this.ProcessDeleteBusCommand(parameters);
                    break;
                case "FindTickets":
                    commandResult = this.ProcessFindTicketsCommand(parameters);
                    break;
                case "FindTicketsInInterval":
                    commandResult = this.ProcessfindTicketsInIntervalCommand(parameters);
                    break;
                default:
                    commandResult = TravelAgencyConstants.InvalidCommand;
                    break;
            }

            return commandResult;
        }

        private string ProcessfindTicketsInIntervalCommand(string[] parameters)
        {
            DateTime departureFromDateTime = ParseDateTime(parameters[0]);
            DateTime departureToDateTime = ParseDateTime(parameters[1]);

            string commandResult = 
                this.TravelAgencyRepository.FindTicketsInInterval(departureFromDateTime, departureToDateTime);

            return commandResult;
        }

        private string ProcessFindTicketsCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            string commandResult = this.TravelAgencyRepository.FindTickets(departureTown, arrivalTown);

            return commandResult;
        }

        private string ProcessDeleteBusCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            string travelCompany = parameters[2];
            DateTime departureDateTime = ParseDateTime(parameters[3]);

            string commandResult = this.TravelAgencyRepository.DeleteBusTicket(
                departureTown, 
                arrivalTown,
                travelCompany,
                departureDateTime);

            return commandResult;
        }

        private string ProcessAddBussCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            string travelCompany = parameters[2];
            DateTime departureDateTime = ParseDateTime(parameters[3]);
            decimal price = decimal.Parse(parameters[4]);
            string commandResult =
                this.TravelAgencyRepository.AddBusTicket(
                departureTown,
                arrivalTown, 
                travelCompany, 
                departureDateTime, 
                price);

            return commandResult;
        }

        private string ProcessDeleteTrainCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            DateTime departureDateTime = ParseDateTime(parameters[2]);

            string commandResult = this.TravelAgencyRepository.DeleteTrainTicket(departureTown, arrivalTown, departureDateTime);

            return commandResult;
        }

        private string ProcessAddTrainCommand(string[] parameters)
        {
            string departureTown = parameters[0];
            string arrivalTown = parameters[1];
            DateTime departureDateTime = ParseDateTime(parameters[2]);
            decimal price = decimal.Parse(parameters[3]);
            decimal studentPrice = decimal.Parse(parameters[4]);
            string commandResult =
                this.TravelAgencyRepository.AddTrainTicket(departureTown, arrivalTown, departureDateTime, price, studentPrice);

            return commandResult;
        }

        private string ProcessDeleteAirCommand(string flightNumber)
        {
            string commandResult = this.TravelAgencyRepository.DeleteAirTicket(flightNumber);

            return commandResult;
        }

        private string ProcessAddAirCommand(string[] parameters)
        {
            string flightNumber = parameters[0];
            string departureAirline = parameters[1];
            string arrivalAiriline = parameters[2];
            string airlineCompany = parameters[3];
            DateTime departureDateTime = ParseDateTime(parameters[4]);
            decimal price = decimal.Parse(parameters[5]);
            string commandResult =
                this.TravelAgencyRepository.AddAirTicket(
                flightNumber,
                departureAirline, 
                arrivalAiriline, 
                airlineCompany, 
                departureDateTime, 
                price);

            return commandResult;
        }
    }
}