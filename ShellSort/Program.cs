using SortExtravaganza.Common;
using System;

namespace ShellSort
{
    class ShellSort
    {
        static void Print(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static int Sort(int[] array)
        {
            int length = array.Length;

            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < length; i += 1)
                {
                    int temp = array[i];

                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }

                    array[j] = temp;
                }
            }
            return 0;
        }

        // Driver method 
        public static void Main()
        {
            int[] array = { 53, 19, 71, 3, 66, 62, 20, 84 };

            Console.WriteLine("Shell Sort");

            CommonFunctions.PrintInitial(array);

            Sort(array);

            CommonFunctions.PrintFinal(array);
            Console.ReadKey();
        }
    }
}
