using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            set
            {
                this.dough = value;
            }
        }

        public int NumberOfToppings { get => this.toppings.Count; }

        public double TottalCalories() => dough.CalculateCalories() + this.toppings.Sum(x => x.CalculateCalories());

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TottalCalories():f2} Calories.";
        }
    }
}
