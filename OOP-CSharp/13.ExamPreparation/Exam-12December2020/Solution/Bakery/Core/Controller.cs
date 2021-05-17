using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal tottalIncome = 0M;

        public Controller()
        {
            this.bakedFoods = new List<BakedFood>();
            this.drinks = new List<Drink>();
            this.tables = new List<Table>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type != "Tea" && type != "Water")
            {
                throw new ArgumentException();
            }

            Drink drink = null;

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }

            if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            this.drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type != "Bread" && type != "Cake")
            {
                throw new ArgumentException();
            }

            BakedFood food = null;

            if (type == "Bread")
            {
                food = new Bread(name, price);
            }

            if (type == "Cake")
            {
                food = new Cake(name, price);
            }
            this.bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, name, food.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type != "InsideTable" && type != "OutsideTable")
            {
                throw new ArgumentException();
            }

            Table table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }

            if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables.Where(t => t.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return String.Format(OutputMessages.TotalIncome, this.tottalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            var bill = table.GetBill();
            this.tottalIncome += bill;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {bill:f2}");

            table.Clear();

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var drink = this.drinks.FirstOrDefault(d => d.Name == drinkName &&
                                                        d.Brand == drinkBrand);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);

        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTable = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (freeTable == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                freeTable.Reserve(numberOfPeople);
                return String.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
            }
        }
    }
}
