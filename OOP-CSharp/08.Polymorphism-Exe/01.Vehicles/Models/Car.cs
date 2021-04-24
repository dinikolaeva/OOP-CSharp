using System;

namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private double increaseFuelConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        public override void Driving(double distance)
        {
            double finalConsumption = this.FuelConsumption + increaseFuelConsumption;
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

        public override void Refueling(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
