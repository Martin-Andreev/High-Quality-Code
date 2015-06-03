namespace TravelAgency.Models
{
    using System;
    using System.Text;

    public abstract class Ticket : IComparable<Ticket>
    {
        protected Ticket(
            string departureTown, 
            string arrivalTown, 
            string company,
            DateTime dateAndTime, 
            decimal price)
        {
            this.DepartureTown = departureTown;
            this.ArrivalTown = arrivalTown;
            this.Company = company;
            this.DateAndTime = dateAndTime;
            this.Price = price;
        }

        public abstract TicketType Type { get; }

        public string DepartureTown { get; set; }
    
        public string ArrivalTown { get; set; }
    
        public string Company { get; set; }
    
        public DateTime DateAndTime { get; set; }

        public decimal Price { get; set; }

        public decimal SpecialPrice { get; set; }
    
        public abstract string UniqueTicketKey { get; }

        public string FromToKey
        {
            get
            {
                return CreateFromToKey(this.DepartureTown, this.ArrivalTown);
            }
        }

        public static string CreateFromToKey(string from, string to)
        {
            return string.Format("{0};{1}", from, to);
        }

        public int CompareTo(Ticket otherTicket)
        {
            var comparedTicket = this.DateAndTime.CompareTo(otherTicket.DateAndTime);
            if (comparedTicket == 0)
            {
                comparedTicket = this.Type.CompareTo(otherTicket.Type);
            }

            if (comparedTicket == 0)
            {
                comparedTicket = this.Price.CompareTo(otherTicket.Price);
            }

            return comparedTicket;
        }

        public override string ToString()
        {
            StringBuilder ticket = new StringBuilder();
            ticket.AppendFormat(
                "[{0}; {1}; {2:F2}]",
                this.DateAndTime.ToString("dd.MM.yyyy HH:mm"), 
                this.Type.ToString().ToLower(),
                this.Price);
            
            return ticket.ToString();
        }
    }
}