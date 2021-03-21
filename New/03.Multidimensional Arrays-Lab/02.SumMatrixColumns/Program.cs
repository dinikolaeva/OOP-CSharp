using System;
using System.Text;
using System.Linq;


namespace _02.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                                 .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] colElements = Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sumOfColElement = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sumOfColElement += matrix[row, col];
                }

                Console.WriteLine(sumOfColElement);
            }
        }
    }
}
