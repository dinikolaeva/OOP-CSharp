using _06.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    public class Rable : IBuyer
    {
        public Rable(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }

        public int BuyFood()
        {
            return this.Food = 5;
        }
    }
}
