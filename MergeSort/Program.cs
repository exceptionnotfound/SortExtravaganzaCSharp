using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> unsorted = new List<int>();
            List<int> sorted;

            Random random = new Random(DateTime.Now.Millisecond);

            Console.WriteLine("Original array:");
            for (int i = 0; i < 21; i++)
            {
                unsorted.Add(random.Next(0, 100));
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();

            sorted = MergeSort(unsorted);

            Console.WriteLine("Sorted array: ");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
            Console.ReadLine();
        }

        //Uses recursion to break the collection into progressively smaller collections.
        //Eventually, each collection will have just one element.
        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int median = unsorted.Count / 2;
            for (int i = 0; i < median; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = median; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        //Method takes two sorted "sublists" (left and right) of original list and merges them into a new colletion
        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>(); //The new collection

            while (left.Any() || right.Any())
            {
                if (left.Any() && right.Any())
                {
                    if (left.First() <= right.First())  //Comparing the first element of each sublist to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Any())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Any())
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
