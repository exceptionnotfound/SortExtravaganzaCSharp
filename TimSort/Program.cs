using SortExtravaganza.Common;
using System;

namespace TimSort
{
    //Timsort is a combination of Merge Sort and Insertion Sort.  It is specifically designed
    //to perform well on real-world data, and forms the sorting mechanism for various implementations,
    //including those in Java, Android, and Chrome.
    //ALGORITHM
    //1. Divide the array of unsorted numbers into blocks, called "Run".
    //2. Sort each run using Insertion Sort.
    //3. Merge each run using Merge Sort.
    //NOTE: Remember that Merge Sort performs best when the number of elements is a power of 2.
    class TimSort
    {
        public const int RUN = 4;

        //We sort each run using Insertion Sort.
        //It is possible for the size of the original array to be less than the size of run;
        //if that happens, we will ONLY do Insertion Sort.
        public static void InsertionSort(int[] array, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = array[i];
                int j = i;
                j--;
                while (j >= left && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }

        //After the runs have been sorted using Insertion Sort, we merge them with Merge Sort.
        public static void Merge(int[] array, int l, int m, int r)
        {
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
            {
                left[x] = array[l + x];
            }
            for (int x = 0; x < len2; x++)
            {
                right[x] = array[m + 1 + x];
            }

            int i = 0;
            int j = 0;
            int k = l;

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

            while (i < len1)
            {
                array[k] = left[i];
                k++;
                i++;
            }

            while (j < len2)
            {
                array[k] = right[j];
                k++;
                j++;
            }
        }

        //This is the "top-level" sort functions, which iteratively calls Insertion Sort on the runs
        //and then merges them using Merge Sort.
        public static void Sort(int[] array, int length)
        {
            //Split the main array into subarrays called "runs".
            for (int i = 0; i < length; i += RUN)
            {
                InsertionSort(array, i, Math.Min((i + (RUN - 1)), (length - 1)));
            }

            // start merging from size RUN (or 32). It will merge  
            // to form size 64, then 128, 256 and so on ....  
            for (int size = RUN; size < length; size = 2 * size)
            {
                // pick starting point of left sub array. We  
                // are going to merge arr[left..left+size-1]  
                // and arr[left+size, left+2*size-1]  
                // After every merge, we increase left by 2*size  
                for (int left = 0; left < length; left += 2 * size)
                {
                    // find ending point of left sub array  
                    // mid+1 is starting point of right sub array  
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (length - 1));

                    // merge sub array arr[left.....mid] &  
                    // arr[mid+1....right]  
                    Merge(array, left, mid, right);
                }
            }
        }

        public static void Main()
        {
            int[] array = { 88, 31, 16, 8, 69, 92, 27, 79, 10, 3 };
            int length = array.Length;

            CommonFunctions.PrintInitial(array);

            Sort(array, length);

            CommonFunctions.PrintFinal(array);
            Console.ReadKey();
        }
    }
}
