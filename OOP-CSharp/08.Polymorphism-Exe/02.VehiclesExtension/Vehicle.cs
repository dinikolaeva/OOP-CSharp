using System;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private const double decreaseFuelConsumption = 95;

        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuel, double fuelConsumption, double tankCapacity)
        {
            if (fuel > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuel;
            }

            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public abstract void Driving(double distance);
        public virtual void DriveEmpty(double distance) 
        {

        }

        public virtual void Refueling(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }

            if (liters > this.TankCapacity - this.FuelQuantity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }

            if (liters > 0 && liters <= this.TankCapacity - this.FuelQuantity)
            {
                if (this.GetType().Name == "Truck")
                {
                    this.FuelQuantity += liters * decreaseFuelConsumption / 100.0;
                }
                else
                {
                    this.FuelQuantity += liters;
                }
            }
        }

        public virtual string RemainingFuel()
        {
            return $"{this.FuelQuantity:f2}";
        }
    }
}
