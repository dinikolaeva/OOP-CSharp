using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] colElements = Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int sumOfPrimaryDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sumOfPrimaryDiagonal += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sumOfPrimaryDiagonal);
        }
    }
}
