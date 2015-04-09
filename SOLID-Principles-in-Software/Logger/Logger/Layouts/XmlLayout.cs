namespace Logger.Layouts
{
    using System;
    using Contracts;
    using Enumerations;

    public class XmlLayout : ILayout
    {
        private const string XmlFormat = "<log>\n" +
                                         "\t<date>{0}</date>\n" +
                                         "\t<level>{1}</level>\n" +
                                         "\t<message>{2}</message>\n" +
                                         "</log>";

        public string Format(string message, ReportLevel reportLevel, DateTime date)
        {
            return string.Format(XmlFormat, date, reportLevel, message);
        }
    }
}
