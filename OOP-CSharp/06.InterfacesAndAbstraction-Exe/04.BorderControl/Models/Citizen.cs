﻿using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl.Models
{
    public class Citizen : Id
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Name { get; set ; }
        public int Age { get ; set ; }
        public string Id { get ; set; }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}