using System;

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 100;
            int[] arr = fibonacci(counter);
            Console.Write("[");
            for (int i = 0; i < arr.Length; ++i)
            {
                if (i == arr.Length - 1)
                    Console.Write("{0}", arr[i]);
                else
                    Console.Write("{0},", arr[i]);
            }
            Console.Write("]");
        }

        private static int[] fibonacci(int counter)
        {
            int current_position = 2;
            int[] arr = new int[counter];
            arr[0] = 0;
            arr[1] = 1;
            while (current_position < counter)
            {
                arr[current_position] = arr[current_position - 1] + arr[current_position - 2];
                current_position++;
            }
            return arr;
        }
    }
}
