using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Models
{
    public class Mouse : Mammal
    {
        private const double MOUSE_MODIFIER = 0.10;
        private static HashSet<string> ALLOWED_FOODS = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Fruit)
        };

        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion, ALLOWED_FOODS, MOUSE_MODIFIER)
        {

        }

        public override string ProducingSound()
        {
            return $"Squeak";
        }
    }
}
