namespace TravelAgency.Utilities
{
    using System;
    using Contracts;

    public class ConsoleOperator : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
