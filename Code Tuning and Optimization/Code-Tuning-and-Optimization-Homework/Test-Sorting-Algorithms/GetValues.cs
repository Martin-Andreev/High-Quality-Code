using System;
using System.Collections.Generic;

namespace Test_Sorting_Algorithms
{
    public static class GetValues
    {
        private static string[] alphabet =
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
            "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };

        public static List<int> GenerateRandomIntegerNumbers(int count)
        {
            Random numberGenerator = new Random();
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(numberGenerator.Next(0, count));
            }

            return numbers;
        }

        public static List<double> GenerateRandomDoubleNumbers(int count)
        {
            Random numberGenerator = new Random();
            List<double> numbers = new List<double>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(numberGenerator.Next(0, count));
            }

            return numbers;
        }

        public static List<string> GenerateRandomStrings(int count)
        {
            Random numberGenerator = new Random();
            List<string> lettersCollection = new List<string>();
            for (int i = 0; i < count; i++)
            {
                lettersCollection.Add(alphabet[numberGenerator.Next(0, alphabet.Length - 1)]);
            }

            return lettersCollection;
        }

        public static List<int> GenerateSortedIntegerNumbers(int count)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        public static List<double> GenerateSortedDoubleNumbers(int count)
        {
            List<double> numbers = new List<double>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        public static List<string> GenerateSortedStrings(int count)
        {
            Random numberGenerator = new Random();
            List<string> lettersCollection = new List<string>();
            for (int i = 0; i < count; i++)
            {
                lettersCollection.Add(alphabet[numberGenerator.Next(0, alphabet.Length - 1)]);
            }

            return lettersCollection;
        }

        public static List<int> GenerateReversedSortedIntegerNumbers(int count)
        {
            List<int> numbers = new List<int>();
            for (int i = count; i > 0; i--)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        public static List<double> GenerateReversedSortedDoubleNumbers(int count)
        {
            List<double> numbers = new List<double>();
            for (int i = count; i > 0; i--)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        public static List<string> GenerateReversedSortedStrings(int count)
        {
            Random numberGenerator = new Random();
            List<string> lettersCollection = new List<string>();
            for (int i = count; i > 0; i--)
            {
                lettersCollection.Add(alphabet[numberGenerator.Next(0, alphabet.Length - 1)]);
            }

            return lettersCollection;
        }
    }
}
