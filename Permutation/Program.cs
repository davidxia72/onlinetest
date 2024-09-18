// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.Collections;
using Permutation_combination;


Calculation calculation = new Calculation();
// combination
int[] arr =  { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<List<int>>  returnedList = calculation.CombinateList(arr, arr.Length, 5);
// permutation 
int min = 100000;
int minNum1 = 0;
int minNum2 = 0;
foreach (List<int> seq1 in returnedList)
{
    List<int> seq2 = arr.ToList().Except(seq1).ToList();
    IEnumerable<IList> list1 = calculation.PermutateList(seq1, seq1.Count);
    IEnumerable<IList> list2 = calculation.PermutateList(seq2, seq2.Count);
    int refminNum1 = 0;
    int refminNum2 = 0;
    int returnMin = calculation.GetMin(list1, list2, ref refminNum1, ref refminNum2);
    if (min > returnMin)
    {
        min = returnMin;
        minNum1 = refminNum1;
        minNum2 = refminNum2;
    }
}
Console.WriteLine(min.ToString());
Console.WriteLine(minNum1.ToString());
Console.WriteLine(minNum2.ToString());
