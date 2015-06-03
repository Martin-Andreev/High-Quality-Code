namespace Ticket.Models
{
    using System;
    using Enums;

    public abstract class Ticket : IComparable<Ticket>
    {
        internal Ticket(string departureTown, string arrivalTown, DateTime departureDateAndTime, decimal regularPrice)
        {
            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.DepartureDateAndTime = departureDateAndTime;
            this.RegularPrice = regularPrice;
        }

        public abstract TicketType Type { get; }

        public virtual string DepartureTown { get; set; }

        public virtual string ArrivalTown { get; set; }

        public virtual DateTime DepartureDateAndTime { get; set; }

        public virtual decimal RegularPrice { get; set; }

        public abstract string TicketKey { get; }

        public int CompareTo(Ticket otherTicket)
        {
            var comparisonResult = this.DepartureDateAndTime.CompareTo(otherTicket.DepartureDateAndTime);
            if (comparisonResult == 0)
            {
                comparisonResult = this.Type.CompareTo(otherTicket.Type);
            }

            if (comparisonResult == 0)
            {
                comparisonResult = this.RegularPrice.CompareTo(otherTicket.RegularPrice);
            }

            return comparisonResult;
        }

        public override string ToString()
        {
            var input = string.Format(
                "[{0}|{1}|{2:f2}]",
                this.DepartureDateAndTime.ToString("dd.MM.yyyy HH:mm"),
                this.Type.ToString().ToLower(),
                this.RegularPrice);

            return input;
        }
    }
}