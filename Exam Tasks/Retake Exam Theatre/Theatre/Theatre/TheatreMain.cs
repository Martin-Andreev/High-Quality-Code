namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class TheatreMain
    {
        protected static void Main()
        {
            string a = "";
            if (string.IsNullOrEmpty(a))
            {
                Console.WriteLine("da");
            }

            return;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    return;
                }

                if (commandLine != string.Empty)
                {
                    commandLine = commandLine.Trim();
                    TheatreSystemEngine.ProcessCommand(commandLine);
                }
            }
        }
    }
}