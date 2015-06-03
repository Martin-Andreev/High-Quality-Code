namespace Ticket
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class TicketOfficeMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                if (commandLine != string.Empty)
                {
                    commandLine = commandLine.Trim();
                    string commandResult = TicketOffice.ProcessCommand(commandLine);
                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}
