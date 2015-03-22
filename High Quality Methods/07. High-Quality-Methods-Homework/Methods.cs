using System;
using System.Linq;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    return "Invalid number";
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("There are no elements in the array!");
            }

            return elements.Max();
        }

        static void PrintNumberInFormat(object number, string format)
        {
            string outputFormat;
            switch (format)
            {
                case "f":
                    outputFormat = "{0:f2}";
                    break;
                case "%":
                    outputFormat = "{0:p0}";
                    break;
                case "r":
                    outputFormat = "{0,8}";
                    break;
                default:
                    throw new ArgumentException("Invalid format!");
            }

            Console.WriteLine(outputFormat, number);
        }


        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }


        public static bool ArePointsHorizontal(double x1, double y1, double x2, double y2)
        {
            if (y1.Equals(y2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ArePointsVertical(double x1, double y1, double x2, double y2)
        {
            if (x1.Equals(x2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintNumberInFormat(1.3, "f");
            PrintNumberInFormat(0.75, "%");
            PrintNumberInFormat(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + ArePointsHorizontal(1, 2.2, 3, 4.5));
            Console.WriteLine("Vertical? " + ArePointsVertical(1.44, 2.05, 1.44, 4.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
