using SortExtravaganza.Common;
using System;

namespace CocktailShakerSort
{
    //Cocktail Shaker Sort is pretty much like Bubble Sort, except that it moves items both ways
    //(higher to lower and lower to higher) on each pass.
    class CocktailShakerSort
    {

        static void Sort(int[] array)
        {
            bool isSwapped = true;
            int start = 0;
            int end = array.Length;

            while (isSwapped == true)
            {

                //Reset this flag.  It is possible for this to be true from a prior iteration.
                isSwapped = false;

                //Do a bubble sort on this array, from low to high.  If something changed, make isSwapped true.
                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }

                //If no swaps are made, the array is sorted.
                if (isSwapped == false)
                    break;

                //We need to reset the isSwapped flag for the high-to-low pass
                isSwapped = false;

                //The item we just moved is in its rightful place, so we no longer need to consider it unsorted.
                end -= 1;

                //Now we bubble sort from high to low
                for (int i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                    }
                }

                //Finally, we need to increase the starting point for the next low-to-high pass.
                start += 1;
            }
        }

        public static void Main()
        {
            int[] array = { 15, 10, 83, 5, 7, 42, 65, 50, 58, 71, 61 };

            CommonFunctions.PrintInitial(array);

            Sort(array);

            CommonFunctions.PrintFinal(array);

            Console.ReadKey();
        }
    }
}
