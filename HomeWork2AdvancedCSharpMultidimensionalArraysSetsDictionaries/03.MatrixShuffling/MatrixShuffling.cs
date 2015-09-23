using System;
using System.Linq;

namespace _03.MatrixShuffling
{
    class MatrixShuffling
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = Console.ReadLine();
                }
            }
            string swapTake = "";
            string swapPut = "";
            string[] commandParams = Console.ReadLine().Split(' ').ToArray();
            while (commandParams[0]!="END")
            {
                if (commandParams[0]=="swap")
                {
                    bool haveExp = false;
                    try
                    {
                        swapTake = matrix[int.Parse(commandParams[1]), int.Parse(commandParams[2])];
                        swapPut = matrix[int.Parse(commandParams[3]), int.Parse(commandParams[4])];
                        matrix[int.Parse(commandParams[1]), int.Parse(commandParams[2])] = swapPut;
                        matrix[int.Parse(commandParams[3]), int.Parse(commandParams[4])] = swapTake;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Invalid input!");
                        haveExp = true;
                    }
                    finally
                    {
                        if (!haveExp)
                        {
                            PrintMatrix(matrix, rows, cols);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                commandParams = Console.ReadLine().Split(' ').ToArray();
            }
        }

        private static void PrintMatrix(string[,] matrix,int rows,int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0} ",matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
