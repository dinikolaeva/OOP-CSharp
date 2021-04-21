using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person()
        {
            this.bagOfProducts = new List<Product>();
        }

        public Person(string name, decimal money) : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void Shopping(Product product)
        {
            var leftMoney = this.Money - product.Cost;

            if (leftMoney >= 0)
            {
                this.bagOfProducts.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
                this.Money = leftMoney;
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (this.bagOfProducts.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(x => x.Name))}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            }
        }
    }
}
