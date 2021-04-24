using System.Collections.Generic;

namespace _04.WildFarm.Animals
{
    public abstract class Feline : Animal
    {
        protected Feline(string name, double weight, string livingRegion, string breed, HashSet<string> allowedFoods, double weightModifier) 
            : base(name, weight, allowedFoods, weightModifier)
        {
            this.LivingRegion = livingRegion;
            this.Breed = breed;
        }

        public string LivingRegion { get; set; }
        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()}{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
