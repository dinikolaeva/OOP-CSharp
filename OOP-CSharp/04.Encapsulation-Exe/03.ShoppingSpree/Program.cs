using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] persons = Console.ReadLine()
                                      .Split(';', StringSplitOptions.RemoveEmptyEntries)
                                      .ToArray();

            string[] products = Console.ReadLine()
                                       .Split(';', StringSplitOptions.RemoveEmptyEntries)
                                       .ToArray();            

            try
            {
                var people = new List<Person>();
                var foodstuffs = new List<Product>();

                GePerson(persons, people);

                GetProducts(products, foodstuffs);

                var command = Console.ReadLine();

                while (command != "END")
                {
                    var input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var person = input[0];
                    var product = input[1];

                    var currentPerson = people.FirstOrDefault(p => p.Name == person);
                    var currentPtroduct = foodstuffs.FirstOrDefault(f => f.Name == product);

                    if (currentPerson != null && currentPtroduct != null)
                    {
                        currentPerson.Shopping(currentPtroduct);
                    }

                    command = Console.ReadLine();
                }
                people.ForEach(x => Console.WriteLine(x));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }

        private static void GePerson(string[] persons, List<Person> people)
        {
            foreach (var item in persons)
            {
                var personInfo = item
                                   .Split('=', StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var money = decimal.Parse(personInfo[1]);
                var currentPerson = new Person(name, money);
                people.Add(currentPerson);
            }
        }

        private static void GetProducts(string[] products, List<Product> foodstuffs)
        {
            foreach (var item in products)
            {
                var productsInfo = item
                                  .Split('=', StringSplitOptions.RemoveEmptyEntries);

                var name = productsInfo[0];
                var cost = decimal.Parse(productsInfo[1]);

                var currentProduct = new Product(name, cost);
                foodstuffs.Add(currentProduct);
            }
        }
    }
}
