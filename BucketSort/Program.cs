using SortExtravaganza.Common;
using System;
using System.Collections.Generic;

namespace BucketSort
{
    //Bucket Sort breaks a list of items into sublists, so that you can use another sorting
    //algorithm to sort the sublists.  In this case, we will use insertion sort.
    //To use this algorithm, we must determine how many buckets our numbers can be sorted into.
    //Because our starting array has numbers in the range 1-99, we will use 10 buckets based on
    //the least-significant digit of the value.
    class Program
    {
        public static List<int> BucketSort(params int[] x)
        {
            List<int> sortedArray = new List<int>();

            int numOfBuckets = 10;

            //Create buckets
            List<int>[] buckets = new List<int>[numOfBuckets];
            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            //Iterate through the passed array and add each integer to the appropriate bucket
            for (int i = 0; i < x.Length; i++)
            {
                int bucket = (x[i] / numOfBuckets);
                buckets[bucket].Add(x[i]);
            }

            //Sort each bucket and add it to the result List
            for (int i = 0; i < numOfBuckets; i++)
            {
                List<int> temp = InsertionSort(buckets[i]);
                sortedArray.AddRange(temp);
            }
            return sortedArray;
        }

        //Insertion Sort
        public static List<int> InsertionSort(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                //2. Store the current value in a variable
                int currentValue = input[i];
                int pointer = i - 1;

                //3. As long as we are pointing to a valid value in the array...
                while (pointer >= 0)
                {
                    //4. If the current value is less than the value we are pointing at...
                    if (currentValue < input[pointer])
                    {
                        //5. Move the pointed-at value up one space, and insert the current value at the pointed-at position.
                        input[pointer + 1] = input[pointer];
                        input[pointer] = currentValue;
                    }
                    else break;
                }
            }

            return input;
        }
        static void Main(string[] args)
        {
            int[] array = new int[] { 43, 17, 87, 92, 13, 6, 96, 12, 66, 62, 4 };

            Console.WriteLine("Bucket Sort");

            CommonFunctions.PrintInitial(array);

            List<int> sorted = BucketSort(array);

            CommonFunctions.PrintFinal(array);
            Console.ReadLine();
        }
    }
}
