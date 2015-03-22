using System.Collections.Generic;

namespace Test_Sorting_Algorithms
{
    using System;

    public static class TestSortingAlgorithm
    {
        public static void InsertionSort<T>(IList<T> collection) where T : IComparable<T>
        {
            Console.Write("Insertion sort for {0} with {1} elements:\t", typeof(T).Name, collection.Count);
            int counter, 
                index,
                listCount = collection.Count;
            List<T> innerList = new List<T>(collection);
            SortingAlgorithmTester.DisplayExecutionTime(() =>
            {
                for (counter = 1; counter < listCount; counter++)
                {
                    T value = innerList[counter];
                    index = counter - 1;
                    while ((index >= 0) && (innerList[index].CompareTo(value) > 0))
                    {
                        innerList[index + 1] = innerList[index];
                        index--;
                    }

                    innerList[index + 1] = value;
                }
            });
        }

        public static void SelectionSort<T>(IList<T> collection) where T : IComparable<T>
        {
            Console.Write("Selection sort for {0} with {1} elements:\t", typeof(T).Name, collection.Count);
            T temp;
            int counter,
                index,
                min,
                arrayCount = collection.Count;
            List<T> innerList = new List<T>(collection);
            SortingAlgorithmTester.DisplayExecutionTime(() =>
            {
                for (counter = 0; counter < arrayCount - 1; counter++)
                {
                    min = counter;
                    for (index = counter + 1; index < arrayCount; index++)
                    {
                        if (innerList[index].CompareTo(innerList[min]) < 0)
                        {
                            min = index;
                        }
                    }

                    temp = innerList[counter];
                    innerList[counter] = innerList[min];
                    innerList[min] = temp;
                }
            });
        }

        public static void Quicksort<T>(IList<T> collection, int left, int right) where T : IComparable
        {
            Console.Write("Quicksort for {0} with {1} elements:\t", typeof(T).Name, collection.Count);

            SortingAlgorithmTester.DisplayExecutionTime(() =>
            {
                GetQuicksortResult(collection, left, right);
            });
        }

        private static void GetQuicksortResult<T>(IList<T> collection, int left, int right) where T : IComparable
        {
            List<T> innerList = new List<T>(collection);
            int i = left,
                j = right;
            T pivot = innerList[(left + right) / 2];
            while (i <= j)
            {
                while (innerList[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (innerList[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = innerList[i];
                    innerList[i] = innerList[j];
                    innerList[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                GetQuicksortResult(innerList, left, j);
            }

            if (i < right)
            {
                GetQuicksortResult(innerList, i, right);
            }
        }
    }
}
