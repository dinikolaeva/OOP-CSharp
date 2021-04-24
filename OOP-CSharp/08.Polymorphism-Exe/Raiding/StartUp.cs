using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heroes.Count != n)
            {
                string nameOfHero = Console.ReadLine();
                string typeOfHero = Console.ReadLine();

                BaseHero hero;

                switch (typeOfHero)
                {
                    case "Druid":
                        hero = new Druid(nameOfHero);
                        heroes.Add(hero);
                        break;
                    case "Paladin":
                        hero = new Paladin(nameOfHero);
                        heroes.Add(hero);
                        break;
                    case "Rogue":
                        hero = new Rogue(nameOfHero);
                        heroes.Add(hero);
                        break;
                    case "Warrior":
                        hero = new Warrior(nameOfHero);
                        heroes.Add(hero);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int sumOfheroesPower = heroes.Sum(x => x.Power);

            if (bossPower <= sumOfheroesPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
