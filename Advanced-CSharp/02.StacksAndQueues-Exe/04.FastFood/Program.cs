using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                                  .Split()
                                  .Select(int.Parse)
                                  .ToArray();

            var queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                int currentOrder = queue.Peek();

                if (quantityOfFood >= currentOrder)
                {
                    queue.Dequeue();
                    quantityOfFood -= currentOrder;
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
