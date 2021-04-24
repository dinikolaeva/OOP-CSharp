using _01.Vehicles.Models;
using _02.VehiclesExtension.Models;
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
            double tankCapacityCar = double.Parse(inputCar[3]);
            Vehicle car = new Car(fuelQuantityCar, fuelConsumptionCar,tankCapacityCar);

            string[] inputTruck = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();

            double fuelQuantityTruck = double.Parse(inputTruck[1]);
            double fuelConsumptionTruck = double.Parse(inputTruck[2]);
            double tankCapacityTruck = double.Parse(inputTruck[3]);
            Vehicle truck = new Truck(fuelQuantityTruck, fuelConsumptionTruck,tankCapacityTruck);

            string[] inputBus = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double fuelQuantityBus = double.Parse(inputBus[1]);
            double fuelConsumptionBus = double.Parse(inputBus[2]);
            double tankCapacityBus = double.Parse(inputBus[3]);
            Vehicle bus = new Bus(fuelQuantityBus, fuelConsumptionBus, tankCapacityBus);

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
                    else if (typeOfVehicle == "Bus")
                    {
                        bus.Driving(distanceOrLiters);
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
                    else if (typeOfVehicle == "Bus")
                    {
                        bus.Refueling(distanceOrLiters);
                    }
                }
                else if (typeOfOperation == "DriveEmpty")
                {
                    bus.DriveEmpty(distanceOrLiters);
                }
            }

            Console.WriteLine($"Car: {car.RemainingFuel()}");
            Console.WriteLine($"Truck: {truck.RemainingFuel()}");
            Console.WriteLine($"Bus: {bus.RemainingFuel()}");
        }
    }
}
