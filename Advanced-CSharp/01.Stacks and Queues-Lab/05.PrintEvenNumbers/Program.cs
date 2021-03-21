using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            List<int> evenNums = new List<int>();

            while (queue.Count > 0)
            {
                queue.Peek();
                var currentNum = queue.Dequeue();

                if (currentNum % 2 == 0)
                {
                    evenNums.Add(currentNum);
                }
            }

            Console.WriteLine(String.Join(", ", evenNums));
        }
    }
}
