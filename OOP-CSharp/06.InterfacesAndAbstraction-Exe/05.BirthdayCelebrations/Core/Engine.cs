using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;
using _05.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            var BirthdatesList = new List<IBirthdate>();

            var command = Console.ReadLine();

            while (command != "End")
            {
                var cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var currentItem = cmdArgs[0];

                if (currentItem == "Citizen")
                {
                    var name = cmdArgs[1];
                    var age = int.Parse(cmdArgs[2]);
                    var id = cmdArgs[3];
                    var birthdate = cmdArgs[4];

                    IBirthdate citizen = new Citizen(name, age, id, birthdate);
                    BirthdatesList.Add(citizen);
                }
                else if (currentItem == "Robot")
                {
                    var model = cmdArgs[1];
                    var id = cmdArgs[2];
                }
                else if (currentItem == "Pet")
                {
                    var name = cmdArgs[1];
                    var birthdate = cmdArgs[2];

                    IBirthdate pet = new Pet(name, birthdate);
                    BirthdatesList.Add(pet);
                }

                command = Console.ReadLine();
            }

            var fakeIds = Console.ReadLine();

            BirthdatesList = BirthdatesList.Where(x => x.Birthdate.EndsWith(fakeIds)).ToList();

            foreach (var item in BirthdatesList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
