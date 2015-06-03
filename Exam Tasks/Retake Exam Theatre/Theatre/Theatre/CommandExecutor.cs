namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public static class CommandExecutor
    {
        private static IPerformanceDatabase theatresDatabase = new PerformanceDatabase();
        
        public static void ExecuteAddTheatreCommand(string theatreName)
        {
            theatresDatabase.AddTheatre(theatreName);
        }

        public static void ExecuteAddPerformanceCommand(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            theatresDatabase.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
        }

        public static void ExecutePrintAllTheatresCommand()
        {
            var theatresNames = theatresDatabase.ListTheatres();
            if (theatresNames.Any())
            {
                string theatreResult = FormatTheatresForPrinting(theatresNames);
                PrintOutput(theatreResult);

            }
            else
            {
                Console.WriteLine(Constants.NoTheatresMessage);
            }
        }

        public static void ExecutePrintAllPerformancesCommand()
        {
            var performances = theatresDatabase.ListAllPerformances().ToList();
            if (performances.Any())
            {
                string performancesResult = FormatAllPerformancesForPrinting(performances);
                PrintOutput(performancesResult);
            }
            else
            {
                Console.WriteLine(Constants.NoPerformancesMessage);   
            }
        }
        
        public static void ExecutePrintPerformancesCommand(string theatreName)
        {
            var performances = theatresDatabase.ListPerformances(theatreName);
            if (performances.Any())
            {
                string performancesResult = FormatTheatrePerformancesForPrinting(performances);
                PrintOutput(performancesResult);
            }
            else
            {
                Console.WriteLine(Constants.NoPerformancesMessage);
            }
        }

        private static void PrintOutput(string output)
        {
            Console.WriteLine(output);
        }

        private static string FormatTheatrePerformancesForPrinting(IEnumerable<Performance> performances)
        {
            var result = string.Join(
                ", ",
                performances
                .OrderBy(p => p.DateAndTime)
                .Select(p =>
                {
                    string performanceDate = p.DateAndTime.ToString("dd.MM.yyyy HH:mm");
                    return string.Format("({0}, {1})", p.TheatrePerformance, performanceDate);
                }));

            return result;
        }

        private static string FormatAllPerformancesForPrinting(List<Performance> performances)
        {
            string result = string.Join(
                ", ",
                performances
                .OrderBy(p => p.Theatre)
                .ThenBy(p => p.DateAndTime)
                .Select(p => p.ToString()));

            return result;
        }

        private static string FormatTheatresForPrinting(IEnumerable<string> theatres)
        {
            string result = string.Join(", ", theatres.OrderBy(t => t));

            return result;
        }
    }
}