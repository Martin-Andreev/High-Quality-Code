namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Contracts;
    using Enumerations;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout) : base(layout)
        {

        }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            if (this.Threshold <= reportLevel)
            {
                using (StreamWriter writer = new StreamWriter(this.File, true))
                {
                    var formattedMessage = Layout.Format(message, reportLevel, date);
                    writer.Write(formattedMessage);
                }
            }
        }

        public string File { get; set; }
    }
}
