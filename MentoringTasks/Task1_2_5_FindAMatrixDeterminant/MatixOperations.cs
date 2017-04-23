using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_5_FindAMatrixDeterminant
{
    public class MatixOperations
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
    }
}
