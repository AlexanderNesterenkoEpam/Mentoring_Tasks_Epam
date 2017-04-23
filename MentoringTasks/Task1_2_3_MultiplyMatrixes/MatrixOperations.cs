using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_3_MultiplyMatrixes
{
    public class MatrixOperations
    {
        public static int[,] GenerateRandomMatrix(int n, int m)
        {
            Random rand = new Random();

            int[,] randomMatrix = new int[n, m];

            for (int i = 0; i < randomMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i, j] = rand.Next(0, 100);
                }
            }

            return randomMatrix;
        }

        public static int[,] MultiplicateMatrices(int[,] a, int[,] b)
        {
            int[,] resultMatrix = new int[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        resultMatrix[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return resultMatrix;
        }
    }
}
