using System;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double increaseConsumptionForTruck = 1.6;
        private const double decreaseFuelConsumption = 95;

        public Truck(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {

        }

        public override void Driving(double distance)
        {
            double finalConsumption = this.FuelConsumption + increaseConsumptionForTruck;
            double fuelNeeded = finalConsumption * distance;

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
