using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _06.FoodShortage.Interfaces;
using _06.FoodShortage.Models;

namespace _06.FoodShortage.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            List<Citizen> citizens = new List<Citizen>();
            List<Rable> rables = new List<Rable>();
            int food = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();

                var name = input[0];
                var age = int.Parse(input[1]);

                if (input.Length == 4)
                {
                    var id = input[2];
                    var birthdate = input[3];

                    var newCitizen = new Citizen(name, age, id, birthdate);
                    citizens.Add(newCitizen);
                }
                else if (input.Length == 3)
                {
                    var group = input[2];
                    var newRabel = new Rable(name, age, group);
                    rables.Add(newRabel);
                }
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var citizen in citizens)
                {
                    if (citizen.Name == command)
                    {
                        food += citizen.BuyFood();
                    }
                }

                foreach (var rabel in rables)
                {
                    if (rabel.Name == command)
                    {
                        food += rabel.BuyFood();
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(food);
        }
    }
}
