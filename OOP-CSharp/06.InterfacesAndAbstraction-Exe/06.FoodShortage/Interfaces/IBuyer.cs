using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage.Interfaces
{
    public interface IBuyer
    {
        public int BuyFood();

        public int Food { get; set; }
    }
}
