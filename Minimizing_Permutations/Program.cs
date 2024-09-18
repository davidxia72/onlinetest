using System;
using System.Collections.Generic;

namespace Minimizing_Permutations
{
    //Time Complexity: O(N! * N2) 
    //https://www.geeksforgeeks.org/minimum-number-of-prefix-reversals-to-sort-permutation-of-first-n-numbers/
    /*Input : a[] = {1, 2, 4, 3}
    Output : 3 
    Step1: Reverse the complete array a, a[] = {3, 4, 2, 1}
    Step2: Reverse the prefix(0 - 1) in s, a[] = { 4, 3, 2, 1}
    Step3: Reverse the complete array a, a[] = { 1, 2, 3, 4 }
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 4, 3 };
            Console.WriteLine(minimumPrefixReversals(a));
        }

        public class Node
        {
            public String str;
            public int steps;

            public Node(String str, int steps)
            {
                this.str = str;
                this.steps = steps;
            }
        }

        // function to find minimum prefix reversal through BFS
        public static int minimumPrefixReversals(int[] a)
        {
            // size of array
            int n = a.Length;

            // string for initial and goal nodes
            String start = "", destination = "";

            // string for manipulation in while loop
            String original = "", modified = "";

            // node to store temporary values
            // from front of queue
            Node temp = null;

            // create the starting string
            for (int i = 0; i < n; i++)
                start += a[i];

            // sort the array and prepare
            // final destination string
            Array.Sort(a);
            for (int i = 0; i < n; i++)
                destination += a[i];

            // this queue will store all the BFS siblings
            Queue<Node> q = new Queue<Node>();

            // place the starting node in queue
            q.Enqueue(new Node(start, 0));

            //base case:- if array is already sorted
            if (start == destination)
                return 0;


            // loop until the size of queue is empty
            while (q.Count != 0)
            {
                // put front node of queue in temporary variable
                temp = q.Dequeue();

                // store the original string at this step
                original = temp.str;

                for ( int j = 2; j <= n; j++)
                {
                    // modified will be used to generate all
                    // manipulation of original string
                    // like if original = 1342
                    // modified = 3142 , 4312 , 2431

                    modified = original;

                    // generate the permutation by reversing
                    modified = reverse(modified, j);

                    if (modified.Equals(destination))
                    {
                        // if string match then return
                        // the height of the current node
                        return temp.steps + 1;
                    }

                    // else put this node into queue
                    q.Enqueue(new Node(modified, temp.steps + 1));
                }
            }

            // if no case match then default value
            return int.MinValue;
        }

        // function to reverse the string upto an index
        public static String reverse(String s, int index)
        {
            char[] temp = s.ToCharArray();
            int i = 0;
            while (i < index)
            {
                char c = temp[i];
                temp[i] = temp[index - 1];
                temp[index - 1] = c;
                i++; index--;
            }
            return String.Join("", temp);
        }

    }
}
