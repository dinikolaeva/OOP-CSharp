using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations.Models
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get ; set ; }

        public override string ToString()
        {
            return $"{this.Birthdate}";
        }
    }
}
