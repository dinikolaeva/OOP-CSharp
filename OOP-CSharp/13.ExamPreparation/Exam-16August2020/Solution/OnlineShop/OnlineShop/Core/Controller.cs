using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckThatComputerWithThisIdExist(computerId);

            var findComputer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException($"Component with this id already exists.");
            }

            IComponent component = null;

            switch (componentType)
            {
                case "CentralProcessingUnit":
                    component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException($"Component type is invalid.");
            }

            this.components.Add(component);
            findComputer.AddComponent(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException($"Computer type is invalid.");
            }

            this.computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckThatComputerWithThisIdExist(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripheral = null;

            switch (peripheralType)
            {
                case "Headset":
                    peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Keyboard":
                    peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Monitor":
                    peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                case "Mouse":
                    peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    break;
                default:
                    throw new ArgumentException($"Peripheral type is invalid.");
            }

            this.peripherals.Add(peripheral);
            computer.AddPeripheral(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            if (computers.Count == 0 || !computers.Any(x => x.Price <= budget))
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            computers = computers.OrderByDescending(x => x.OverallPerformance)
                                 .ToList();
            IComputer buyBestItem = computers.FirstOrDefault(c => c.Price <= budget);
            computers.Remove(buyBestItem);
            return buyBestItem.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckThatComputerWithThisIdExist(id);
            var computer = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckThatComputerWithThisIdExist(id);
            var computer = this.computers.FirstOrDefault(c => c.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckThatComputerWithThisIdExist(computerId);

            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            var component = computer.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            computer.RemoveComponent(componentType);
            this.components.Remove(component);
            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckThatComputerWithThisIdExist(computerId);
            var computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            var peripheral = computer.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);
            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        private void CheckThatComputerWithThisIdExist(int id)
        {
            var computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException($"Computer with this id does not exist.");
            }
        }
    }
}
