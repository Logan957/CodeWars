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
                    result = result.Append(keyValues[key] + " ");
                }

                return result.ToString().Trim();
            }

            /*
            7kyu Is this a triangle?

            Implement a method that accepts 3 integer values a, b, c.
            The method should return true if a triangle can be built with the sides of given length and false in any other case.
            (In this case, all triangles must have surface greater than 0 to be accepted). */

            //Console.WriteLine(IsTriangle(5, 7, 10));

            static bool IsTriangle(int a, int b, int c)
            {
                return a + b > c && a + c > b && c + b > a;
            }

            //7 kyu You're a square!

            //Given an integral number, determine if it's a square number:

            //Console.WriteLine(IsSquare(25));

            static bool IsSquare(int n)
            {
                for (int i = 0; i * i <= n; i++)
                {
                    if (i * i == n)
                    {
                        return true;
                    }
                }

                return false;

                //оказывается есть Math.Sqrt(n)
            }

            //6 kyu Valid Braces

            //What is considered Valid ?
            //A string of braces is considered valid if all braces are matched with the correct brace.

            //Console.WriteLine(validBraces("(((((("));
            static bool validBraces(String braces)
            {
                var ch = braces.ToCharArray();

                if (ch[0] != '(' && ch[0] != '[' && ch[0] != '{')
                {
                    return false;
                }

                if (ch[ch.Length - 1] != ')' && ch[ch.Length - 1] != '}' && ch[ch.Length - 1] != ']')
                {
                    return false;
                }

                for (int a = 0; a < ch.Length - 1; a++)
                {
                    switch (ch[a])
                    {
                        case '(':
                            if (ch[a + 1] == '}' || ch[a + 1] == ']')
                            { 
                                return false;
                            } 
                            break;
                        case '{':
                            if (ch[a + 1] == ')' || ch[a + 1] == ']')
                            {
                                return false;
                            }
                            break;
                        case '[':
                            if (ch[a + 1] == ')' || ch[a + 1] == '}')
                            {
                                return false;
                            }
                            break;
                    }
                }
                return true;

                // Через Replace, очень просто и красиво решается

            }
        }
    }
}
