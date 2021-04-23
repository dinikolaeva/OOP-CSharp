using _06.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public int Food { get; set; }

        public int BuyFood()
        {
            return this.Food = 10;
        }
    }
}
