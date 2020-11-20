using SortExtravaganza.Common;
using System;

namespace OddEvenSort
{
    //Odd Even Sort is a variation on Bubble Sort.  On each traversal of the collection,
    //the algorithm compares the values next to each other.  On the first traversal, it will compare
    //the values in odd-numbered positions against the next-highest position.  On the second traversal,
    //it will compare values in even numbered positions against their next-higher position.  
    class OddEvenSort
    {
        public static void Sort(int[] array, int length)
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                //Swap i and i+1 if they are out of order, for i == odd numbers
                for (int i = 1; i <= length - 2; i = i + 2)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSorted = false;
                    }
                }

                //Swap i and i+1 if they are out of order, for i == even numbers
                for (int i = 0; i <= length - 2; i = i + 2)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSorted = false;
                    }
                }
            }
            return;
        }

        public static void Main()
        {
            int[] array = { 71, 42, 19, 3, 33, 28, 0, 89, 44, 2, 81 };
            int length = array.Length;

            Console.WriteLine("Odd-Even Sort");

            CommonFunctions.PrintInitial(array);

            Sort(array, length);

            CommonFunctions.PrintFinal(array);

            Console.ReadKey();
        }
    }
}
