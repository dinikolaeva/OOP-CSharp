using System;

namespace _07.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var jaggedArr = new long[n][];
            long cols = 1;

            for (int i = 0; i < jaggedArr.Length; i++)
            {
                jaggedArr[i] = new long[cols];
                jaggedArr[i][0] = 1;
                jaggedArr[i][jaggedArr[i].Length - 1] = 1;
                cols++;

                if (i > 1)
                {
                    for (int j = 1; j < jaggedArr[i].Length - 1; j++)
                    {
                        long[] prevRow = jaggedArr[i - 1];
                        long firstElement = prevRow[j];
                        long secondElement = prevRow[j - 1];
                        jaggedArr[i][j] = firstElement + secondElement;
                    }
                }
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
