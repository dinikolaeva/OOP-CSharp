namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double ConstCubicCentimeters = 5000;
        private const int MinHoresePower = 400;
        private const int MaxHoresePower = 600;        
        
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, ConstCubicCentimeters, MinHoresePower, MaxHoresePower)
        {
            //throw exception?
        }
    }
}
