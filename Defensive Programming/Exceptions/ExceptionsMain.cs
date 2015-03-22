using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsMain
{
    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException outOfRangeEx)
        {
            Console.WriteLine(outOfRangeEx.Message);
        }
        catch (ArgumentNullException nullEx)
        {
            Console.WriteLine(nullEx.Message);
        }

        CheckPrime(23);
        CheckPrime(33);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }

    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentNullException("Subsequence source cannot be null or empty");
        }

        if (startIndex < 0 || startIndex > arr.Length - 1)
        {
            throw new ArgumentOutOfRangeException("Subsequence startIndex must be greater than zero and smaller than array lenght");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("Subsequence count cannot be a negative number");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new ArgumentNullException("str", "ExtractEnding source cannot be null or empty");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "ExtractEnding count cannot be a negative number");
        }

        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("count", "ExtractEnding count must be smaller than str lenght");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("number", "CheckPrime number cannot be a negative number.");
        }

        bool isPrime = true;

        if (number == 2 || number == 3)
        {
            isPrime = true;
        }
        else
        {
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number%divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }

        Console.WriteLine(isPrime ? "The number is prime!" : "The number is not prime!");
    }
}
