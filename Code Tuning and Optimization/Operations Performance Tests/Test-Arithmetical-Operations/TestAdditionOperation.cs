using System;
using System.Diagnostics;

namespace Operations_Performance_Tests
{
    public static class TestAdditionOperation
    {
        public static void TestIntegerAddition()
        {
            Console.Write("Int Addition:\t\t");
            int number = 10000000;
            int firstAddend = 20000000;
            int secondAddend = 30000000;
            PerformanceTests.DisplayExecutionTime(() =>
            {

                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstAddend + secondAddend;
                }
            });
        }

        public static void TestLongAddition()
        {
            Console.Write("Long Addition:\t\t");
            long number = 10000000;
            long firstAddend = 20000000;
            long secondAddend = 30000000;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstAddend + secondAddend;
                }
            });
        }

        public static void TestFloatAddition()
        {
            Console.Write("Float Addition:\t\t");
            float number = 10000000.0f;
            float firstAddend = 20000000.0f;
            float secondAddend = 30000000.0f;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstAddend + secondAddend;
                }
            });
        }

        public static void TestDoubleAddition()
        {
            Console.Write("Double Addition:\t");
            double number = 10000000.0;
            double firstAddend = 20000000.0;
            double secondAddend = 30000000.0;
            PerformanceTests.DisplayExecutionTime(() =>
            {

                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstAddend + secondAddend;
                }
            });
        }

        public static void TestDecimalAddition()
        {
            Console.Write("Decimal Addition:\t");
            decimal number = 10000000m;
            decimal firstAddend = 20000000m;
            decimal secondAddend = 30000000m;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    number = firstAddend + secondAddend;
                }
            });
        }
    }
}
