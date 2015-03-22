namespace Test_Mathematical_Functions
{
    using System;

    public static class TestSinusOperation
    {
        public static void TestDoubleSinus()
        {
            Console.Write("Double Sinus:\t\t\t");
            double number = 100;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Sin(number);
                }
            });
        }

        public static void TestFloatSinus()
        {
            Console.Write("Float Sinus:\t\t\t");
            float number = 100.0f;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Sin(number);
                }
            });
        }

        public static void TestDecimalSinus()
        {
            Console.Write("Decimal Sinus:\t\t\t");
            decimal number = 100m;
            MathematicalFunctionsTester.DisplayExecutionTime(() =>
            {
                for (int i = 0; i < 100000000; i++)
                {
                    Math.Sin((double)number);
                }
            });
        }
    }
}
