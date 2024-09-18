using System;
using System.Collections.Generic;
using System.Linq;

namespace Group_People_Given_Group_Size
{
    //https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
    // There are n people that are split into some unknown number of groups.Each person is labeled with a unique ID from 0 to n - 1.
    //You are given an integer array groupSizes, where groupSizes[i] is the size of the group that person i is in. For example, if groupSizes[1] = 3, then person 1 must be in a group of size 3.
    //Both implementations require O(N) linear space and the time complexity is also O(N) where N is the number of the elements in the original list i.e. each number will be visited exactly twice.
    class Program
    {
        //string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        //int[] array = new int[5]; The elements of the array are initialized to the default value of the element type, 0 for integers.
        static void Main(string[] args)
        {
            //int[] groupSizes = new int[] { 3, 3, 3, 3, 3, 1, 3 };
            int[] groupSizes = new int[] { 2, 1, 3, 3, 3, 2 };
            List<int[]> list = groupThePeople(groupSizes);
            Console.WriteLine("output: [");
            foreach (int[] arr in list)
            {
                Console.Write("[");
                for (int i = 0; i < arr.Length; ++i)
                {
                    if( i == arr.Length - 1)
                        Console.Write("{0}", arr[i]);
                    else
                        Console.Write("{0},", arr[i]);
                }
                Console.Write("]");
            }
            Console.WriteLine("]");
        }
        private static List<int[]> groupThePeople(int[] groupSizes)
        {
            List<int[]> ans = new List<int[]>();
            Dictionary<int, List<int>> ids = new Dictionary<int, List<int>>();
            for (int i = 0; i < groupSizes.Length; ++i)
            {
                if (!ids.ContainsKey(groupSizes[i]))  // add new keyvalue pair
                {
                    ids[groupSizes[i]] = new List<int>();
                    ids[groupSizes[i]].Add(i);
                }
                else 
                {
                    ids[groupSizes[i]].Add(i);
                }
            }
            //var items = from pair in ids
            //            orderby pair.Key descending
            //            select pair;
            foreach (KeyValuePair<int, List<int>> item in ids)
            {
                
                int startIndex = 0;
                while (startIndex < item.Value.Count)
                {
                    int[] subarr = new int[item.Key];
                    for (int j=0; j< subarr.Length; j++)
                    {
                        subarr[j] = item.Value[startIndex];
                        if (j == subarr.Length - 1) // this array is full
                        {
                            ans.Add(subarr);
                        }
                        startIndex++;
                    }
                }
            }
            return ans;
        }
    }
}
