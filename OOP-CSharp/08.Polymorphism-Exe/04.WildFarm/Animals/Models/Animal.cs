using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFoods,double weightModifier)
        {
            this.Name = name;
            this.Weight = weight;
            this.AllowedFoods = allowedFoods;
            this.WeightModifier = weightModifier;
        }

        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        private HashSet<string> AllowedFoods { get;}
        private double WeightModifier { get; set; }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract string ProducingSound();

        public void Eat(Food food) 
        {
            string cuurentFood = food.GetType().Name;

            if (!AllowedFoods.Contains(cuurentFood))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {cuurentFood}!");
            }

            this.FoodEaten += food.Quantity;

            this.Weight += this.WeightModifier * food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
