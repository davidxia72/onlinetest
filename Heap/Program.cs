using System;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            string userinput = Console.ReadLine();
            if (userinput == "large")
            {
                LargestTripletMultiplication Obj = new LargestTripletMultiplication();
                Obj.execute(arr);
            }
            else if (userinput == "max")
            {
                arr = new int[]{ 2, 1, 8, 4, 100 };
                MaxHeap heap = new MaxHeap(arr, arr.Length);  // nlogn
                int k = 3;
                int total = 0;
                while (k > 0)
                {
                    int max =  heap.RemoveMaximum();
                    total += max;
                    heap.InsertElementInHeap(max / 2);  // logn
                    k--;
                }
                Console.WriteLine($"output is: {total}");
            }
        }
    }
}
