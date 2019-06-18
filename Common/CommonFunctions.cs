using System;
using System.Collections.Generic;

namespace SortExtravaganza.Common
{
    public static class CommonFunctions
    {
        public static void PrintInitial(List<int> list)
        {
            Console.Write("Initial array is: ");
            Print(list.ToArray());
        }

        public static void PrintInitial(int[] array)
        {
            Console.Write("Initial array is: ");
            Print(array);
        }

        public static void PrintFinal(List<int> list)
        {
            Console.Write("Sorted array is: ");
            Print(list.ToArray());
        }

        public static void PrintFinal(int[] array)
        {
            Console.Write("Sorted array is: ");
            Print(array);
        }

        private static void Print(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length; ++i)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
