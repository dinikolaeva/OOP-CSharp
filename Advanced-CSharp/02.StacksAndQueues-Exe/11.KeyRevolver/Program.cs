using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBulet = int.Parse(Console.ReadLine());
            int sizeOfGunBarell = int.Parse(Console.ReadLine());
            var bulletsInput = Console.ReadLine()
                                      .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();
            var locksInput = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());

            var bulletsStack = new Stack<int>(bulletsInput);
            var locksQueue = new Queue<int>(locksInput);

            var countOfBulletsBurned = 0;
            var currentBarrel = sizeOfGunBarell;

            while (bulletsStack.Count != 0 && locksQueue.Count != 0)
            {
                if (bulletsStack.Pop() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                currentBarrel--;
                countOfBulletsBurned++;

                if (currentBarrel == 0 && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    currentBarrel = sizeOfGunBarell;
                }
            }

            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                var moneyEarned = intelligenceValue - (countOfBulletsBurned * priceOfBulet);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
