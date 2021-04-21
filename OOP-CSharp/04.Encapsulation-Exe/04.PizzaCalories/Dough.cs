using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {        
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && 
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }
                this.weight = value;
            }
        }

        public double CalculateCalories()
        {
            double modifier = 1;

            switch (flourType.ToLower())
            {
                case "white":
                    modifier *= 1.5;
                    break;
                case "wholegrain":
                    modifier *= 1.0;
                    break;
            }
            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    modifier *= 0.9;
                    break;
                case "chewy":
                    modifier *= 1.1;
                    break;
                case "homemade":
                    modifier *= 1.0;
                    break;
            }

            return (2 * weight) * modifier;
        }
    }
}
