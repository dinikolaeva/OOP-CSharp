using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random element = new Random();

        public string RandomString()
        {
            int index = element.Next(0, this.Count);
            string removedElement = this[index];
            this.RemoveAt(index);
            return removedElement;
        }
    }
}
