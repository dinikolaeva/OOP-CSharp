using System;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private double increaseFuelConsumption = 1.6;
        private double decreaseFuelConsumption = 95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override void Driving(double distance)
        {
            double finalConsumption = this.FuelConsumption + increaseFuelConsumption;
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

        public override void Refueling(double liters)
        {
            this.FuelQuantity += liters * decreaseFuelConsumption / 100.0;
        }
    }
}
