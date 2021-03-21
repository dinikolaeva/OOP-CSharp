using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var jaggedArr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

                jaggedArr[i] = numbers;
            }

            string[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string operation = commands[0];

            while (operation != "END")
            {
                int rowInfo = int.Parse(commands[1]);
                int colInfo = int.Parse(commands[2]);
                int valueInfo = int.Parse(commands[3]);

                if (rowInfo >= 0 &&
                    colInfo >= 0 &&
                    rowInfo < jaggedArr.GetLength(0) &&
                    colInfo < jaggedArr[rowInfo].Length)
                {
                    if (operation == "Add")
                    {
                        jaggedArr[rowInfo][colInfo] += valueInfo;
                    }
                    else if (operation == "Subtract")
                    {
                        jaggedArr[rowInfo][colInfo] -= valueInfo;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                operation = commands[0];
            }

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                for (int j = 0; j < jaggedArr[i].Length; j++)
                {
                    Console.Write($"{jaggedArr[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
