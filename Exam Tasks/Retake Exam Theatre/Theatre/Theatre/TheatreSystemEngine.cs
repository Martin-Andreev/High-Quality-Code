namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Linq;

    public static class TheatreSystemEngine
    {
        public static void ProcessCommand(string commandLine)
        {
            string[] allParameters = commandLine.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string parameters = string.Empty;
            if (allParameters.Count() > 1)
            {
                parameters = allParameters.Skip(1).ToArray()[0];    
            }
            
            string commandType = allParameters[0];
            try
            {
                switch (commandType)
                {
                    case "AddTheatre":
                        ProcessAddTheatreCommand(parameters);
                        break;
                    case "PrintAllTheatres":
                        ProcessPrintAllTheatresCommand();
                        break;
                    case "AddPerformance":
                        ProcessAddPerformanceCommand(parameters);
                        break;
                    case "PrintAllPerformances":
                        ProcessPrintAllPerformancesCommand();
                        break;
                    case "PrintPerformances":
                        ProcessPrintPerformancesCommand(parameters);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ProcessPrintPerformancesCommand(string theatreName)
        {
            CommandExecutor.ExecutePrintPerformancesCommand(theatreName);
        }

        private static void ProcessAddPerformanceCommand(string parameters)
        {
            string[] newPerformanceParameters = parameters.Split(new[] { ','}, StringSplitOptions.RemoveEmptyEntries);
            newPerformanceParameters = newPerformanceParameters.Select(p => p.Trim()).ToArray();
            string theatreName = newPerformanceParameters[0];
            string performanceTitle = newPerformanceParameters[1];
            DateTime startDateTime = ParseDateTime(newPerformanceParameters[2]);
            TimeSpan duration = TimeSpan.Parse(newPerformanceParameters[3]);
            decimal price= decimal.Parse(newPerformanceParameters[4], NumberStyles.Float);
            CommandExecutor.ExecuteAddPerformanceCommand(theatreName, performanceTitle, startDateTime, duration, price);
        }

        private static void ProcessPrintAllPerformancesCommand()
        {
            CommandExecutor.ExecutePrintAllPerformancesCommand();
        }

        private static void ProcessPrintAllTheatresCommand()
        {
            CommandExecutor.ExecutePrintAllTheatresCommand();
        }

        private static void ProcessAddTheatreCommand(string theatreName)
        {
            CommandExecutor.ExecuteAddTheatreCommand(theatreName);
        }

        private static DateTime ParseDateTime(string dateAndTime)
        {
            DateTime result = DateTime.ParseExact(dateAndTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);

            return result;
        }
    }
}