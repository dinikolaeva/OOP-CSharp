using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var symbols = new Stack<string>(input.Reverse());

            while (symbols.Count > 1)
            {
                int leftDigit = int.Parse(symbols.Pop());
                char operation = char.Parse(symbols.Pop());
                int rightDigit = int.Parse(symbols.Pop());

                if (operation == '+')
                {
                    symbols.Push((leftDigit + rightDigit).ToString());
                }
                else if (operation == '-')
                {
                    symbols.Push((leftDigit - rightDigit).ToString());
                }
            }

            Console.WriteLine(symbols.Pop());
        }
    }
}
