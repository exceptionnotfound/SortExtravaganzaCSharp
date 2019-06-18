using System;
using System.Linq;

namespace RadixSort
{
    class Program
    {
        public static void Main()
        {
            int[] array = { 330, 8, 27, 4419, 55, 816, 419, 77, 622, 1234, 6, 9, 241, 1, 35, 7733, 4, 69 };
            int length = array.Length;

            Console.WriteLine("Radix Sort");
            Console.Write("Initial array is: ");
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }

            int max = array.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountingSort(array, length, exp);
            }

            Console.Write("\nSorted array is: ");
            for (int i = 0; i < length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.ReadLine();
        }

        //This is a modified version of Counting Sort from an earlier post
        //We need to do Counting Sort against each group of integers,
        //where the groups are made based on the number of significant digits.
        //So, we do Counting Sort on all 1-digit numbers, all 2-digit numbers, etc.
        //After that, we concatenate the groups together to form the final array.
        public static void CountingSort(int[] array, int length, int exponent)
        {
            //Create a new "output" array
            int[] output = new int[length]; // output array  
            int i;

            //Create a new "counting" array which stores the count of each unique number
            int[] count = new int[10];
            for (i = 0; i < 10; i++)
            {
                count[i] = 0;
            }
            for (i = 0; i < length; i++)
            {
                count[(array[i] / exponent) % 10]++;
            }

            //Change count[i] so that count[i] now contains actual position of  
            //this character in the output array.
            for (i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            //Build the output array.
            //This is the tricky part.
            for (i = length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exponent) % 10] - 1] = array[i];
                count[(array[i] / exponent) % 10]--;
            }

            //Copy the output array to the final array.
            for (i = 0; i < length; i++)
            {
                array[i] = output[i];
            }
        }
    }
}
