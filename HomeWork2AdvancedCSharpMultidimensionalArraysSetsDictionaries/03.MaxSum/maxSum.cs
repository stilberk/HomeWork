using System;
using System.Linq;


namespace _03.MaxSum
{
    class maxSum
    {
        static void Main()
        {
            int[] matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[] inputRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] matrix = new int[rows, cols];
            //Fill it up
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
                if (row == rows - 1) { break; }
                inputRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            FindPrintMaxSumZone(matrix, rows, cols);
        }
        private static void FindPrintMaxSumZone(int[,] matrix, int rows, int cols)
        {
            int maxSum = 0;
            int[] newMatrix = new int[9];
            for (int row = 1; row < rows - 1; row++)
            {
                for (int col = 1; col < cols - 1; col++)
                {
                    if (matrix[row + 1, col - 1] + matrix[row + 1, col] + matrix[row + 1, col + 1]
                       + matrix[row, col - 1] + matrix[row, col] + matrix[row, col + 1]
                       + matrix[row - 1, col - 1] + matrix[row - 1, col] + matrix[row - 1, col + 1] > maxSum)
                    {
                        maxSum = matrix[row + 1, col - 1] + matrix[row + 1, col] + matrix[row + 1, col + 1]
                       + matrix[row, col - 1] + matrix[row, col] + matrix[row, col + 1]
                       + matrix[row - 1, col - 1] + matrix[row - 1, col] + matrix[row - 1, col + 1];

                        newMatrix = new int[9] { matrix[row - 1, col - 1] , matrix[row - 1, col] , matrix[row - 1, col + 1],
                                    matrix[row, col - 1] , matrix[row, col] , matrix[row, col + 1],
                            matrix[row + 1, col - 1] , matrix[row + 1, col] , matrix[row + 1, col + 1]                                };
                    }
                }
            }
            Console.WriteLine("Sum = {0}", maxSum);
            for (int i = 0; i < newMatrix.Length; i++)
            {
                Console.Write("{0} ", newMatrix[i]);
                if (i == 2 || i == 5)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();   
        }
    }
}
