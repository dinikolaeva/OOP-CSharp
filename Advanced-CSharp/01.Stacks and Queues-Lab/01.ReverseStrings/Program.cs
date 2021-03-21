using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> symbols = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];
                symbols.Push(symbol);
            }

            StringBuilder sb = new StringBuilder();

            while (symbols.Count > 0)
            {
                char letter = symbols.Pop();
                sb.Append(letter);
            }

            Console.WriteLine(sb);
        }
    }
}
