using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class LargestTripletMultiplication
    {
        public void execute(int[] arr)
        {
            // call a priority queue
            int n = arr.Length;
            List<int> q = new List<int>();

            // traversing the array
            for (int i = 0; i < n; i++)
            {
                // pushing arr[i] in array
                q.Add(arr[i]);
                q.Sort();

                // if less than three elements are present
                // in array print -1
                if (q.Count < 3)
                    Console.WriteLine("-1");
                else
                {

                    // pop three largest elements
                    int x = q[q.Count - 1];
                    int y = q[q.Count - 2];
                    int z = q[q.Count - 3];
                    //q.RemoveRange(0, 3);

                    // Reinsert x, y, z in priority_queue
                    int ans = x * y * z;
                    Console.WriteLine(ans);
                    //q.Add(x);
                    //q.Add(y);
                    //q.Add(z);
                }
            }
        }
    }
}
