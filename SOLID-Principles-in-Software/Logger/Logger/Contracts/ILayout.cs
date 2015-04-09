namespace Logger.Contracts
{
    using System;
    using Enumerations;

    public interface ILayout
    {
        string Format(string message, ReportLevel reportLevel, DateTime date);
    }
}
