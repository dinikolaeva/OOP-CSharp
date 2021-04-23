using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Exceptions;
using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite.Core
{
    public class Engine
    {
        private readonly List<ISoldier> army;

        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArg = command.Split().ToArray();

                var type = cmdArg[0];
                var id = cmdArg[1];
                var firstName = cmdArg[2];
                var lastName = cmdArg[3];
                var salary = decimal.Parse(cmdArg[4]);

                if (type == "Private")
                {
                    Private soldier = new Private(id, firstName, lastName, salary);
                    army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

                    string[] privatesList = cmdArg.Skip(5).ToArray();

                    foreach (var privatesId in privatesList)
                    {
                        ISoldier currentPrivate = this.army.First(s => s.Id == privatesId);
                        general.AddPrivate(currentPrivate);
                    }

                    this.army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        string corps = cmdArg[5];
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                        string[] repairs = cmdArg.Skip(6).ToArray();

                        for (int i = 0; i < repairs.Length; i += 2)
                        {
                            string partName = repairs[i];
                            int hours = int.Parse(repairs[i + 1]);

                            IRepair currentRepair = new Repair(partName, hours);
                            engineer.AddRepair(currentRepair);
                        }

                        this.army.Add(engineer);
                    }
                    catch (InvalidCorpsException ice)
                    {
                        
                    }                    
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = cmdArg[5];
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        string[] missions = cmdArg.Skip(6).ToArray();

                        for (int i = 0; i < missions.Length; i+=2)
                        {
                            try
                            {
                                string codeName = missions[i];
                                string state = missions[i + 1];

                                IMission currentMission = new Mission(codeName, state);
                                commando.AddMission(currentMission);

                            }
                            catch (InvalidStateException ise)
                            {
                                continue;
                            }
                        }

                        army.Add(commando);
                    }
                    catch (InvalidCorpsException ice)
                    {

                    }                
                    
                }
                else if (type == "Spy")
                {
                    int codeNumber = (int)salary;

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    this.army.Add(spy);
                }

                command = Console.ReadLine();
            }

            foreach (var soldier in this.army)
            {
                Type type = soldier.GetType();
                Object actualType = Convert.ChangeType(soldier, type);
                Console.WriteLine(actualType.ToString());
            }
        }
    }
}
