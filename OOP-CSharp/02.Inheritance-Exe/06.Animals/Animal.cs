﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public string Gender
        {
            get => gender;
            set
            {
                if (!IsGenderValid(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        private bool IsGenderValid(string value)
        {
            if (value == "Female" || value == "Male")
            {
                return true;
            }
            return false;
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine(ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
