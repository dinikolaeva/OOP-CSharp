using Shapes.Models;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(10.5);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());

            Shape rectangle = new Rectangle(10.25, 15.30);
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(circle.Draw());

        }
    }
}
