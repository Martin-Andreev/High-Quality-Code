using System;

namespace Operations_Performance_Tests
{
    class TestSubtractionOperation
    {
        public static void TestIntegerSubtraction()
        {
            Console.Write("Int Subtraction:\t");
            int number = 40000000;
            int firstSubtrahend = 20000000;
            int secondSubtrahend = 10000000;
            PerformanceTests.DisplayExecutionTime(() =>
            {

                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstSubtrahend + secondSubtrahend;
                }
            });
        }

        public static void TestLongSubtraction()
        {
            Console.Write("Long Subtraction:\t");
            long number = 40000000;
            long firstSubtrahend = 20000000;
            long secondSubtrahend = 10000000;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstSubtrahend + secondSubtrahend;
                }
            });
        }

        public static void TestFloatSubtraction()
        {
            Console.Write("Float Subtraction:\t");
            float number = 40000000.0f;
            float firstSubtrahend = 20000000.0f;
            float secondSubtrahend = 10000000.0f;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstSubtrahend + secondSubtrahend;
                }
            });
        }

        public static void TestDoubleSubtraction()
        {
            Console.Write("Double Subtraction:\t");
            double number = 40000000;
            double firstSubtrahend = 20000000;
            double secondSubtrahend = 10000000;
            PerformanceTests.DisplayExecutionTime(() =>
            {

                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstSubtrahend + secondSubtrahend;
                }
            });
        }

        public static void TestDecimalSubtraction()
        {
            Console.Write("Decimal Subtraction:\t");
            decimal number = 40000000m;
            decimal firstSubtrahend = 20000000m;
            decimal secondSubtrahend = 10000000m;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    number = firstSubtrahend + secondSubtrahend;
                }
            });
        }
    }
}
