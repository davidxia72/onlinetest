using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static int NO_OF_CHARS = 256;
        static void Main(string[] args)
        {
            string userinput = Console.ReadLine();
            // a word, number, phrase, or other sequence of characters which reads the same backward as forward, such as madam or racecar.
            if (userinput == "palindrome")
                Identify_palindrome();
            //https://www.geeksforgeeks.org/check-whether-two-strings-are-anagram-of-each-other/ 
            //An anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once
            else if (userinput == "anagram")
            {
               // char[] str1 = ("geeksforgeeks").ToCharArray();
               // char[] str2 = ("gorgeeksgeeks").ToCharArray();
                char[] str1 = ("eleven plus two").ToCharArray();
                char[] str2 = ("twelve plus one").ToCharArray();

                // Function Call
                if (areAnagram(str1, str2))
                    Console.WriteLine("The two strings are"
                                      + "anagram of each other");
                else
                    Console.WriteLine("The two strings are not"
                                      + " anagram of each other");
                // log(n)
                if (areAnagram2(str1, str2))
                    Console.WriteLine("The two strings are"
                                      + "anagram of each other");
                else
                    Console.WriteLine("The two strings are not"
                                      + " anagram of each other");
            }
            //Identify_palindrome();
            else if (userinput == "stack")
            {
                Operate_Stack();
            }
            else if (userinput == "common")
            {
                string str = FindCommonLetters("you", "your");
                Console.WriteLine(str);
            }

            else if (userinput == "commonWords")
            {
                string[] str = FindCommonWord("xia,david logan,john martin,mar", "xia,david thomas,matthew martin,mar");
                Console.WriteLine(str);
            }

            else if (userinput == "reverse")
            {
                string str = ReverseSentence("funk you");
                Console.WriteLine(str);
                // reverse words
                str = ReverseWords(str);
                Console.WriteLine(str);
                str = ReverseWords3(str);
                Console.WriteLine(str);
            }
            else if (userinput == "rotate")
            {
                int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int n = arr.Length;
                int d = 8;

                leftRotate(arr, d); // Rotate array by 2
                printArray(arr);

                arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                //rightRotate(arr, d); // Rotate array by 2
                leftRotate(arr, arr.Length - d);
                // Array.Reverse(arr);
                printArray(arr);
            }
            else if (userinput == "duplicate")
            {
                string str = "adjfkdffjfdorffg";
                char[] arr = str.ToCharArray();
                List<char> list = arr.ToList();
                List<char> list_no_dup = list.Distinct().ToList();
                arr = list_no_dup.ToArray();
                Console.WriteLine(new string(arr));
                str = "adjfkdffjfdorffg";
                list = new List<char>();
                foreach (char c in str)
                {
                    if (!list.Contains(c))
                        list.Add(c);
                }
                Console.WriteLine(new string(list.ToArray()));
            }
            Console.ReadKey();
        }

        static bool areAnagram(char[] str1, char[] str2)
        {
            // Create 2 count arrays and initialize
            // all values as 0
            int[] count1 = new int[NO_OF_CHARS];
            int[] count2 = new int[NO_OF_CHARS];
            int i;

            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (i = 0; i < str1.Length && i < str2.Length;
                 i++)
            {
                count1[str1[i]]++;
                count2[str2[i]]++;
            }

            // If both strings are of different length.
            // Removing this condition will make the program
            // fail for strings like "aaca" and "aca"
            if (str1.Length != str2.Length)
                return false;

            // Compare count arrays
            for (i = 0; i < NO_OF_CHARS; i++)
                if (count1[i] != count2[i])
                    return false;

            return true;
        }

        static bool areAnagram2(char[] str1, char[] str2)
        {
            // Create 2 count arrays and initialize
            // all values as 0
            //Extended ASCII Codes, https://www.asciitable.com/
            int[] count1 = new int[NO_OF_CHARS];
            int i;

            // For each character in input strings,
            // increment count in the corresponding
            // count array
            for (i = 0; i < str1.Length && i < str2.Length;
                 i++)
            {
                count1[str1[i]]++;
                count1[str2[i]]--;
            }

            // If both strings are of different length.
            // Removing this condition will make the program
            // fail for strings like "aaca" and "aca"
            if (str1.Length != str2.Length)
                return false;

            // Compare count arrays
            for (i = 0; i < NO_OF_CHARS; i++)
                if (count1[i] != 0)
                {
                    return false;
                }

            return true;
        }
        static void leftRotate(int[] arr, int d)
        {

            if (d == 0)
                return;
            int n = arr.Length;
            // in case the rotating factor is
            // greater than array length
            d = d % n;
            reverseArray(arr, 0, d - 1);
            reverseArray(arr, d, n - 1);
            reverseArray(arr, 0, n - 1);
        }

        static void rightRotate(int[] arr, int d)
        {

            if (d == 0)
                return;
            int n = arr.Length;
            // in case the rotating factor is
            // greater than array length
            d = d % n;
            reverseArray(arr, n-1-d + 1, n-1);
            reverseArray(arr, 0, n-d-1);
            reverseArray(arr,  n - 1, 0);
        }
        static void reverseArray(int[] arr, int start,
                             int end)
        {
            int temp;
            while (start < end)
            {
                temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }
        }

        /*UTILITY FUNCTIONS*/
        /* function to print an array */
        static void printArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("");
        }
        static string ReverseWords(string words)
        {
            string[] stringArray = words.Split(' ');
            List<string> reverseWords = new List<string>();
            foreach (string str in stringArray)
            {
                char[] charArray = str.ToCharArray();
                IEnumerable<char> reverseWord = charArray.Reverse();
                reverseWords.Add(new string(reverseWord.ToArray()));
            }
            return String.Join(" ", reverseWords);
        }

        static string ReverseWords2(string str)
        {
            char[] chars = str.ToCharArray();
            char[] result = new char[chars.Length];
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                result[i] = chars[j];
            }
            return new string(result);
        }
        // half of string length
        static string ReverseWords3(string words)
        {
            string[] stringArray = words.Split(' ');
            List<string> reverseWords = new List<string>();
            foreach (string str in stringArray)
            {
                char[] chars = str.ToCharArray();
                for (int i = 0, j = str.Length - 1; i < j; i++, j--)
                {
                    char c = chars[i];
                    chars[i] = chars[j];
                    chars[j] = c;
                }
                reverseWords.Add(new string(chars));
            }
            return String.Join(" ", reverseWords);
        }

        static string ReverseSentence(string sentence)
        {
            string[] stringArray = sentence.Split(' ');
            // reverse items in an array
            IEnumerable<string> reverseWords = stringArray.Reverse();
            // convert array to a string, separated by “ ”
            return String.Join(" ", reverseWords);
        }

        // Write a function f(a, b) which takes two character string arguments and returns a string containing only the characters found in both strings.
        public static string FindCommonLetters(string a, string b)
        {
            // use Dictionary as HashTable to reduce running time to O(n)
            Dictionary<char, bool> dictionary = new Dictionary<char, bool>();
            foreach (char c in a)
            {   // put char as key
                if (!dictionary.ContainsKey(c))  // prevent duplicate key
                    dictionary.Add(c, false);
            }
            // if a char is in both a and b string, set value to be true
            foreach (char c in b)
            {
                if (dictionary.ContainsKey(c))
                    dictionary[c] = true;
            }
            // use linq return keys with value equal to true
            var returnStr =
                (from p in dictionary
                 where p.Value == true
                 select p.Key);
            return new string(returnStr.ToArray());
        }


        public static string[] FindCommonWord(string a, string b)
        {
            // use Dictionary as HashTable to reduce running time to O(n)
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            string[] arr1 = a.Split(" ");
            string[] arr2 = b.Split(" ");
            foreach (string c in arr1)
            {   // put char as key
                if (!dictionary.ContainsKey(c))  // prevent duplicate key
                    dictionary.Add(c, false);
            }
            // if a char is in both a and b string, set value to be true
            foreach (string c in arr2)
            {
                if (dictionary.ContainsKey(c))
                    dictionary[c] = true;
            }
            // use linq return keys with value equal to true
            var returnStr =
                (from p in dictionary
                 where p.Value == true
                 select p.Key);
            return returnStr.ToArray();
        }


        static void Operate_Stack()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("1");
            stack.Push("2");
            stack.Push("3");
            while (true)
            {
                if (stack.Peek() != null)
                {
                    Console.WriteLine("the stack is not empty, " + stack.Peek());
                    Console.WriteLine(stack.Pop());
                }
                else
                {
                    Console.WriteLine("the stack is empty, nothing to pop: " + stack.Peek());
                }
            }
        }
        static void Identify_palindrome()
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
