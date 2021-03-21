using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] operations = Console.ReadLine().Split();
            string[] input = Console.ReadLine().Split();

            var queue = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                queue.Enqueue(int.Parse(input[i]));
            }

            int popElements = int.Parse(operations[1]);

            for (int i = 0; i < popElements; i++)
            {
                queue.Dequeue();
            }

            int isElementExist = int.Parse(operations[2]);

            if (queue.Contains(isElementExist))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine($"{queue.Min()}");
                }
            }
        }
    }
}
