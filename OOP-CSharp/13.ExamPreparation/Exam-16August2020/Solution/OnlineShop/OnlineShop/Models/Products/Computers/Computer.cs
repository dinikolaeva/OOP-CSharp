using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
                }
            }
        }

        public override decimal Price => base.Price +
                                         this.Peripherals.Sum(p => p.Price) +
                                         this.Components.Sum(c => c.Price);

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (this.components.Count == 0 || component == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var component = this.peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (this.peripherals.Count == 0 || component == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Remove(component);
            return component;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            double result = 0;

            if (this.peripherals.Count != 0)
            {
                result = this.peripherals.Average(p => p.OverallPerformance);
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({result:f2}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
