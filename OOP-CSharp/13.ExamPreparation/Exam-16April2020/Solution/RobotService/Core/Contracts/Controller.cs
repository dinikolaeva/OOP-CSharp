using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        private Garage garage;
        private List<IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new List<IProcedure>();
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckThatRobotExistInGarage(robotName);
            IRobot currentRobot = this.garage.Robots[robotName];
            var procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Charge");

            if (procedure == null)
            {
                procedure = new Charge();
            }

            procedure.DoService(currentRobot, procedureTime);
            this.procedures.Add(procedure);
            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            CheckThatRobotExistInGarage(robotName);
            IRobot currentRobot = this.garage.Robots[robotName];
            var procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Chip");

            if (procedure == null)
            {
                procedure = new Chip();
            }

            procedure.DoService(currentRobot, procedureTime);
            this.procedures.Add(procedure);
            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
            var procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == procedureType);

            return procedure.History().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new ArgumentException($"{robotType} type doesn't exist");
            }

            this.garage.Manufacture(robot);
            return $"Robot {name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            CheckThatRobotExistInGarage(robotName);
            IRobot currentRobot = this.garage.Robots[robotName];
            var procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Polish");

            if (procedure == null)
            {
                procedure = new Polish();
            }

            procedure.DoService(currentRobot, procedureTime);
            this.procedures.Add(procedure);
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckThatRobotExistInGarage(robotName);
            IRobot currentRobot = this.garage.Robots[robotName];
            var procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Rest");

            if (procedure == null)
            {
                procedure = new Rest();
            }

            procedure.DoService(currentRobot, procedureTime);
            this.procedures.Add(procedure);
            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckThatRobotExistInGarage(robotName);
            IRobot currentRobot = this.garage.Robots[robotName];
            this.garage.Sell(robotName, ownerName);

            if (currentRobot.IsChipped == true)
            {
                return $"{ownerName} bought robot with chip";
            }
            else
            {
                return $"{ownerName} bought robot without chip";
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            CheckThatRobotExistInGarage(robotName);
            IRobot currentRobot = this.garage.Robots[robotName];
            var procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "TechCheck");

            if (procedure == null)
            {
                procedure = new TechCheck();
            }

            procedure.DoService(currentRobot, procedureTime);
            this.procedures.Add(procedure);
            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            CheckThatRobotExistInGarage(robotName);
            IRobot currentRobot = this.garage.Robots[robotName];
            var procedure = this.procedures.FirstOrDefault(p => p.GetType().Name == "Work");

            if (procedure == null)
            {
                procedure = new Work();
            }

            procedure.DoService(currentRobot, procedureTime);
            this.procedures.Add(procedure);
            return $"{robotName} was working for {procedureTime} hours";
        }

        public void CheckThatRobotExistInGarage(string robotName)
        {
            if (!garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }

        }
    }
}
