using SortExtravaganza.Common;
using System;

namespace BitonicMergeSort
{
    /// <summary>
    /// Bitonic merge sort only works with collections that are powers of 2.
    /// </summary>
    class BitonicMergeSort
    {
        static void Swap<T>(ref T leftHandSide, ref T rightHandSide)
        {
            T temp;
            temp = leftHandSide;
            leftHandSide = rightHandSide;
            rightHandSide = temp;
        }
        static void CompareAndSwap(int[] array, int i, int j, int direction)
        {
            int k;

            k = array[i] > array[j] ? 1 : 0;

            if (direction == k) //If the order the elements are currently in DOES NOT match the sort direction (array[i] > array[j])...
            {
                //...Swap the elements so they DO match the sort direction
                Swap(ref array[i], ref array[j]);
            }
        }

        //This method recursively sorts a bitonic sequence in ascending order,  
        //if dir = 1, and in descending order otherwise (means dir=0).  
        //The sequence to be sorted starts at index position low,  
        //the parameter count is the number of elements to be sorted.
        static void BitonicMerge(int[] array, int low, int count, int direction)
        {
            if (count > 1)
            {
                int k = count / 2;
                for (int i = low; i < low + k; i++)
                {
                    CompareAndSwap(array, i, i + k, direction);
                }
                BitonicMerge(array, low, k, direction);
                BitonicMerge(array, low + k, k, direction);
            }
        }

        //This function first produces a bitonic sequence by recursively  
        //sorting its two halves in opposite sorting directions, and then  
        //calls BitonicMerge to make them in the same direction
        static void BitonicSort(int[] array, int low, int count, int direction)
        {
            if (count > 1)
            {
                int k = count / 2;

                // sort left side in ascending order
                BitonicSort(array, low, k, 1);

                // sort right side in descending order
                BitonicSort(array, low + k, k, 0);

                //Merge entire sequence in ascending order
                BitonicMerge(array, low, count, direction);
            }
        }

        public static void Main()
        {
            int[] array = { 66, 98, 11, 43, 7, 28, 14, 49, 77, 61, 31, 12, 71, 93, 15, 2  };
            int length = array.Length;

            Console.WriteLine("Bitonic Merge Sort");

            CommonFunctions.PrintInitial(array);

            BitonicSort(array, 0 /*low value*/, length, 1); //1 is for sorting in ascending order

            CommonFunctions.PrintFinal(array);
            Console.ReadLine();
        }
    }
}
