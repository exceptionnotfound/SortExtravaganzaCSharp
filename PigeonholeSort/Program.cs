using SortExtravaganza.Common;
using System;

namespace PigeonholeSort
{
    class PigeonholeSort
    {
        // Driver Code 
        public static void Main(string[] args)
        {
            int[] array = { 64, 11, 83, 8, 13, 45, 92, 98, 55, 17, 41, 81 };

            Console.WriteLine("Pigeonhole Sort");

            CommonFunctions.PrintInitial(array);

            Sort(array, array.Length);

            CommonFunctions.PrintFinal(array);
            Console.ReadLine();
        }

        public static void Sort(int[] array, int n)
        {
            //1. Find the min, max, and range of values in the array
            int min = array[0];
            int max = array[0];
            int range = max - min + 1;

            for (int a = 0; a < n; a++)
            {
                if (array[a] > max)
                {
                    max = array[a];
                }
                if (array[a] < min)
                {
                    min = array[a];
                }
            }

            //2. Create a new array of "pigeonholes" with the same number of holes as the number of elements in the array.
            int[] pigeonholes = new int[range];

            for (int i = 0; i < n; i++)
            {
                pigeonholes[i] = 0;
            }

            //3. For each value in the array, place it in its appropriate pigeonhole.  
            for (int i = 0; i < n; i++)
            {
                pigeonholes[array[i] - min]++;
            }


            //4. For each value in the pigeonholes, place it into its final sorted position.
            int index = 0;
            for (int j = 0; j < range; j++)
            {
                while (pigeonholes[j]-- > 0)
                {
                    array[index++] = j + min;
                }
            }

        }
    }
}
