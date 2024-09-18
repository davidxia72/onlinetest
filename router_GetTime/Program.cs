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



class Result
{

    /*
     * Complete the 'getTime' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static long getTime(string s)
    {
        int[] arr = new int[25];
        int ptr = 0;
        int cost = 0;
        char[] input = s.ToCharArray();
        foreach (char c in input)
        {
            int dest = c - 'A';
            int cw = ptr > dest ? (dest + 26 - ptr) : dest - ptr;
            int acw = ptr < dest ? (ptr + 26 - dest) : ptr - dest;
            cost = cost + Math.Min(cw, acw);
            ptr = dest;
        }
        return Convert.ToInt64(cost);
        //return cost;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long result = Result.getTime(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
