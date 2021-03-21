using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string actionOrCar = Console.ReadLine();

            int countOfCarsPass = 0;
            char crashedChar = '0';
            bool isCrashed = false;

            while (actionOrCar != "END")
            {
                int passDuration = greenLightDuration;

                if (actionOrCar == "green")
                {
                    if (cars.Count > 0)
                    {
                        while (passDuration >= 0 && cars.Count > 0)
                        {
                            if (passDuration > cars.Peek().Length)
                            {
                                passDuration -= cars.Peek().Length;
                                cars.Dequeue();
                                countOfCarsPass++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (passDuration > 0 && cars.Count > 0)
                        {
                            if (passDuration + freeWindow >= cars.Peek().Length)
                            {
                                countOfCarsPass++;
                            }
                            else
                            {
                                int index = passDuration + freeWindow;
                                crashedChar = cars.Peek()[index];
                                isCrashed = true;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(actionOrCar);
                }

                actionOrCar = Console.ReadLine();
            }

            if (isCrashed)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{cars.Dequeue()} was hit at {crashedChar}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countOfCarsPass} total cars passed the crossroads.");
            }
        }
    }

}

