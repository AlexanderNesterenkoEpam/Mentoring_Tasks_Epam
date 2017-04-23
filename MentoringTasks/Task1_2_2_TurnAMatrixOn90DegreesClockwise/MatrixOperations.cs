using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_2_TurnAMatrixOn90DegreesClockwise
{
    public class MatrixOperations
    {
        public static int[,] GenerateRandomMatrix(int n, int m)
        {
            Random rand = new Random();

            int[,] randomMatrix = new int[n,m];

            for (int i = 0; i < randomMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i,j] = rand.Next(0, 100);
                }
            }

            return randomMatrix;
        }

        public static int[,] RotateMatrixOn90DegreesClockwise(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] rotatedMatrix = new int[m, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    rotatedMatrix[j, n - 1 - i] = matrix[i, j];
                }
            }

            return rotatedMatrix;
        }
    }
}
