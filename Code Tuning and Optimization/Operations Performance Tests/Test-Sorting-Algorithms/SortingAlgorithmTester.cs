using System.Collections.Generic;

namespace Test_Sorting_Algorithms
{
    using System;
    using System.Diagnostics;

    public class SortingAlgorithmTester
    {
        public static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void Main()
        {
            List<int> intNumbers = GetValues.GenerateRandomIntegerNumbers(30000);
            List<double> doubleNumbers = GetValues.GenerateRandomDoubleNumbers(30000);
            List<string> letters = GetValues.GenerateRandomStrings(30000);

            Console.WriteLine("\tSorting collection with random integer numbers:");
            TestSortingAlgorithm.Quicksort(intNumbers, 0, intNumbers.Count - 1);
            TestSortingAlgorithm.InsertionSort(intNumbers);
            TestSortingAlgorithm.SelectionSort(intNumbers);
            TestSortingAlgorithm.SelectionSort(letters);

            Console.WriteLine("\n\tSorting collection with random double numbers:");
            TestSortingAlgorithm.Quicksort(doubleNumbers, 0, doubleNumbers.Count - 1);
            TestSortingAlgorithm.InsertionSort(doubleNumbers);
            TestSortingAlgorithm.SelectionSort(doubleNumbers);

            Console.WriteLine("\n\tSorting collection with random strings:");
            TestSortingAlgorithm.Quicksort(letters, 0, letters.Count - 1);
            TestSortingAlgorithm.InsertionSort(letters);
            TestSortingAlgorithm.SelectionSort(letters);

            List<int> sortedIntNumbers = GetValues.GenerateSortedIntegerNumbers(30000);
            List<double> sortedDoubleNumbers = GetValues.GenerateSortedDoubleNumbers(30000);
            List<string> sortedLetters = GetValues.GenerateSortedStrings(26);

            Console.WriteLine("\n\tSorting sorted collection with integer numbers:");
            TestSortingAlgorithm.Quicksort(sortedIntNumbers, 0, sortedIntNumbers.Count - 1);
            TestSortingAlgorithm.InsertionSort(sortedIntNumbers);
            TestSortingAlgorithm.SelectionSort(sortedIntNumbers);

            Console.WriteLine("\n\tSorting sorted collection with double numbers:");
            TestSortingAlgorithm.Quicksort(sortedDoubleNumbers, 0, sortedDoubleNumbers.Count - 1);
            TestSortingAlgorithm.InsertionSort(sortedDoubleNumbers);
            TestSortingAlgorithm.SelectionSort(sortedDoubleNumbers);

            Console.WriteLine("\n\tSorting collection with sorted strings:");
            TestSortingAlgorithm.Quicksort(sortedLetters, 0, sortedLetters.Count - 1);
            TestSortingAlgorithm.InsertionSort(sortedLetters);
            TestSortingAlgorithm.SelectionSort(sortedLetters);

            List<int> reversedSortedIntNumbers = GetValues.GenerateReversedSortedIntegerNumbers(30000);
            List<double> reversedSortedDoubleNumbers = GetValues.GenerateReversedSortedDoubleNumbers(30000);
            List<string> reversedSortedLetters = GetValues.GenerateSortedStrings(6);

            Console.WriteLine("\n\tSorting reversed sorted collection with integer numbers:");
            TestSortingAlgorithm.Quicksort(reversedSortedIntNumbers, 0, reversedSortedIntNumbers.Count - 1);
            TestSortingAlgorithm.InsertionSort(reversedSortedIntNumbers);
            TestSortingAlgorithm.SelectionSort(reversedSortedIntNumbers);

            Console.WriteLine("\n\tSorting sorted collection with double numbers:");
            TestSortingAlgorithm.Quicksort(reversedSortedDoubleNumbers, 0, reversedSortedDoubleNumbers.Count - 1);
            TestSortingAlgorithm.InsertionSort(reversedSortedDoubleNumbers);
            TestSortingAlgorithm.SelectionSort(reversedSortedDoubleNumbers);

            Console.WriteLine("\n\tSorting collection with reversed sorted strings:");
            TestSortingAlgorithm.Quicksort(reversedSortedLetters, 0, reversedSortedLetters.Count - 1);
            TestSortingAlgorithm.InsertionSort(reversedSortedLetters);
            TestSortingAlgorithm.SelectionSort(reversedSortedLetters);
        }
    }
}
