using System;

namespace _04.SequnceInMatrix
{
    class SequenceInMatrix
    {
        static void Main()
        {
            int nRows = int.Parse(Console.ReadLine());
            int mCols = int.Parse(Console.ReadLine());
            string[,] matrix = new string[nRows, mCols];
            for (int i = 0; i < nRows; i++)
            {
                for (int y = 0; y < mCols; y++)
                {
                    matrix[i, y] = Console.ReadLine();
                }
            }
            FindLongestSeqOfEqualStrInMatrix(matrix,nRows,mCols);
        }

        private static void FindLongestSeqOfEqualStrInMatrix(string[,] matrix,int rows,int cols)
        {
            string inputStr = "";
            string maxCountedStr = "";
            int maxEqualCounted = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    inputStr = matrix[row, col];
                    if (ScanTheRow(matrix, row, col, inputStr, rows, cols) > maxEqualCounted)
                    {
                        maxEqualCounted = ScanTheRow(matrix, row, col, inputStr, rows, cols);
                        maxCountedStr = matrix[row, col];
                    }
                    if (ScanColon(matrix, row, col, inputStr, rows, cols) > maxEqualCounted)
                    {
                        maxEqualCounted = ScanColon(matrix, row, col, inputStr, rows, cols);
                        maxCountedStr = matrix[row, col];
                    }
                    if (ScanDiagonal(matrix, row, col, inputStr, rows, cols)>maxEqualCounted)
                    {
                        maxEqualCounted = ScanDiagonal(matrix, row, col, inputStr, rows, cols);
                        maxCountedStr = matrix[row, col];
                    }
                }
            }
            for (int i = 0; i < maxEqualCounted; i++)
            {
                Console.Write(" {0},",maxCountedStr);
            }
            Console.WriteLine();
        }

        private static int ScanDiagonal(string[,] matrix, int row, int col, string str, int rows, int cols)
        {
            int atCol = col;
            int countEqual = 0;
            int maxEqual = 0;
            string maxCountStr = "";
            for (int atRow = row; atRow < (matrix.Length / cols) - col; atRow++,atCol++)
            {
                if (str == matrix[atRow, atCol])
                {
                    countEqual++;
                    if (countEqual > maxEqual)
                    {
                        maxCountStr = str;
                        maxEqual = countEqual;
                    }
                }
                else
                {
                    countEqual = 0;
                    break;
                }
            }
            return maxEqual;
        }

        private static int ScanColon(string[,] matrix, int row, int col, string str, int rows, int cols)
        {
            int countEqual = 0;
            int maxEqual = 0;
            string maxCountStr = "";
            for (int i = row; i < matrix.Length / cols; i++)
            {
                if (str == matrix[i,col])
                {
                    countEqual++;
                    if (countEqual > maxEqual)
                    {
                        maxCountStr = str;
                        maxEqual = countEqual;
                    }
                }
                else
                {
                    countEqual = 0;
                    break;
                }
            }
            return maxEqual;
        }

        private static int ScanTheRow(string[,] matrix,int row ,int col,string str,int rows,int cols)
        {
            int countEqual = 0;
            int maxEqual = 0;
            string maxCountStr = "";
            for (int i = row; i < matrix.Length/rows; i++)
            {
                if (str == matrix[row,i])
                {
                    countEqual++;
                    if (countEqual > maxEqual)
                    {
                        maxCountStr = str;
                        maxEqual = countEqual;
                    }          
                }
                else
                {
                    countEqual = 0;
                    break;
                }
            }
            return maxEqual;
        }
    }
}

//Test data 
//3
//4
//ha
//fifi
//ho
//hi
//fo
//ha
//hi
//xx
//xxx
//ho
//ha
//xx

//3
//3
//s
//qq
//s
//pp
//pp
//s
//pp
//qq
//s