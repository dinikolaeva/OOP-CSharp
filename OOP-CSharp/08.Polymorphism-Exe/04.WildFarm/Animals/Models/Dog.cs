using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Models
{
    public class Dog : Mammal
    {
        private const double DOG_MODIFIER = 0.40;
        private static HashSet<string> ALLOWED_FOODS = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, ALLOWED_FOODS, DOG_MODIFIER)
        {
        }

        public override string ProducingSound()
        {
            return $"Woof!";
        }
    }
}
