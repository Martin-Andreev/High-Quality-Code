namespace Test_Mathematical_Functions
{
    using System;

    public class TestNaturalLogarithmOperation
    {
        public static void TestDoubleNaturalLogarithm()
        {
            Console.Write("Double Natural Logarithm:\t");
            double number = 100;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Log(number);
                }
            });
        }

        public static void TestFloatNaturalLogarithm()
        {
            Console.Write("Float Natural Logarithm:\t");
            float number = 100.0f;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Log(number);
                }
            });
        }

        public static void TestDecimalNaturalLogarithm()
        {
            Console.Write("Decimal Natural Logarithm:\t");
            decimal number = 100m;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Log((double)number);
                }
            });
        }
    }
}
