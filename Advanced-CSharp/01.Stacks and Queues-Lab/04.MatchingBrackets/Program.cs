using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var expression = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];

                if (currentSymbol == '(')
                {
                    expression.Push(i);
                }
                else if (currentSymbol == ')')
                {
                    int startIndex = expression.Pop();
                    Console.WriteLine(input.Substring(startIndex,i-startIndex + 1));
                }
            }
        }
    }
}
