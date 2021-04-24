using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Models
{
    public class Tiger : Feline
    {
        private const double TIGER_MODIFIER = 1.00;
        private static HashSet<string> ALLOWED_FOODS = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, ALLOWED_FOODS, TIGER_MODIFIER)
        {

        }

        public override string ProducingSound()
        {
            return $"ROAR!!!";
        }
    }
}
