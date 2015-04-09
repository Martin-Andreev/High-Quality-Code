namespace Logger.Contracts
{
    using System;
    using Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; set; }

        void Append(string message, ReportLevel reportLevel, DateTime dateTime);

        ReportLevel Threshold { get; set; }
    }
}
