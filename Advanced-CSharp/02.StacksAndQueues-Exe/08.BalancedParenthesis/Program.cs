using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> parentheses = new Stack<char>();

            bool isBalanced = true;

            foreach (char ch in input)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    parentheses.Push(ch);
                }
                else
                {
                    if (parentheses.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    char openBreckets = parentheses.Pop();
                    bool isRound = openBreckets == '(' && ch == ')';
                    bool isSqare = openBreckets == '[' && ch == ']';
                    bool isCurl = openBreckets == '{' && ch == '}';

                    if (isRound == false && isSqare == false && isCurl == false)
                    {
                        isBalanced = false;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
