using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string typeOfAnimal = Console.ReadLine();

            List<Animal> animals = new List<Animal>();

            while (typeOfAnimal != "Beast!")
            {
                try
                {
                    string[] information = Console.ReadLine()
                                                  .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                  .ToArray();
                    var name = information[0];
                    var age = int.Parse(information[1]);
                    var gender = string.Empty;

                    if (information.Length == 3)
                    {
                        gender = information[2];
                    }

                    if (typeOfAnimal == "Cat")
                    {
                        var cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (typeOfAnimal == "Dog")
                    {
                        var dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (typeOfAnimal == "Frog")
                    {
                        var frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    else if (typeOfAnimal == "Kitten")
                    {
                        var kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    else if (typeOfAnimal == "Tomcat")
                    {
                        var tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch(Exception exeption)
                {
                    Console.WriteLine(exeption.Message);
                }
                typeOfAnimal = Console.ReadLine();
            }

            foreach (var aimal in animals)
            {
                Console.WriteLine(aimal);
            }
        }
    }
}
