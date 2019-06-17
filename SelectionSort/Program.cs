using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[15] { 45, 72, 58, 92, 26, 4, 13, 90, 81, 15, 33, 36, 47, 8, 54 };
            int count = 15;
            Console.WriteLine("Selection Sort");

            //First, output starting state of the array
            Console.Write("Initial array is: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            int temp, smallest;

            //The algorithm builds the sorted list from the left.
            //1. For each item in the array...
            for (int i = 0; i < count - 1; i++)
            {
                //2. ...assume the first item is the smallest value
                smallest = i;
                //3. Cycle through the rest of the array
                for (int j = i + 1; j < count; j++)
                {
                    //4. If any of the remaining values are smaller, find the smallest of these
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                //5. Swap the found-smallest value with the current value
                temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
            }

            //Output final state of the array
            Console.Write("Sorted array is: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }

            //We call ReadLine here to avoid noisy output in the command line.
            Console.ReadLine();
        }
    }
}
