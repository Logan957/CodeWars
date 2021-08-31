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

            /*
             6 kyu Title Case
            A string is considered to be in title case if each word in the string is either(a) capitalised (that is, only the first letter of the word is in upper case) 
            or(b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised.
            
            Write a function that will convert a string into title case, 
            given an optional list of exceptions(minor words).
            
            The list of minor words will be given as a string with each word separated by a space.
            Your function should ignore the case of the minor words string --it should behave in the same way even if the case of the minor word string is changed.*/

            //Console.WriteLine(TitleCase("ab", null));

            static string TitleCase(string title, string minorWords = "")
            {
                string[] splitTitle = title.Split(" ");

                if (minorWords == null)
                {
                    minorWords = "";
                }
                string[] splitMinorWords = minorWords.Split(" ");
                bool wasFirstWord = false;

                List<string> newTitle = new List<string>();

                foreach (string word in splitTitle)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        bool isMinorWord = false;

                        if (!wasFirstWord)
                        {
                            if (word == splitTitle[0])
                            {
                                string firstWord = word.ToLower();
                                newTitle.Add(Char.ToUpper(firstWord[0]) + firstWord.Substring(1));
                                wasFirstWord = true;

                                continue;
                            }
                        }

                        foreach (string minorWord in splitMinorWords)
                        {
                            if (word.ToLower() == minorWord.ToLower())
                            {
                                newTitle.Add(word.ToLower());
                                isMinorWord = true;

                                break;
                            }
                        }

                        if (!isMinorWord)
                        {
                            string newWord = word.ToLower();
                            newTitle.Add(Char.ToUpper(newWord[0]) + newWord.Substring(1));
                        }
                    }
                }

                return string.Join(" ", newTitle);

                //Очень плохое решение
            }

            //5 kyu Greed is Good
            //Greed is a dice game played with five six - sided dice.Your mission, should you choose to accept it, is to score a throw according to these rules.
            //You will always be given an array with five six-sided dice values.
            //A single die can only be counted once in each roll.
            //For example, a given "5" can only count as part of a triplet(contributing to the 500 points) or as a single 50 points, but not both in the same roll.

            //Console.WriteLine(Score(new int[] { 2, 4, 4, 5, 4 }));

            static int Score(int[] dice)
            {
                Dictionary<int, int> countNumbers = new Dictionary<int, int>();
                int sum = 0;

                foreach (int number in dice)
                {
                    if (countNumbers.ContainsKey(number))
                    {
                        countNumbers[number]++;
                    }
                    else
                    {
                        countNumbers.Add(number, 1);
                    }
                }

                foreach (int key in countNumbers.Keys)
                {
                    switch (key)
                    {
                        case 1:
                            sum += countNumbers[key] / 3 * 1000 + countNumbers[key] % 3 * 100;
                            break;
                        case 2:
                            sum += countNumbers[key] / 3 * 200;
                            break;
                        case 3:
                            sum += countNumbers[key] / 3 * 300;
                            break;
                        case 4:
                            sum += countNumbers[key] / 3 * 400;
                            break;
                        case 5:
                            sum += countNumbers[key] / 3 * 500 + countNumbers[key] % 3 * 50;
                            break;
                        case 6:
                            sum += countNumbers[key] / 3 * 600;
                            break;
                    }

                }

                return sum;
                // Нормальное решение, но через LINQ очень красиво решается 
            }

            //6 kyu Sum of Digits / Digital Root
            //Digital root is the recursive sum of all the digits in a number.
            //Given n, take the sum of the digits of n.
            //If that value has more than one digit, continue reducing in this way until a single-digit number is produced.
            //The input will be a non-negative integer.

            //Console.WriteLine(DigitalRoot(493193));

            static int DigitalRoot(long n)
            {
                long result = n % 9;

                return (result == 0 && n > 0) ? 9 : Convert.ToInt32(result);
            }

            //5 kyu Maximum subarray sum
            //The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:
            //Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array.
            //If the list is made up of only negative numbers, return 0 instead.

            Console.WriteLine(MaxSequence(new int[] {-4, 21, 0, 2, -29, -10, 17, 15, -24, 23, 19,
-16, -25, 16, 10, 28, 15, -7, -7, -14, 4, 7,
-22, -15, -19, 27, -8, -7, -19, -20, -12, 23,
25, 0, -22, -8, -26, 2, 14, 26, 0, 9, -19, -8,
-20, 21, 10, 19, 14, 14 }));

            static int MaxSequence(int[] arr)
            {
                if (arr == null || arr.Length == 0 || arr.Max() <= 0)
                {
                    return 0;
                }
                int maxResult = 0;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] > 0)
                    {
                        int maxLeftResult = 0;
                        int maxRightResult = 0;
                        int leftSum = 0;
                        int rightSum = 0;

                        for (int j = i - 1; j >= 0; j--)
                        {
                            leftSum += arr[j];

                            if (leftSum > maxLeftResult)
                            {
                                maxLeftResult = leftSum;
                            }
                        }

                        for (int j = i + 1; j < arr.Length; j++)
                        {
                            rightSum += arr[j];

                            if (rightSum > maxRightResult)
                            {
                                maxRightResult = rightSum;
                            }
                        }

                        if (arr[i] + maxLeftResult + maxRightResult > maxResult)
                        {
                            maxResult = arr[i] + maxLeftResult + maxRightResult;
                        }
                    }
                }

                return maxResult;
            }
        }
    }
}
