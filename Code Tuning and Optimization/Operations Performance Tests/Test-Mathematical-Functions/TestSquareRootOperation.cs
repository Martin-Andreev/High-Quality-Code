namespace Test_Mathematical_Functions
{
    using System;

    public static class TestSquareRootOperation
    {
        public static void TestDoubleSquareRoot()
        {
            Console.Write("Double Square Root:\t\t");
            double number = 100;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Sqrt(number);
                }
            });
        }

        public static void TestFloatSquareRoot()
        {
            Console.Write("Float Square Root:\t\t");
            float number = 100.0f;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Sqrt(number);
                }
            });
        }

        public static void TestDecimalSquareRoot()
        {
            Console.Write("Decimal Square Root:\t\t");
            decimal number = 100m;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Sqrt((double)number);
                }
            });
        }
    }
}
