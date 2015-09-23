using System;
using System.Linq;

namespace _02.MaximalSum
{
    class MaximalSum
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
                if (row == rows-1){break;}
                inputRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); 
            }
//-------------------------------------------------------------------------------------
           int[] maxSumRowColl = CalcMaxSum(matrix,rows,cols);
            Console.WriteLine("Sum = {0}",maxSumRowColl[0]);
            PrintMatrix(matrix, rows, cols);
        }

        private static int[] CalcMaxSum(int[,] matrix,int rows,int cols)
        {
            int[] maximal = new int[3];
            int sum = 0;
            int maxRow = 0;
            int maxColl = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!CellIsEmpty(matrix,row-1,col-1))
                    {
                        sum += matrix[row - 1, col - 1];
                    }
                    if (!CellIsEmpty(matrix,row-1,col))
                    {
                        sum += matrix[row - 1, col];
                    }
                    if (!CellIsEmpty(matrix,row-1,col+1))
                    {
                        sum += matrix[row - 1, col + 1];
                    }
                    if (!CellIsEmpty(matrix,row,col-1))
                    {
                        sum += matrix[row, col - 1];
                    }
                    sum += matrix[row, col];
                    if (!CellIsEmpty(matrix,row,col+1))
                    {
                        sum += matrix[row, col + 1];
                    }
                    if (!CellIsEmpty(matrix,row+1,col-1))
                    {
                        sum += matrix[row + 1, col - 1];
                    }
                    if (!CellIsEmpty(matrix,row+1,col))
                    {
                        sum += matrix[row + 1, col];
                    }
                    if (!CellIsEmpty(matrix,row+1,col+1))
                    {
                        sum += matrix[row + 1, col + 1];
                    }
                    if (sum > maximal[0])
                    {
                        maximal[0] = sum;
                        maxRow = rows;
                        maxColl = cols;
                    }

                    sum = 0;
                }
             }
            maximal[1] = maxRow;
            maximal[2] = maxColl;
            return maximal;
        }

        private static bool CellIsEmpty(int[,] matrix,int row,int col)
        {
            bool isEmpty = false;
            int test = 0;
            try
            {
                test = matrix[row, col];
            }
            catch (IndexOutOfRangeException)
            {
                isEmpty = true;
            }
            return isEmpty;
        }

        private static void PrintMatrix(int[,] matrix,int rows,int cols)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int y = 0; y < cols; y++)
                {
                    Console.Write("{0} ", matrix[i, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
