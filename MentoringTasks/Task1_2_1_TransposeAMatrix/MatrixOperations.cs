using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_1_TransposeAMatrix
{
    public class MatrixOperations
    {
        public static int[][] GenerateRandomMatrix(int n, int m)
        {
            Random rand = new Random();

            int[][] randomMatrix = new int[n][];

            for (int i = 0; i < randomMatrix.Length; i++)
            {
                randomMatrix[i] = new int[m];

                for (int j = 0; j < randomMatrix[i].Length; j++)
                {
                    randomMatrix[i][j] = rand.Next(0, 100);
                }
            }

            return randomMatrix;
        }

        public static int[][] TransposeMatrix(int[][] matrix)
        {
            int[][] transposedMatrix = new int[matrix[0].Length][];

            for (int i = 0; i < transposedMatrix.Length; i++)
            {
                transposedMatrix[i] = new int[matrix.Length];
            }

            for (int i = 0; i < transposedMatrix.Length; i++)
            {
                for (int j = 0; j < transposedMatrix[i].Length; j++)
                {
                    transposedMatrix[i][j] = matrix[j][i];
                }
            }

            return transposedMatrix;
        }
    }
}
