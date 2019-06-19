using SortExtravaganza.Common;
using System;

namespace InsertionSort
{
    class InsertionSort
    {
        static void Main(string[] args)
        {
            int count = 15;
            int[] array = new int[15] { 55, 97, 76, 60, 4, 18, 37, 34, 88, 51, 43, 49, 19, 12, 63 };
            Console.WriteLine("Insertion Sort");

            CommonFunctions.PrintInitial(array);

            //1. For each value in the array...
            for (int i = 1; i < count; i++)
            {
                //2. Store the current value in a variable
                int currentValue = array[i];
                int pointer = i - 1;

                //3. As long as we are pointing to a valid value in the array...
                while (pointer >= 0)
                {
                    //4. If the current value is less than the value we are pointing at...
                    if (currentValue < array[pointer])
                    {
                        //5. Move the pointed-at value up one space, and insert the current value at the pointed-at position.
                        array[pointer + 1] = array[pointer];
                        array[pointer] = currentValue;
                    }
                    else break;
                }
            }
            Console.Write("\nSorted array is: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
