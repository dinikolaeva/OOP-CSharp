using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int counting = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();

            for (int i = 0; i < names.Length; i++)
            {
                queue.Enqueue(names[i]);
            }

            while (queue.Count > 1)
            {
                for (int i = 1; i < counting; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
