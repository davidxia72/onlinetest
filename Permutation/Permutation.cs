using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Permutation_combination
{
    public class Calculation
    {
        public IEnumerable<IList> PermutateList(IList sequence, int count)
        {
            if (count == 1) 
                yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in PermutateList(sequence, count - 1))
                        yield return perm;
                    RotateRight(sequence, count);
                }
            }
        }
        private void RotateRight(IList sequence, int count)
        {
            object tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }
        public List<List<int>> CombinateList(int[] arr,
                                 int n, int r)
        {

            List<List<int>> returnedList = new List<List<int>>();
            // A temporary array to store 
            // all combination one by one
            int[] data = new int[r];

            // Print all combination 
            // using temporary array 'data[]'
            combinationUtil(arr, data, 0,
                            n - 1, 0, r, returnedList);
            return returnedList;
        }
        private void combinationUtil(int[] arr, int[] data,
                                int start, int end,
                                int index, int r, List<List<int>> returnedList)
        {
            // Current combination is 
            // ready to be printed, 
            // print it
            if (index == r)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < r; j++)
                //Console.Write(data[j] + " ");
                {
                    list.Add(data[j]);
                }
                returnedList.Add(list);
                //Console.WriteLine("");
                return;
            }

            // replace index with all
            // possible elements. The 
            // condition "end-i+1 >= 
            // r-index" makes sure that 
            // including one element
            // at index will make a 
            // combination with remaining 
            // elements at remaining positions
            for (int i = start; i <= end &&
                      end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1,
                                end, index + 1, r, returnedList);
            }
        }
        public int GetMin(IEnumerable<IList> list1, IEnumerable<IList> list2, ref int minNum1, ref int minNum2)
        {
            List<int> listNum1 = new List<int>();
            List<int> listNum2 = new List<int>();
            int min = 100000;
            foreach (List<int> permu in list1)
            {
                string strNum = string.Empty;
                foreach (int num in permu)
                //Console.Write(i.ToString() + " ");
                {
                    strNum = strNum + num.ToString();
                }
                listNum1.Add(int.Parse(strNum));
            }
            foreach (List<int> permu2 in list2)
            {
                string strNum = string.Empty;
                foreach (int num in permu2)
                //Console.Write(i.ToString() + " ");
                {
                    strNum = strNum + num.ToString();
                }
                listNum2.Add(int.Parse(strNum));
            }
            foreach (int num1 in listNum1)
            {
                foreach (int num2 in listNum2)
                {
                    if (num1 >= num2)
                    {
                        if (num1 - num2 < min)
                        {
                            min = num1 - num2;
                            minNum1 = num1;
                            minNum2= num2;
                        }
                    }
                    else
                    {
                        if (num2 - num1 < min)
                        {
                            min = num2 - num1;
                            minNum1 = num1;
                            minNum2 = num2;
                        }
                    }
                }
            }
            return min;
        }
    }
}
