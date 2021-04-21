using System;
using System.Linq;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var pizza = Console.ReadLine().Split(' ');
                Pizza currentPizza = new Pizza(pizza[1]);

                var infoForDough = Console.ReadLine().Split(' ');
                currentPizza.Dough = new Dough(infoForDough[1], infoForDough[2],
                                               double.Parse(infoForDough[3]));

                var command = Console.ReadLine();

                while (command.ToLower() != "end")
                {
                  var infoForTopping = command.Split(' ');
                    
                    var currentTopping = new Topping(infoForTopping[1], double.Parse(infoForTopping[2]));
                    currentPizza.AddTopping(currentTopping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(currentPizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
