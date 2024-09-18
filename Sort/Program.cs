using System;

namespace Sort
{
    /*
      https://www.geeksforgeeks.org/g-fact-86/
    Auxiliary Space is the extra space or temporary space used by an algorithm.
    Space Complexity of an algorithm is total space taken by the algorithm with respect to the input size. Space complexity includes both Auxiliary space and space used by input.
    For example, if we want to compare standard sorting algorithms on the basis of space, then Auxiliary Space would be a better criteria than Space Complexity.Merge Sort uses O(n) auxiliary space, Insertion sort and Heap Sort use O(1) auxiliary space.Space complexity of all these sorting algorithms is O(n) though. 
    */
    class Program
    {
        static void Main(string[] args)
        {
            string userinput = Console.ReadLine();
            int[] arr = { 12, 11, 13, 5, 6, 7 };
            if (userinput == "merge")
            {
                Console.WriteLine("Given Array");
                printArray(arr);
                MergeSort ob = new MergeSort();
                ob.sort(arr, 0, arr.Length - 1);
                Console.WriteLine("\nSorted array");
                printArray(arr);
            }
            else if (userinput == "bubble")
            {
                Console.WriteLine("Given Array");
                printArray(arr);
                Bubble ob = new Bubble();
                ob.bubbleSort(arr);
                Console.WriteLine("\nSorted array");
                printArray(arr);
            }
            static void printArray(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n; ++i)
                    Console.Write(arr[i] + " ");
                Console.WriteLine();
            }
        }
    }
}
