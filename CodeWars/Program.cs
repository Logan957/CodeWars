using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            6kyu Your order, please

            Your task is to sort a given string.Each word in the string will contain a single number. 
            This number is the position the word should have in the result.
            Note: Numbers can be from 1 to 9.So 1 will be the first word(not 0).
            If the input string is empty, return an empty string.
            The words in the input String will only contain valid consecutive numbers.*/

            //Console.WriteLine(Order("4of Fo1r pe6ople g3ood th5e the2"));

            static string Order(string words)
            {
                string[] wordArry = words.Split(' ');

                StringBuilder result = new StringBuilder(20);

                SortedDictionary<int, string> keyValues = new SortedDictionary<int, string>();

                foreach (string word in wordArry)
                {
                    foreach (char ch in word)
                    {
                        if (Char.IsDigit(ch))
                        {
                            keyValues.Add(ch, word);
                        }
                    }
                }

                foreach (int key in keyValues.Keys)
                {
                    result = result.Append(keyValues[key]+ " ");
                }

                return result.ToString().Trim();
            }
        }
    }
}
