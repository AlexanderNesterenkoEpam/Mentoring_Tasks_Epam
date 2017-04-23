using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAMatrixDeterminant
{
    public static class MatrixOperations
    {
        public static float[,] GenerateRandomMatrix(int n)
        {
            Random rand = new Random();

            float[,] randomMatrix = new float[n, n];

            for (int i = 0; i < randomMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i, j] = rand.Next(0, 100);
                }
            }

            return randomMatrix;
        }

        public static float[,] DecomposeMatrix(float[,] matrix, out int[] permutation, out int flag)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                Console.WriteLine("Non-square matrix! ");
                Environment.Exit(1);
            }

            float[,] result = matrix;

            permutation = new int[rows];
            for (int i = 0; i < rows; ++i) { permutation[i] = i; }

            flag = 1;

            for (int j = 0; j < rows - 1; ++j)
            {
                float maxColValue = Math.Abs(result[j, j]);
                int pRow = j;
                for (int i = j + 1; i < rows; ++i)
                {
                    if (result[i, j] > maxColValue)
                    {
                        maxColValue = result[i, j];
                        pRow = i;
                    }
                }

                if (pRow != j)
                {
                    float[] rowTemp = new float[result.GetLength(1)];


                    for (int k = 0; k < result.GetLength(1); k++)
                    {
                        rowTemp[k] = result[pRow, k];
                    }

                    for (int k = 0; k < result.GetLength(1); k++)
                    {
                        result[pRow, k] = result[j, k];
                    }

                    for (int k = 0; k < result.GetLength(1); k++)
                    {
                        result[j, k] = rowTemp[k];
                    }

                    int tmp = permutation[pRow];
                    permutation[pRow] = permutation[j];
                    permutation[j] = tmp;

                    flag = -flag;
                }

                if (Math.Abs(result[j, j]) < 1.0E-20)
                    return null;

                for (int i = j + 1; i < rows; ++i)
                {
                    result[i, j] /= result[j, j];
                    for (int k = j + 1; k < rows; ++k)
                    {
                        result[i, k] -= result[i, j] * result[j, k];
                    }
                }
            }
            return result;
        }

        public static float MatrixDeterminant(float[,] matrix)
        {
            int[] permutation;
            int flag;
            float[,] lum = DecomposeMatrix(matrix, out permutation, out flag);
            if (lum == null)
            {
                Console.WriteLine("It is impossible to compute determinant! ");
                Environment.Exit(0);
            }

            float result = flag;
            for (int i = 0; i < lum.GetLength(0); ++i)
                result *= lum[i, i];

            return result;
        }
    }
}
