namespace Operations_Performance_Tests
{
    using System;

    public static class TestIncrementationOperation
    {
        public static void TestIntegerIncrementation()
        {
            Console.Write("Int Incrementation:\t");
            int number = 1;
            int addend = 3;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = number + addend;
                }
            });
        }

        public static void TestLongIncrementation()
        {
            Console.Write("Long Incrementation:\t");
            long number = 1;
            long addend = 3;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = number + addend;
                }
            });
        }

        public static void TestFloatIncrementation()
        {
            Console.Write("Float Incrementation:\t");
            float number = 1.0f;
            float addend = 3.0f;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 1000000000; i++)
                {
                    number = number + addend;
                }
            });
        }

        public static void TestDoubleIncrementation()
        {
            Console.Write("Double Incrementation:\t");
            double number = 1.0;
            double addend = 3.0;
            PerformanceTests.DisplayExecutionTime(() =>
            {

                for (int i = 0; i < 1000000000; i++)
                {
                    number = number + addend;
                }
            });
        }

        public static void TestDecimalIncrementation()
        {
            Console.Write("Decimal Incrementation:\t");
            decimal number = 1m;
            decimal addend = 3m;
            PerformanceTests.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    number = number + addend;
                }
            });
        }
    }
}
