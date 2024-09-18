using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLibrary1
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int intervalsRows = Convert.ToInt32(Console.ReadLine().Trim());
            int intervalsColumns = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> intervals = new List<List<int>>();

            for (int i = 0; i < intervalsRows; i++)
            {
                intervals.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(intervalsTemp => Convert.ToInt32(intervalsTemp)).ToList());
            }

            //List<List<int>> result = Result.getMergedIntervals(intervals);

            textWriter.WriteLine(String.Join("\n", intervals.Select(x => String.Join(" ", x))));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
