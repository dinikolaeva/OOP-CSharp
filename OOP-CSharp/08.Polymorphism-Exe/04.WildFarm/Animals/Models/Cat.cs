using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Models
{
    public class Cat : Feline
    {
        private const double CAT_MODIFIER = 0.30;
        private static HashSet<string> ALLOWED_FOODS = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Meat)
        };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, ALLOWED_FOODS, CAT_MODIFIER)
        {

        }

        public override string ProducingSound()
        {
            return $"Meow";
        }
    }
}
