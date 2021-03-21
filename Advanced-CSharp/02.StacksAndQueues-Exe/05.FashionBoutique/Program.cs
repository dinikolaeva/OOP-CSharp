using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine()
                                   .Split()
                                   .Select(int.Parse)
                                   .ToArray();

            int capacityOfARack = int.Parse(Console.ReadLine());
            var stack = new Stack<int>(clothes);

            int sum = 0;
            int countOfFullRacks = 1;

            while (stack.Count > 0)
            {
                sum += stack.Peek();

                if (sum <= capacityOfARack)
                {
                    stack.Pop();
                }
                else
                {
                    countOfFullRacks++;
                    sum = 0;
                }
            }

            Console.WriteLine(countOfFullRacks);
        }
    }
}
