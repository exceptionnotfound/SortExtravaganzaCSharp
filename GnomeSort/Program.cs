using SortExtravaganza.Common;
using System;

namespace GnomeSort
{
    class GnomeSort
    {

        static void Sort(int[] arr, int length)
        {
            int index = 0;

            while (index < length)//If there is no pot next to the gnome, he is done.
            {
                if (index == 0) //If the gnome is at the start of the line...
                {
                    index++;//he steps forward
                }

                if (arr[index] >= arr[index - 1])//If the pots next to the gnome are in the correct order...
                {
                    index++;//he goes to the next pot
                }
                else //If the pots are in the wrong order, he switches them.
                {
                    int temp = arr[index];
                    arr[index] = arr[index - 1];
                    arr[index - 1] = temp;
                    index--;
                }
            }
            return;
        }

        public static void Main()
        {
            int[] array = { 84, 61, 15, 2, 7, 55, 19, 40, 78, 33 };

            Console.WriteLine("Gnome Sort");

            CommonFunctions.PrintInitial(array);

            Sort(array, array.Length);

            CommonFunctions.PrintFinal(array);

            Console.ReadKey();
        }
    }
}
