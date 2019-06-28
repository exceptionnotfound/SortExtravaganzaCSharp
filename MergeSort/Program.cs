using SortExtravaganza.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
class MergeSort
{
    static void Main(string[] args)
    {
        List<int> unsorted = new List<int>() { 42, 13, 86, 9, 10, 55, 71 };
        List<int> sorted;

        Random random = new Random(DateTime.Now.Millisecond);

        Console.WriteLine("Merge Sort");

        CommonFunctions.PrintInitial(unsorted);

        sorted = Sort(unsorted);

        CommonFunctions.PrintFinal(sorted);
        Console.ReadLine();
    }

    //Uses recursion to break the collection into progressively smaller collections.
    //Eventually, each collection will have just one element.
    private static List<int> Sort(List<int> unsorted)
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

        left = Sort(left);
        right = Sort(right);
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
