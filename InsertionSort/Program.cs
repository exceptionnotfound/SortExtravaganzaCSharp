using SortExtravaganza.Common;
using System;

namespace InsertionSort
{
class InsertionSort
{
    static void Main(string[] args)
    {
        int[] array = new int[15] { 55, 97, 76, 60, 4, 18, 37, 34, 88, 51, 43, 49, 19, 12, 63 };
        Console.WriteLine("Insertion Sort");

        CommonFunctions.PrintInitial(array);

        //1. For each value in the array...
        for (int i = 1; i < array.Length; ++i)
        {
            //2. Store the current value in a variable.
            int currentValue = array[i];
            int pointer = i - 1;

            //3. While we are pointing to a valid value...
            //4. If the current value is less than the value we are pointing at...
            while (pointer >= 0 && array[pointer] > currentValue)
            {
                //5. Then move the pointed-at value up one space, and store the
                //   current value at the pointed-at position.
                array[pointer + 1] = array[pointer];
                pointer = pointer - 1;
            }
            array[pointer + 1] = currentValue;
        }

        CommonFunctions.PrintFinal(array);

        Console.ReadLine();
    }
}
}
