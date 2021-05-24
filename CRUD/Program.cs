using System;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.UtcNow.ToString("o"));
            Console.WriteLine(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day-1, 23, 0, 0).ToUniversalTime().ToString("o"));
            Console.WriteLine(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 3, 0, 0));
            Console.WriteLine(new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 0, 0, 0).ToUniversalTime().ToString("o"));
        }
    }
}
