namespace Logger.Appenders
{
    using System;
    using System.Dynamic;
    using Enumerations;
    using Contracts;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; set; }

        public abstract void Append(string message, ReportLevel reportLevel, DateTime date);

        public ReportLevel Threshold
        {
            get; set;
        }
    }
}
