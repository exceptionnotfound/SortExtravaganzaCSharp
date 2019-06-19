using SortExtravaganza.Common;
using System;
namespace HeapSortDemo
{
    //HeapSort takes advantage of a heap data structure to sort an unsorted list.
    //It can be thought of as an improved version of selection.
    //It's improved because, instead of traversing the 
    //ALGORITHM:
    //1. Build a "max heap" out of the unsorted data (a heap with the largest value as the first node).
    //2. Swap the first element of the heap with the final element.  That element (now at final position) is considered sorted.
    //   In effect, this makes the largest element the last one in the considered range.
    //3. Decrease the range of considered elements (those still needing to be sorted) by 1.
    //4. Continue until the considered range of elements is 1.
    public class HeapSort
    {
        static void Sort(int[] array)
        {
            var length = array.Length;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, length, i);
            }
            for (int i = length - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);
            }
        }

        static void Heapify(int[] array, int length, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && array[left] > array[largest])
            {
                largest = left;
            }
            if (right < length && array[right] > array[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Heapify(array, length, largest);
            }
        }
        public static void Main()
        {
            int[] arr = { 74, 19, 24, 5, 8, 79, 42, 15, 20, 53, 11 };
            Console.WriteLine("Heap Sort");

            CommonFunctions.PrintInitial(arr);

            Sort(arr);

            CommonFunctions.PrintFinal(arr);

            Console.ReadKey();
        }
    }
}