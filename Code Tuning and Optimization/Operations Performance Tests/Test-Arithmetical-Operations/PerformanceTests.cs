namespace Operations_Performance_Tests
{
    using System;
    using System.Diagnostics;

    public class PerformanceTests
    {
        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        static void Main()
        {
            Console.WriteLine("\tTest Addition:");
            TestAdditionOperation.TestIntegerAddition();
            TestAdditionOperation.TestLongAddition();
            TestAdditionOperation.TestFloatAddition();
            TestAdditionOperation.TestDoubleAddition();
            TestAdditionOperation.TestDecimalAddition();

            Console.WriteLine("\n\tTest Subtraction:");
            TestSubtractionOperation.TestIntegerSubtraction();
            TestSubtractionOperation.TestLongSubtraction();
            TestSubtractionOperation.TestFloatSubtraction();
            TestSubtractionOperation.TestDoubleSubtraction();
            TestSubtractionOperation.TestDecimalSubtraction();

            Console.WriteLine("\n\tTest Incrementation:");
            TestIncrementationOperation.TestIntegerIncrementation();
            TestIncrementationOperation.TestLongIncrementation();
            TestIncrementationOperation.TestFloatIncrementation();
            TestIncrementationOperation.TestDoubleIncrementation();
            TestIncrementationOperation.TestDecimalIncrementation();

            Console.WriteLine("\n\tTest Multiplication:");
            TestMultiplicationOperation.TestIntegerMultiplication();
            TestMultiplicationOperation.TestLongMultiplication();
            TestMultiplicationOperation.TestFloatMultiplication();
            TestMultiplicationOperation.TestDoubleMultiplication();
            TestMultiplicationOperation.TestDecimalMultiplication();

            Console.WriteLine("\n\tTest Division:");
            TestDivisionOperation.TestIntegerDivision();
            TestDivisionOperation.TestLongDivision();
            TestDivisionOperation.TestFloatDivision();
            TestDivisionOperation.TestDoubleDivision();
            TestDivisionOperation.TestDecimalDivision();
        }
    }
}
