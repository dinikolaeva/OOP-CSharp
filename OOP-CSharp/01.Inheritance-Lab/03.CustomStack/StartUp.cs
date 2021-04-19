using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.Push("lala");
            stack.Push("dudu");
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(string.Join(' ',stack.AddRange()));
        }
    }
}
