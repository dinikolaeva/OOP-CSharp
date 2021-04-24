using System;

namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double increaseConsumptionForCar = 0.9;

        public Car(double fuel, double fuelConsumption, double tankCapacity) 
            : base(fuel, fuelConsumption, tankCapacity)
        {

        }

        public override void Driving(double distance)
        {
            double finalConsumption = this.FuelConsumption + increaseConsumptionForCar;
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
    }
}
