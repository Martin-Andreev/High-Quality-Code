namespace Theatre
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> theatresRepository =
            new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (theatresRepository.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException(Constants.DuplicateTheatreMessage);
            }

            theatresRepository[theatreName] = new SortedSet<Performance>();
            Console.WriteLine(Constants.SuccessfullyAddedTheatreMessage);
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatresNames = theatresRepository.Keys;

            return theatresNames;
        }

        public void AddPerformance(string theatreName, string performance, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            if (!theatresRepository.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.TheatreDoesNotExistMessage);
            }

            var theatre = theatresRepository[theatreName];
            var performanceTime = dateAndTime + duration;
            if (HasOtherPerformancesDuringThisTime(theatre, dateAndTime, performanceTime))
            {
                throw new TimeDurationOverlapException(Constants.TimeDurationOverlapMessage);
            }

            Performance newPerformance = new Performance(theatreName, performance, dateAndTime, duration, price);
            theatre.Add(newPerformance);
            Console.WriteLine(Constants.SuccessfullyAddedPerformanceMessage);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.theatresRepository.Keys;
            var performances = new List<Performance>();
            foreach (var theatre in theatres)
            {
                var performance = this.theatresRepository[theatre];
                performances.AddRange(performance);
            }

            return performances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!theatresRepository.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException(Constants.TheatreDoesNotExistMessage);
            }

            var theatre = theatresRepository[theatreName];
            return theatre;
        }

        public static bool HasOtherPerformancesDuringThisTime(
            IEnumerable<Performance>performances, 
            DateTime currentPerformanceStartTime,
            DateTime currentPerformanceEndTime)
        {
            foreach (var performance in performances)
            {
                var startTime = performance.DateAndTime;
                var endTime = performance.DateAndTime + performance.Duration;
                var opervapping = 
                    (startTime <= currentPerformanceStartTime && currentPerformanceStartTime <= endTime) ||
                    (startTime <= currentPerformanceEndTime && currentPerformanceEndTime <= endTime) || 
                    (currentPerformanceStartTime <= startTime && startTime <= currentPerformanceEndTime) || 
                    (currentPerformanceStartTime <= endTime && endTime <= currentPerformanceEndTime);
                if (opervapping)
                {
                    return true;
                }
            }

            return false;
        }
    }
}