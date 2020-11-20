// C# program to perform TimSort. 
using SortExtravaganza.Common;
using System;

//TimSort is a stable sorting algorithm based on Merge Sort and Insertion Sort.
//This algorithm takes advantage of the fact that InsertionSort performs well on small collections.
//ALGORITHM:
//1. Divide the unsorted collection into smaller collections, where the size of those collections is a power of 2.
//These blocks are known as "run"
//2. For each run, sort the run using insertion sort.
//3. Once all runs are sorted, merge the runs together using merge sort.
class TimSort
{
    public const int RUN = 32;

    public static void InsertionSort(int[] array, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = array[i];
            int j = i - 1;
            while (array[j] > temp && j >= left)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = temp;
        }
    }

    // merge function merges the sorted runs 
    public static void Merge(int[] array, int l, int m, int r)
    {
        // original array is broken in two parts 
        // left and right array 
        int len1 = m - l + 1, len2 = r - m;
        int[] left = new int[len1];
        int[] right = new int[len2];
        for (int x = 0; x < len1; x++)
            left[x] = array[l + x];
        for (int x = 0; x < len2; x++)
            right[x] = array[m + 1 + x];

        int i = 0;
        int j = 0;
        int k = l;

        // after comparing, we merge those two array 
        // in larger sub array 
        while (i < len1 && j < len2)
        {
            if (left[i] <= right[j])
            {
                array[k] = left[i];
                i++;
            }
            else
            {
                array[k] = right[j];
                j++;
            }
            k++;
        }

        // copy remaining elements of left, if any 
        while (i < len1)
        {
            array[k] = left[i];
            k++;
            i++;
        }

        // copy remaining element of right, if any 
        while (j < len2)
        {
            array[k] = right[j];
            k++;
            j++;
        }
    }

    // iterative Timsort function to sort the 
    // array[0...n-1] (similar to merge sort) 
    public static void Sort(int[] arr, int n)
    {
        // Sort individual subarrays of size RUN 
        for (int i = 0; i < n; i += RUN)
        {
            InsertionSort(arr, i, Math.Min((i + 31), (n - 1)));
        }

        // start merging from size RUN (or 32). It will merge 
        // to form size 64, then 128, 256 and so on .... 
        for (int size = RUN; size < n; size = 2 * size)
        {
            // pick starting point of left sub array. We 
            // are going to merge arr[left..left+size-1] 
            // and arr[left+size, left+2*size-1] 
            // After every merge, we increase left by 2*size 
            for (int left = 0; left < n; left += 2 * size)
            {
                // find ending point of left sub array 
                // mid+1 is starting point of right sub array 
                int mid = left + size - 1;
                int right = Math.Min((left + 2 * size - 1), (n - 1));

                // merge sub array arr[left.....mid] & 
                // arr[mid+1....right] 
                Merge(arr, left, mid, right);
            }
        }
    }

    public static void Main()
    {
        int[] array = { 68, 14, 27, 91, 32, 18, 45, 71, 5, 9, 32 };
        int length = array.Length;

        Console.WriteLine("Timsort");

        CommonFunctions.PrintInitial(array);

        Sort(array, length);

        CommonFunctions.PrintFinal(array);

        Console.ReadKey();
    }
}
