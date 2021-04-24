using _01.Vehicles.Models;
using System;
using System.Linq;

namespace _01.Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] inputCar = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            double fuelQuantityCar = double.Parse(inputCar[1]);
            double fuelConsumptionCar = double.Parse(inputCar[2]);
            Vehicle car = new Car(fuelQuantityCar, fuelConsumptionCar);

            string[] inputTruck = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            double fuelQuantityTruck = double.Parse(inputTruck[1]);
            double fuelConsumptionTruck = double.Parse(inputTruck[2]);
            Vehicle truck = new Truck(fuelQuantityTruck, fuelConsumptionTruck);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var typeOfOperation = command[0];
                var typeOfVehicle = command[1];
                var distanceOrLiters = double.Parse(command[2]);

                if (typeOfOperation == "Drive")
                {
                    if (typeOfVehicle == "Car")
                    {
                        car.Driving(distanceOrLiters);
                    }
                    else if (typeOfVehicle == "Truck")
                    {
                        truck.Driving(distanceOrLiters);
                    }
                }
                else if (typeOfOperation == "Refuel")
                {
                    if (typeOfVehicle == "Car")
                    {
                        car.Refueling(distanceOrLiters);
                    }
                    else if (typeOfVehicle == "Truck")
                    {
                        truck.Refueling(distanceOrLiters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.RemainingFuel()}");
            Console.WriteLine($"Truck: {truck.RemainingFuel()}");
        }
    }
}
