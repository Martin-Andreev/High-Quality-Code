namespace TravelAgency
{
    using System.Globalization;
    using System.Threading;
    using Utilities;

    public class TravelAgencyMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            ConsoleOperator consoleOperator = new ConsoleOperator();
            var engine = new TravelAgencyEngine(consoleOperator);
            engine.Run();
        }
    }
}