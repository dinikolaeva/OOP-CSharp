using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] commands = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                if (commands[0] == 1)
                {
                    int element = commands[1];
                    stack.Push(element);
                }
                else if (commands[0] == 2 && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (commands[0] == 3 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (commands[0] == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.Write(string.Join(", ", stack));
        }
    }
}
