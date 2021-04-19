using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList(){ "1","2","3" };

            Console.WriteLine(list.RandomString());
            Console.WriteLine(string.Join(" ",list));
        }
    }
}
