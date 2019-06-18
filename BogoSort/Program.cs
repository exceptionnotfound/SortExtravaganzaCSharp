using System;
using System.Collections.Generic;

namespace BogoSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 2, 1, 3, 0 };
            Console.WriteLine("BogoSort");
            Console.WriteLine("Sorting...");
            BogoSort(list);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void BogoSort(List<int> list)
        {
            int iteration = 0;
            while (!IsSorted(list))
            {
                PrintIteration(list, iteration);
                list = Remap(list);
                iteration++;
            }

            PrintIteration(list, iteration); //Print the final, sorted iteration
            Console.WriteLine();
            Console.WriteLine("BogoSort completed after {0} iterations.", iteration);
        }

        static void PrintIteration(List<int> list, int iteration)
        {
            Console.Write("BogoSort iteration #{0}: ", iteration);
            foreach(var value in list)
            {
                Console.Write($"{value} ");
            }
            Console.WriteLine();
        }
        static bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        static List<int> Remap(List<int> list)
        {
            int temp;
            List<int> newList = new List<int>();
            Random r = new Random();

            while (list.Count > 0)
            {
                temp = (int)r.Next(list.Count);
                newList.Add(list[temp]);
                list.RemoveAt(temp);
            }
            return newList;
        }
    }
}
