using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CsharpStack alist = new CsharpStack();
            string ch;
            string word = "eye";
            bool isPalindrome = true;
            for (int x = 0; x < word.Length; x++)
                alist.push(word.Substring(x, 1));
            int pos = 0;
            while (alist.count > 0)
            {
                ch = alist.pop().ToString();
                if (ch != word.Substring(pos, 1))
                {
                    isPalindrome = false;
                    break;
                }
                pos++;
            }
            if (isPalindrome)
                Console.WriteLine(word + " is a palindrome.");
            else
                Console.WriteLine(word + " is not a palindrome.");
            Console.Read();
        }
    }
}
