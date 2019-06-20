using SortExtravaganza.Common;
using System;
using System.Linq;

namespace BeadSort
{
    class BeadSort
    {

        static int[] Sort(int[] array)
        {
            bool[,] beads = new bool[10,100];
            //Find maximum element
            int max = array.Max();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i]; j++)
                {
                    beads[i, j] = true;
                }
            }

            for (int j = 0; j < max; j++)
            {
                int sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (beads[i, j] != false)
                    {
                        sum++;
                        beads[i, j] = false;
                    }
                }

                for(int i = array.Length - sum; i < array.Length; i++)
                {
                    beads[i, j] = true;
                }
            }

            //Put sorted values in array
            for(int i = 0; i < array.Length; i++)
            {
                int j;
                for (j = 0; j < max && beads[i, j] != false; j++) ;
                array[i] = j;
            }

            return array;
        }

        static void Main(string[] args)
        {
            int[] array = { 53, 12, 18, 94, 62, 20, 38, 61, 71, 7 };
            CommonFunctions.PrintInitial(array);
            var sortedArray = Sort(array);
            CommonFunctions.PrintFinal(sortedArray);
            Console.ReadKey();
        }
    }
}
