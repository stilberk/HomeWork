using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CollectTheCoins
{
    class CollectTheCoins
    {
        static void Main()
        {
            const int rows = 4;
            List<string> tableStr = new List<string>();
            for (int row_ = 0; row_ < rows; row_++)
            {
                tableStr.Add(Console.ReadLine());
            }
            List<string> table = new List<string>(tableStr.OrderByDescending(s => s.Length));
            string commands = Console.ReadLine();
            //Create matrix with thableStr strings
            int cols = table[0].Length;
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                char[] inputRow = tableStr[row].ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                        matrix[row] = inputRow;
                }
            }
            //----------------------------------------------------------
            int rowl = 0;
            int coll = 0;
            int currRow = 0;
            int currColl = 0;
            int coins = 0;
            int wallsHit = 0;
            foreach (var ch in commands)
            {
                switch (ch)
                {
                    case 'V': rowl++; break;
                    case '>': coll++; break;
                    case '^': rowl--; break;
                    case '<': coll--; break;
                }
                if (MatrixHaveElement(matrix, rowl, coll))
                {
                    if (matrix[rowl][coll] == '$')
                    {
                        coins++;
                    }
                     currRow = rowl;
                     currColl = coll;
                }
                else
                {
                    wallsHit++;
                    rowl = currRow;
                    coll = currColl;
                }
            }
            Console.WriteLine("Coins collected: {0}",coins);
            Console.WriteLine();
            Console.WriteLine("Walls hit: {0}",wallsHit);
        }

        private static bool MatrixHaveElement(char[][] matrix,int row,int col)
        {
            char test;
            bool haveIt = true;
            try
            {
                test = matrix[row][col];
            }
            catch (IndexOutOfRangeException)
            {
                haveIt = false;
            }
            return haveIt;
        }

        private static bool CharArrhaveElement(char[] inputRow,int col)
        {
            bool thisExist = true;
            char test;
            try
            {
                test = inputRow[col];
            }
            catch (IndexOutOfRangeException)
            {
                thisExist = false;
            }
            return thisExist;         
        }
    }
}
