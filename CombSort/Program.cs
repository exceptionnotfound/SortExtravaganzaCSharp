using System;

namespace CombSort
{
    //Comb Sort sorts a list by comparing values across a "gap" and switching them if they are 
    //out of order.  On each iteration through the list, the gap shrinks by a certain amount,
    //until it is comparing elements that are next to each other.
    //The gap is length of the list N divided by shrink factor K.
    //K has been empirically proven to be most efficient at 1.3.
    class Program
    {
        public static void Main()
        {
            int[] arr = { 10, 28, 1, 55, 6, 21, 36, 3, 45, 15, 0 };

            Console.Write("Initial array is: ");
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }

            CombSort(arr);

            Console.Write("\nSorted array is: ");
            for (int i = 0; i < arr.Length; ++i)
            {
                Console.Write(arr[i] + " ");
            }
            Console.ReadLine();

        }

        static int GetNextGap(int gap)
        {
            //The "shrink factor", empirically shown to be 1.3
            gap = (gap * 10) / 13;
            if (gap < 1)
            {
                return 1;
            }
            return gap;
        }

        static void CombSort(int[] array)
        {
            int length = array.Length;

            int gap = length;

            //We initialize this as true to enter while loop.
            bool swapped = true;

            while (gap != 1 || swapped == true)
            {
                gap = GetNextGap(gap);

                // Set swapped as false.  Will only go to true if two values get swapped.
                swapped = false;

                // Compare all elements with current gap 
                for (int i = 0; i < length - gap; i++)
                {
                    if (array[i] > array[i + gap])
                    {
                        // Swap array[i] and array[i + gap] 
                        int temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;

                        swapped = true;
                    }
                }
            }
        }
    }
}
