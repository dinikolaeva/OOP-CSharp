using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] operations = Console.ReadLine().Split();
            string[] input = Console.ReadLine().Split();

            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(int.Parse(input[i]));
            }

            int popElements = int.Parse(operations[1]);

            for (int i = 0; i < popElements; i++)
            {
                stack.Pop();
            }

            int isElementExist = int.Parse(operations[2]);

            if (stack.Contains(isElementExist))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine($"{stack.Min()}");
                }
            }
        }
    }
}
