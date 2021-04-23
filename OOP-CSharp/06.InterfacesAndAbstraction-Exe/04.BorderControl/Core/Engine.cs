using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;
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
            var IdList = new List<Id>();

            var command = Console.ReadLine();

            while (command != "End")
            {
                var cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var nameOrMOdel = cmdArgs[0];

                if (cmdArgs.Length == 3)
                {
                    var age = int.Parse(cmdArgs[1]);
                    var id = cmdArgs[2];

                    Id citizen = new Citizen(nameOrMOdel, age, id);
                    IdList.Add(citizen);
                }
                else if (cmdArgs.Length == 2)
                {
                    var id = cmdArgs[1];

                    Id robot = new Robot(nameOrMOdel, id);
                    IdList.Add(robot);
                }

                command = Console.ReadLine();
            }

            var fakeIds = Console.ReadLine();
            IdList = IdList.Where(x => x.Id.EndsWith(fakeIds)).ToList();
            foreach (var item in IdList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
