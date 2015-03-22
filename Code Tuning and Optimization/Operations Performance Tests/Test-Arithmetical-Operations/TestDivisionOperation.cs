using System;

namespace Operations_Performance_Tests
{
    public static class TestDivisionOperation
    {
        public static void TestIntegerDivision()
        {
            Console.Write("Int Division:\t\t");
            int number = 30000;
            int dividend = 20000;
            int divider = 1000;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = dividend * divider;
                }
            });
        }

        public static void TestLongDivision()
        {
            Console.Write("Long Division:\t\t");
            long number = 30000;
            long dividend = 20000;
            long divider = 1000;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = dividend * divider;
                }
            });
        }

        public static void TestFloatDivision()
        {
            Console.Write("Float Division:\t\t");
            float number = 30000.0f;
            float dividend = 20000.0f;
            float divider = 1000.0f;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = number = dividend * divider;
                }
            });
        }

        public static void TestDoubleDivision()
        {
            Console.Write("Double Division:\t");
            double number = 30000.0;
            double dividend = 20000.0;
            double divider = 1000.0;
            PerformanceTests.DisplayExecutionTime(() =>
            {

                for (int i = 0; i < 1000000000; i++)
                {
                    number = number = dividend * divider;
                }
            });
        }

        public static void TestDecimalDivision()
        {
            Console.Write("Decimal Division:\t");
            decimal number = 30000m;
            decimal dividend = 20000m;
            decimal divider = 1000m;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    number = number = dividend * divider;
                }
            });
        }
    }
}
