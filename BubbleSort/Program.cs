using System;

namespace BubbleSort
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] array = { 92, 28, 3, 71, 50, 14, 24, 20, 66, 70, 45, 17, 9, 99, 38 };
            int temp;
            Console.Write("Original array: ");
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
            //1. For each item in the array...
            for (int i = 0; i <= array.Length - 2; i++)
            {
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    //2. ...if two adjoining elements are in the wrong order, swap them.
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                    //3. Repeat this for all pairs of elements.
                }
            }
            Console.Write("\n" + "Sorted array: ");
            foreach (int value in array)
            {
                Console.Write(value + " ");
            }
            Console.Write("\n");
            Console.ReadLine();
        }
    }
}
