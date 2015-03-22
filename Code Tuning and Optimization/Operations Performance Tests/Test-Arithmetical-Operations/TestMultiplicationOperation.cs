namespace Operations_Performance_Tests
{
    using System;

    public static class TestMultiplicationOperation
    {
        public static void TestIntegerMultiplication()
        {
            Console.Write("Int Multiplication:\t");
            int number = 10000;
            int firstМultiplier = 20000;
            int secondМultiplier = 30000;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstМultiplier * secondМultiplier;
                }
            });
        }

        public static void TestLongMultiplication()
        {
            Console.Write("Long Multiplication:\t");
            long number = 10000;
            long firstМultiplier = 20000;
            long secondМultiplier = 30000;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstМultiplier * secondМultiplier;
                }
            });
        }

        public static void TestFloatMultiplication()
        {
            Console.Write("Float Multiplication:\t");
            float number = 10000.0f;
            float firstМultiplier = 20000.0f;
            float secondМultiplier = 30000.0f;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstМultiplier * secondМultiplier;
                }
            });
        }

        public static void TestDoubleMultiplication()
        {
            Console.Write("Double Multiplication:\t");
            double number = 10000.0;
            double firstМultiplier = 20000.0;
            double secondМultiplier = 30000.0;
            PerformanceTests.DisplayExecutionTime(() =>
            {

                for (int i = 0; i < 1000000000; i++)
                {
                    number = firstМultiplier * secondМultiplier;
                }
            });
        }

        public static void TestDecimalMultiplication()
        {
            Console.Write("Decimal Multiplication:\t");
            decimal number = 10000m;
            decimal firstМultiplier = 20000m;
            decimal secondМultiplier = 30000m;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    number = firstМultiplier * secondМultiplier;
                }
            });
        }
    }
}
