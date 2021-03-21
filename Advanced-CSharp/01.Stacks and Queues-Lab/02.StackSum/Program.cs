using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] integers = Console.ReadLine().Split();

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < integers.Length; i++)
            {
                int number = int.Parse(integers[i]);
                numbers.Push(number);
            }

            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] actions = input
                    .Split()
                    .ToArray();

                string command = actions[0];
                int digit1 = int.Parse(actions[1]);

                if (command == "add")
                {
                    int digit2 = int.Parse(actions[2]);
                    numbers.Push(digit1);
                    numbers.Push(digit2);
                }
                else if (command == "remove")
                {
                    if (numbers.Count > digit1)
                    {
                        for (int i = 0; i < digit1; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
