using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    //Time Complexity : O(log n)
    //Space Complexity : O(log n) // height of the tree
    public class MaxHeap
    {
        public int[] Array;
        public int Length;
        public MaxHeap(int[] input, int length)
        {
            this.Length = length;
            this.Array = input;
            BuildMaxHeap();
        }
        private void BuildMaxHeap()
        {
            for (int i = this.Length / 2; i > 0; i--)
            {
                MaxHeapify(i);
            }
            return;
        }
        public void MaxHeapify(int index)
        {
            var left = 2 * index;
            var right = 2 * index + 1;

            int max = index;
            if (left <= this.Length && this.Array[left - 1] > this.Array[index - 1])
            {
                max = left;
            }

            if (right <= this.Length && this.Array[right - 1] > this.Array[max - 1])
            {
                max = right;
            }

            if (max != index)
            {
                int temp = this.Array[max - 1];
                this.Array[max - 1] = this.Array[index - 1];
                this.Array[index - 1] = temp;
                MaxHeapify(max);
            }

            return;
        }
        public int RemoveMaximum()
        {
            int maximum = this.Array[0];

            this.Array[0] = this.Array[this.Length - 1];
            this.Length--;
            MaxHeapify(1);
            return maximum;
        }

        public int GetMaximum()
        {
            return this.Array[0];
        }
        public void RebuildMaxHeap(int newItem)
        {
            this.Array[0] = newItem;
            BuildMaxHeap();
        }
        public void InsertElementInHeap(int newItem)
        {
            //System.Array.Resize(ref this.Array, this.Array.Length + 1);
            this.Array[Length] = newItem;
            this.Length++;
            HeapifyBottomToTop(this.Length);
        }
        public void HeapifyBottomToTop(int index)
        {
            int parent = index / 2;
            // We are at root of the tree. Hence no more Heapifying is required.  
            if (index <= 1)
            {
                return;
            }
            // If Current value is smaller than its parent, then we need to swap  
            if (this.Array[index-1] > this.Array[parent-1])
            {
                int tmp = this.Array[index-1];
                this.Array[index-1] = this.Array[parent-1];
                this.Array[parent-1] = tmp;
            }
            HeapifyBottomToTop(parent);
        }//end of method  
    }
}
