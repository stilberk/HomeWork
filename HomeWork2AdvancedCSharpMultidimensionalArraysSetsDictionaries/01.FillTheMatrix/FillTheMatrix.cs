using System;

namespace _01.FillTheMatrix
{
    class FillTheMatrix
    {
        static void Main()
        {
            int[,] matrixA = FillTheMatrixPatternA();
            int[,] matrixB = FillTheMatrixPatternB();

            //Print-----------------------------------
            PrintTheMAtrix(matrixA);
            Console.WriteLine();
            PrintTheMAtrix(matrixB);
        }

        private static void PrintTheMAtrix(int[,]matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int yi = 0; yi < 4; yi++)
                {
                    Console.Write(" {0}", matrix[i, yi]);
                }
                Console.WriteLine();
            }
        }

        private static int[,] FillTheMatrixPatternA()
        {
            int[,] patternA = new int[4, 4];
            int num = 1;
            for (int i = 0; i < 4; i++)
            {
                for (int yi = 0; yi < 4; yi++)
                {
                    patternA[yi, i] = num;
                    num++;
                }
            }
            return patternA;
        }

        private static int[,] FillTheMatrixPatternB()
        {

            int[,] patternB = new int[4, 4];
            int index = 1;
            int num = 1;
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 1)
                {
                    for (int y = 3; y >= 0; y--)
                    {
                        patternB[y, index] = num;
                        num++;
                    }
                    index += 2;
                }
                else
                {
                    for (int y = 0; y < 4; y++)
                    {
                        patternB[y, i] = num;
                        num++;
                    }
                }

            }
            return patternB;
        }
    }
}
