using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] colElements = Console.ReadLine()
                                           .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int submatrixSize1 = 2;
            int submatrixSize2 = 2;
            int maxSum = int.MinValue;
            int maxSumRow = -1;
            int maxSumCol = -1;

            for (int row = 0; row < matrix.GetLength(0) - submatrixSize1 + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - submatrixSize2 + 1; col++)
                {
                    int sumOfElements = 0;

                    for (int subRow = 0; subRow < submatrixSize1; subRow++)
                    {

                        for (int subCol = 0; subCol < submatrixSize2; subCol++)
                        {
                            sumOfElements += matrix[row + subRow, col + subCol];
                        }
                    }

                    if (sumOfElements > maxSum)
                    {
                        maxSum = sumOfElements;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            for (int row = 0; row < submatrixSize1; row++)
            {
                for (int col = 0; col < submatrixSize2; col++)
                {
                    Console.Write(matrix[maxSumRow + row, maxSumCol + col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
