namespace Logger.Logger
{
    using System;
    using System.Collections.Generic;
    using Enumerations;

    using Contracts;

    public class Logger : ILogger
    {
        public IList<IAppender> Appenders { get; private set; }

        public Logger(params IAppender[] appender)
        {
            this.Appenders = new List<IAppender>(appender);
        }

        public void Info(string msg)
        {
            this.Log(msg, ReportLevel.Info);
        }

        public void Warn(string msg)
        {
            this.Log(msg, ReportLevel.Warning);
        }

        public void Error(string msg)
        {
            this.Log(msg, ReportLevel.Error);
        }

        public void Critical(string msg)
        {
            this.Log(msg, ReportLevel.Critical);
        }

        public void Fatal(string msg)
        {
            this.Log(msg, ReportLevel.Fatal);
        }

        private void Log(string msg, ReportLevel reportLevel)
        {
            foreach (var appender in this.Appenders)
            {
                var date = DateTime.Now;
                appender.Append(msg, reportLevel, date);
            }
        }
    }
}
