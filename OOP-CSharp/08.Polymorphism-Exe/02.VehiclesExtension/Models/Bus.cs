using _01.Vehicles;
using System;

namespace _02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double increaseConsumptionForBus = 1.4;

        public Bus(double fuel, double fuelConsumption, double tankCapacity)
            : base(fuel, fuelConsumption, tankCapacity)
        {

        }

        public override void Driving(double distance)
        {
            double finalConsumption = this.FuelConsumption + increaseConsumptionForBus;
            double fuelNeeded = finalConsumption * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
                this.FuelQuantity -= fuelNeeded;

            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public override void DriveEmpty(double distance)
        {
            double fuelNeeded = this.FuelConsumption * distance;

            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
    }
}
