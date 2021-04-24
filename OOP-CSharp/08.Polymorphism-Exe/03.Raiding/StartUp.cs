using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int n = int.Parse(Console.ReadLine());

            while (heroes.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero;

                if (type == nameof(Druid))
                {
                    hero = new Druid(name);
                    heroes.Add(hero);
                }
                else if (type == nameof(Paladin))
                {
                    hero = new Paladin(name);
                    heroes.Add(hero);
                }
                else if (type == nameof(Rogue))
                {
                    hero = new Rogue(name);
                    heroes.Add(hero);
                }
                else if (type == nameof(Warrior))
                {
                    hero = new Warrior(name);
                    heroes.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }
            }

            int bossPoints = int.Parse(Console.ReadLine());

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                bossPoints -= hero.Power;
            }

            if (bossPoints <= 0)
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
