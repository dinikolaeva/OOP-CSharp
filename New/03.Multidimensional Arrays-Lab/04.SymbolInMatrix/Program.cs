using System;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] colElements = Console.ReadLine()
                                            .ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isSymbolFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = matrix[row, col];
                    if (currentChar == symbol)
                    {
                        isSymbolFound = true;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix ");
        }
    }
}
