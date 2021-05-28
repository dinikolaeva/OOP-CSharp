namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double ConstCubicCentimeters = 3000;
        private const int MinHoresePower = 250;
        private const int MaxHoresePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, ConstCubicCentimeters, MinHoresePower, MaxHoresePower)
        {
        }
    }
}
