using System;
using System.Collections.Generic;
using System.Linq;

namespace StringOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string userinput1 = Console.ReadLine();
            string userinput2 = Console.ReadLine();
            Dictionary<char, int> dictionary = new Dictionary<char, int>();
            Dictionary<char, int> dictionary2 = new Dictionary<char, int>();
            char[] char_array = userinput1.ToCharArray();
            foreach (char c in char_array)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary.Add(c, 1);
                }
                else
                {
                    dictionary[c] = dictionary[c] + 1;
                }

            }
            char[] chay_array2 = userinput2.ToCharArray();
            {
                foreach (char c in chay_array2)
                {
                    if (!dictionary2.ContainsKey(c))
                    {
                        dictionary2.Add(c, 1);
                    }
                    else
                    {
                        dictionary2[c] = dictionary2[c] + 1;
                    }
                }
            }
            // compare two dictionary
            if (new DictionaryComparer<char, int>().Equals(dictionary, dictionary2))
                Console.WriteLine("two strings are made from the same chars");
            else
                Console.WriteLine("two strings are NOT made from the same chars");
        }

        public static bool Equals(Dictionary<char, int> x, Dictionary<char, int> y)
        {
            if (x.Count != y.Count)
                return false;
            if (x.Keys.Except(y.Keys).Any())
                return false;
            if (y.Keys.Except(x.Keys).Any())
                return false;
            foreach (var pair in x)
                if (pair.Value !=  y[pair.Key])
                    return false;
            return true;
        }
    }
}
