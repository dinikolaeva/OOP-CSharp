using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Models
{
    public class Hen : Bird
    {
        private const double HEN_MODIFIER = 0.35;
        private static HashSet<string> ALLOWED_FOODS = new HashSet<string>()
        {
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Meat),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, ALLOWED_FOODS, HEN_MODIFIER)
        {

        }

        public override string ProducingSound()
        {
            return $"Cluck";
        }
    }
}
