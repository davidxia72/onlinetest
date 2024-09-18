using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class sortHelper : IComparer
{
    int IComparer.Compare(object a, object b)
    {
        Interval first = (Interval)a;
        Interval second = (Interval)b;
        if (first.start == second.start)
        {
            return first.end - second.end;
        }
        return first.start - second.start;
    }
}
public class Interval
{
    public int start, end;
    public Interval(int start, int end)
    {
        this.start = start;
        this.end = end;
    }
}
class Result
{

    /*
     * Complete the 'getMergedIntervals' function below.
     *
     * The function is expected to return a 2D_INTEGER_ARRAY.
     * The function accepts 2D_INTEGER_ARRAY intervals as parameter.
     */

    public static List<List<int>> getMergedIntervals(List<List<int>> intervals)
    {
        Interval[] arr = new Interval[intervals.Count];
        int count = 0;
        foreach (List<int> interval in intervals)
        {
            arr[count] = new Interval(interval[0], interval[1]);
            count++;
        }
        Array.Sort(arr, new sortHelper());
        Stack stack = new Stack();

        // Push the first interval to stack
        stack.Push(arr[0]);

        // Start from the next interval and merge if necessary
        for (int i = 1; i < arr.Length; i++)
        {

            // get interval from stack top
            Interval top = (Interval)stack.Peek();

            // if current interval is not overlapping with stack top,
            // Push it to the stack
            if (top.end < arr[i].start)
                stack.Push(arr[i]);

            else if (top.end < arr[i].end)
            {
                top.end = arr[i].end;
                stack.Pop();
                stack.Push(top);
            }
        }
        //return stack
        List<List<int>> returnList = new List<List<int>>();
        while (stack.Count != 0)
        {
            Interval t = (Interval)stack.Pop();
            List<int> item = new List<int>();
            item.Add(t.start);
            item.Add(t.end);
            returnList.Add(item);
        }
        returnList.Reverse();
        return returnList;
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("output.txt", true);

        int intervalsRows = Convert.ToInt32(Console.ReadLine().Trim());
        int intervalsColumns = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> intervals = new List<List<int>>();

        for (int i = 0; i < intervalsRows; i++)
        {
            intervals.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(intervalsTemp => Convert.ToInt32(intervalsTemp)).ToList());
        }

        List<List<int>> result = Result.getMergedIntervals(intervals);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
