using System;
using System.Collections.Generic;

namespace SlowSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 2, 1, 3 };
            Console.WriteLine(getTotalTime(arr));
        }
        private static int getTotalTime(int[] arr)
        {
            // Write your code here
            int total = 0;
            Array.Sort(arr);  // nlogn
            Array.Reverse(arr);
            int size = arr.Length;
            int i = 2;
            total = arr[0] + arr[1];
            int temp = total;
            while (i < size)
            {
                temp  += arr[i];
                total += temp;
                i++;
            }
            return total;
        }
    }
}
