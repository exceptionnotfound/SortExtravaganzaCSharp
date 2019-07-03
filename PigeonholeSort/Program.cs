using SortExtravaganza.Common;
using System;
using System.Linq;

namespace PigeonholeSort
{
    class PigeonholeSort
    {
        public static void Sort(int[] array)
        {
            int length = array.Length;

            //Find the range of values in the array
            int min = array.Min();
            int max = array.Max();
            int range = max - min + 1;

            //Create a set of pigeonholes with the size of the range of values
            int[] pigeonholes = new int[range];
            for (int i = 0; i < length; i++)
            {
                pigeonholes[i] = 0;
            }

            //For each value in the array, mark how many times the index of the pigeonhole appeared in the root array.
            for (int i = 0; i < length; i++)
            {
                pigeonholes[array[i] - min]++;
            }

            int index = 0;

            //Use the pigeonhole array to sort the main array.
            for (int j = 0; j < range; j++)
            {
                //We are using a post-decrement here to keep track of the number of values we've already added to the array.
                while (pigeonholes[j]-- > 0)
                {
                    array[index] = j + min;
                    index++;
                }
            }

        }

        static void Main()
        {
            int[] array = {51, 18, 99, 23, 40, 1, 82, 85, 18, 12, 76};

            CommonFunctions.PrintInitial(array);

            Sort(array);

            CommonFunctions.PrintFinal(array);

            Console.ReadLine();
        }
    }
}
