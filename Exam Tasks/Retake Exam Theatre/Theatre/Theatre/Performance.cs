using System;

namespace Theatre
{
    public class Performance : IComparable<Performance>
    {
        public Performance(string theatre, string theatrePerformance, DateTime dateAndTime, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.TheatrePerformance = theatrePerformance;
            this.DateAndTime = dateAndTime;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre { get; set; }

        public string TheatrePerformance { get; set; }

        public DateTime DateAndTime { get; set; }

        public TimeSpan Duration { get; private set; }

        public decimal Price { get; set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            var comparedPerformance = DateAndTime.CompareTo(otherPerformance.DateAndTime);
            return comparedPerformance;
        }

        public override string ToString()
        {
            var result = string.Format(
                "({0}, {1}, {2})",
                this.TheatrePerformance,
                this.Theatre,
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm"));

            return result;
        }
    }
}