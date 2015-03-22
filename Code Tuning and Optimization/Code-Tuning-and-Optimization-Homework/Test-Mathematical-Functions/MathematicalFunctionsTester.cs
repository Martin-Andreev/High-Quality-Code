namespace Test_Mathematical_Functions
{
    using System;
    using System.Diagnostics;

    public class MathematicalFunctionsTester
    {
        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void Main()
        {
            Console.WriteLine("\tTest Square Root:");
            TestSquareRootOperation.TestFloatSquareRoot();
            TestSquareRootOperation.TestDoubleSquareRoot();
            TestSquareRootOperation.TestDecimalSquareRoot();

            Console.WriteLine("\n\tTest Natural Logarithm:");
            TestNaturalLogarithmOperation.TestFloatNaturalLogarithm();
            TestNaturalLogarithmOperation.TestDoubleNaturalLogarithm();
            TestNaturalLogarithmOperation.TestDecimalNaturalLogarithm();

            Console.WriteLine("\n\tTest Sinus:");
            TestSinusOperation.TestFloatSinus();
            TestSinusOperation.TestDoubleSinus();
            TestSinusOperation.TestDecimalSinus();
        }
    }
}
