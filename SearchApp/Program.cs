using System;

namespace SearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string userinput = Console.ReadLine();
            if (userinput == "tree")
            {
                BinarySearch search = new BinarySearch(10);
                search.insertBST(9);
                search.insertBST(11);
                search.insertBST(7);
                search.insertBST(8);
                search.insertBST(12);
                search.insertBST(13);
                //search.insertBST(6);
                search.insertBST(14);
                search.insertBST(15);
                /*  Console.WriteLine(searchMin(search));
                  Console.WriteLine(searchValue(search, 5));
                  Console.WriteLine(searchValue(search, 15));
                  Console.WriteLine(searchValue(search, 7));
                  Console.WriteLine(searchValue(search, 12));
                */
                Console.WriteLine(search.findHeight(search.GetRoot()));
                search.inOrderPrint(search.GetRoot());
            }
            else if (userinput == "array") //  array
            {
                int[] array = { 0, 1, 2, 9, 7, 8 };
                Array.Sort(array); // Searches a one-dimensional sorted Array for a value, using a binary search algorithm.
                int index = Array.BinarySearch(array, 9);
                Console.WriteLine($"index is {index}");


                object o = BinarySearchRecursive(array, 5, 0, array.Length - 1);
                Console.WriteLine($"return is {o}");

                o = BinarySearchRecursive(array, 9, 0, array.Length - 1);
                Console.WriteLine($"return is {o}");
            }
            else //if (userinput == "shortest")
            {
                //https://courses.lumenlearning.com/waymakermath4libarts/chapter/shortest-path/
                //int[,] graph =  {
                //          { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                //          { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                //          { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                //          { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                //          { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                //          { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                //          { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                //          { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                //          { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                //            };
                int[,] graph =  {
                          { 0, 104, 96, 76, 0, 0, 0},
                          { 104, 0, 0, 0, 36, 0, 0 },
                          { 96, 0, 0, 27, 0, 0, 0 },
                          { 76, 0, 27, 0, 0, 96, 0},
                          { 0, 36, 0, 0, 0, 0, 20 },
                          { 0, 0, 0, 96, 0, 0, 57 },
                          { 0, 0, 0, 0, 20, 57, 0 },
                      
                            };
                (new DijkstraAlgo()).excute(graph, 0, 7);
            }
        }

        public static object BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            if (min > max)
            {
                return "Nil";
            }
            else
            {
                int mid = (min + max) / 2;
                if (key == inputArray[mid])
                {
                    return ++mid;
                }
                else if (key < inputArray[mid])
                {
                    return BinarySearchRecursive(inputArray, key, min, mid - 1);
                }
                else
                {
                    return BinarySearchRecursive(inputArray, key, mid + 1, max);
                }
            }
        }
        static int searchMin(BinarySearch search)
        {
            
            return search.findMin(search.GetRoot());
        }
        static int searchValue(BinarySearch search, int value)
        {
            return search.findValue_BST(value);
        }
    }
}
