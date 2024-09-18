using System;
using System.Collections.Generic;

namespace PairSum
{
    // We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
    class PairSums
    {
        static void Main(string[] args)
        {
            // Call numberOfWays() with test cases here
            Console.Write("input sum");
            int sum = int.Parse(Console.ReadLine());
            //Console.WriteLine(DateTime.Now);
            int[] arr = { 1, 4, 2,2, 3,3};
            int output = numberOfWays(arr, sum);
            Console.WriteLine("Count of pairs is " + output);

            output = numberOfWays2(arr, sum);
            Console.WriteLine("Count of pairs is " + output);
        }

        private static int numberOfWays(int[] arr, int k)
        {
            // Write your code here
            int count = 0; // Initialize result

            // Consider all possible pairs
            // and check their sums
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if ((arr[i] + arr[j]) == k)
                        count++;

            return count;
        }

        private static int numberOfWays2(int[] arr, int sum)
        {
            Dictionary<int, int> hm = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!hm.ContainsKey(arr[i]))
                {
                    hm[arr[i]] = 0;
                }

                hm[arr[i]] = hm[arr[i]] + 1;
            }
            int twice_count = 0;

            // iterate through each element and
            // increment the count (Notice that
            // every pair is counted twice)
            for (int i = 0; i < arr.Length; i++)
            {
                if (hm.ContainsKey(sum - arr[i]))
                {
                    twice_count += hm[sum - arr[i]];
                }

                // if (arr[i], arr[i]) pair satisfies
                // the condition, then we need to ensure
                // that the count is decreased by one
                // such that the (arr[i], arr[i])
                // pair is not considered
                if (sum - arr[i] == arr[i])
                {
                    twice_count--;
                }
            }

            // return the half of twice_count
            return twice_count / 2;
        }
    }
}
