using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_4_FindAReturnMatrix
{
    public class MatrixOperations
    {
        public static double[,] GenerateRandomMatrix(int n)
        {
            Random rand = new Random();

            double[,] randomMatrix = new double[n, n];

            for (int i = 0; i < randomMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < randomMatrix.GetLength(1); j++)
                {
                    randomMatrix[i, j] = rand.Next(0, 100);
                }
            }

            return randomMatrix;
        }

        public static double[,] InvertMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] a = new double[n, n];
            double[,] b = new double[n, n];

            int[] index = new int[n];
            for (int i = 0; i < n; ++i)
                b[i, i] = 1;

            TransformMatrixIntoAnUpperTriangle(matrix, index);

            for (int i = 0; i < n - 1; ++i)
                for (int j = i + 1; j < n; ++j)
                    for (int k = 0; k < n; ++k)
                        b[index[j], k]
                                -= matrix[index[j], i] * b[index[i], k];

            for (int i = 0; i < n; ++i)
            {
                a[n - 1, i] = b[index[n - 1], i] / matrix[index[n - 1], n - 1];
                for (int j = n - 2; j >= 0; --j)
                {
                    a[j, i] = b[index[j], i];
                    for (int k = j + 1; k < n; ++k)
                    {
                        a[j, i] -= matrix[index[j], k] * a[k, i];
                    }
                    a[j, i] /= matrix[index[j], j];
                }
            }
            return a;
        }

        public static void TransformMatrixIntoAnUpperTriangle(double[,] a, int[] index)
        {
            int n = index.Length;
            double[] c = new double[n];

            for (int i = 0; i < n; ++i)
                index[i] = i;

            for (int i = 0; i < n; ++i)
            {
                double c1 = 0;
                for (int j = 0; j < n; ++j)
                {
                    double c0 = Math.Abs(a[i, j]);
                    if (c0 > c1) c1 = c0;
                }
                c[i] = c1;
            }

            int k = 0;
            for (int j = 0; j < n - 1; ++j)
            {
                double pi1 = 0;
                for (int i = j; i < n; ++i)
                {
                    double pi0 = Math.Abs(a[index[i], j]);
                    pi0 /= c[index[i]];
                    if (pi0 > pi1)
                    {
                        pi1 = pi0;
                        k = i;
                    }
                }

                // Interchange rows according to the pivoting order
                int itmp = index[j];
                index[j] = index[k];
                index[k] = itmp;
                for (int i = j + 1; i < n; ++i)
                {
                    double pj = a[index[i], j] / a[index[j], j];

                    // Record pivoting ratios below the diagonal
                    a[index[i], j] = pj;

                    // Modify other elements accordingly
                    for (int l = j + 1; l < n; ++l)
                        a[index[i], l] -= pj * a[index[j], l];
                }
            }
        }
    }
}
