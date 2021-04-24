using _04.WildFarm.Animals;
using _04.WildFarm.Animals.Models;
using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WildFarm
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            var command = Console.ReadLine();
            List<Animal> animals = new List<Animal>();

            while (command != "End")
            {
                var cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Animal animal = CreateAnimal(cmdArg);
                animals.Add(animal);

                var foodInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Food food = CreateFood(foodInfo);

                Console.WriteLine(animal.ProducingSound());

                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString().TrimEnd());
            }
        }

        private Food CreateFood(string[] foodInfo)
        {
            Food food = null;

            var typeOfFood = foodInfo[0];
            var quantity = int.Parse(foodInfo[1]);

            if (typeOfFood == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (typeOfFood == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (typeOfFood == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (typeOfFood == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private Animal CreateAnimal(string[] cmdArg)
        {
            Animal animal = null;

            var type = cmdArg[0];
            var name = cmdArg[1];
            var weight = double.Parse(cmdArg[2]);

            if (type == nameof(Owl))
            {
                var wingSize = double.Parse(cmdArg[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Hen))
            {
                var wingSize = double.Parse(cmdArg[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Cat))
            {
                var livingRegion = cmdArg[3];
                var breed = cmdArg[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Dog))
            {
                var livingRegion = cmdArg[3];
                animal = new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Mouse))
            {
                var livingRegion = cmdArg[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Tiger))
            {
                var livingRegion = cmdArg[3];
                var breed = cmdArg[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }

            return animal;
        }
    }
}
