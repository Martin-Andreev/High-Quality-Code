namespace Logger.Appenders
{
    using System;
    using Enumerations;
    using Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            if (this.Threshold <= reportLevel)
            {
                var formattedMessage = Layout.Format(message, reportLevel, date);
                Console.WriteLine(formattedMessage);
            }   
        }
    }
}
