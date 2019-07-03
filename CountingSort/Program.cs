using SortExtravaganza.Common;
using System;

namespace CountingSort
{
    //This algorithm assumes we know the range of correct values.  
    //For this demo,we are assuming a range of 0-100.
class CountingSort
{
    static void Sort(int[] array)
    {
        int length = array.Length;

        //Create a new "output" array
        int[] output = new int[length];

        //Create a new "counting" array which stores the count of each unique number
        int[] count = new int[100];
        for (int i = 0; i < 100; ++i)
        {
            count[i] = 0;
        }
        for (int i = 0; i < length; ++i)
        {
            ++count[array[i]];
        }

        //Change count[i] so that count[i] now contains actual position of  
        //this character in the output array.
        for (int i = 1; i <= 99; ++i)
        {
            count[i] += count[i - 1];
        }

        //Build the output array.
        //To make this sorting algorithm stable, we are operating in reverse order. 
        for (int i = length - 1; i >= 0; i--)
        {
            output[count[array[i]] - 1] = array[i];
            --count[array[i]];
        }

        //Copy the output array to the final array.
        for (int i = 0; i < length; ++i)
        {
            array[i] = output[i];
        }
    }

    public static void Main()
    {
        int[] array = { 64, 11, 83, 8, 13, 45, 92, 98, 55, 17, 41, 81, 11, 64, 14, 41, 11, 92 };

        Console.WriteLine("Counting Sort");

        CommonFunctions.PrintInitial(array);

        Sort(array);

        CommonFunctions.PrintFinal(array);
        Console.ReadLine();
    }
}
}
