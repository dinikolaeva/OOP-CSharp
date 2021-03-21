using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();

            int counter = 0;

            for (int i = 0; i < n; i++)
            {
                int[] pumpInfo = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                pumps.Enqueue(pumpInfo);
            }

            while (true)
            {
                int fuelAmount = 0;
                bool isFound = true;
                
                for (int i = 0; i < n; i++)
                {
                    int[] currentPump = pumps.Dequeue();
                    int currentFuel = currentPump[0];
                    int currentDistace = currentPump[1];

                    fuelAmount += currentFuel;

                    if (fuelAmount < currentDistace)
                    {
                        isFound = false;
                    }

                    fuelAmount -= currentDistace;

                    pumps.Enqueue(currentPump);
                }

                if (isFound)
                {
                    break;
                }

                counter++;

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(counter);
        }
    }
}
