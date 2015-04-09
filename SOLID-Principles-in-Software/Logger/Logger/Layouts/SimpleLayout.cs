namespace Logger.Layouts
{
    using System;
    using Contracts;
    using Enumerations;

    public class SimpleLayout : ILayout
    {
        private const string LayoutFormat = "{0} - {1} - {2}";
        
        public string Format(string message, ReportLevel reportLevel, DateTime date)
        {
            return string.Format(LayoutFormat, date, reportLevel, message);
        }
    }
}
