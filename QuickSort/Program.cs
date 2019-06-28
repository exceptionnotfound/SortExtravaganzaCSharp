using SortExtravaganza.Common;
using System;

namespace QuickSort
{
//QuickSort is an efficient sorting algorithm that divides the collection of numbers
//into progressively smaller "partitions" within the collection and sorts those partitions
//in place.  The result is a fully sorted collection.
//ALGORITHM:
//1. Select a pivot point (implementation below selects the last value).
//2. Reorder the collection so that all values less than the pivot are before that pivot, and all values
//   greater than the pivot are after the pivot.
//   After this partitioning, the pivot element is in its final position.
//3. Recursively do this partitioning on the "less than pivot" set and the "greater than pivot" set.
//   Continue recursively applying this algorithm until the set is sorted.
class QuickSort
{
    static int Partition(int[] array, int low,
                                    int high)
    {
        //1. Select a pivot point.
        int pivot = array[high];

        int lowIndex = (low - 1);

        //2. Reorder the collection.
        for (int j = low; j < high; j++)
        {
            if (array[j] <= pivot)
            {
                lowIndex++;

                int temp = array[lowIndex];
                array[lowIndex] = array[j];
                array[j] = temp;
            }
        }

        int temp1 = array[lowIndex + 1];
        array[lowIndex + 1] = array[high];
        array[high] = temp1;

        return lowIndex + 1;
    }

    static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(array, low, high);

            //3. Recursively continue sorting the array
            Sort(array, low, partitionIndex - 1);
            Sort(array, partitionIndex + 1, high);
        }
    }

    public static void Main()
    {
        int[] array = { 72, 12, 6, 33, 81, 97, 37, 59, 52, 1, 20 };
        int length = array.Length;

        Console.WriteLine("QuickSort");
        CommonFunctions.PrintInitial(array);
        Sort(array, 0, length - 1);

        CommonFunctions.PrintFinal(array);

        Console.ReadKey();
    }
}
}
