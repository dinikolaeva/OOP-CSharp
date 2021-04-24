namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity{ get; set; }
        public double FuelConsumption { get; set; }

        public abstract void Driving(double distance);

        public abstract void Refueling(double liters);

        public virtual string RemainingFuel()
        {
            return $"{this.FuelQuantity:f2}";
        }
    }
}
