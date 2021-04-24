using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Models
{
    public class Owl : Bird
    {
        private const double OWL_MODIFIER = 0.25;
        private static HashSet<string> ALLOWED_FOODS = new HashSet<string>()
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, ALLOWED_FOODS, OWL_MODIFIER)
        {

        }

        public override string ProducingSound()
        {
            return $"Hoot Hoot";
        }
    }
}
