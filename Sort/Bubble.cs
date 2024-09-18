using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    //https://www.geeksforgeeks.org/bubble-sort/
    public class Bubble
    {
        public void bubbleSort(int[] arr)
        {
            int i, j, temp;
            bool swapped;
            int n = arr.Length;
            for (i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap arr[j] and arr[j+1]
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }

                // IF no two elements were
                // swapped by inner loop, then break
                if (swapped == false)
                    break;
            }
        }
    }
}
