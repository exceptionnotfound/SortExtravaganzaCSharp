using SortExtravaganza.Common;
using System;

namespace ShellSort
{
//The main idea behind Shell Sort is to exchange items which
//are far apart.  To that end, we do a "gapped" insertion sort,
//in which the gap is the number of "subarrays" we will sort
//independently of each other.
class ShellSort
{
    static int Sort(int[] array)
    {
        int length = array.Length;

        for (int h = length / 2; h > 0; h /= 2)
        {
            for (int i = h; i < length; i += 1)
            {
                int temp = array[i];

                int j;
                for (j = i; j >= h && array[j - h] > temp; j -= h)
                {
                    array[j] = array[j - h];
                }

                array[j] = temp;
            }
        }
        return 0;
    }

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
