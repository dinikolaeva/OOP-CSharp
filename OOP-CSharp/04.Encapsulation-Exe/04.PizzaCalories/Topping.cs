using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const string INVALID_WEIGHT = "{0} weight should be in the range [1..50].";

        private string typesOfToppings;
        private double weight;

        public Topping(string typesOfToppings, double weight)
        {
            this.TypesOfToppings = typesOfToppings;
            this.Weight = weight;
        }

        public string TypesOfToppings
        {
            get => this.typesOfToppings;
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.typesOfToppings = value;
            }

        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(String.Format(INVALID_WEIGHT, this.typesOfToppings));
                }
                this.weight = value;
            }

        }

        public double CalculateCalories()
        {
            double modifier = 1;

            switch (typesOfToppings.ToLower())
            {
                case "meat":
                    modifier *= 1.2;
                    break;
                case "veggies":
                    modifier *= 0.8;
                    break;
                case "cheese":
                    modifier = 1.1;
                    break;
                case "sauce":
                    modifier = 0.9;
                    break;
            }

            return (2 * this.weight) * modifier;
        }
    }
}
