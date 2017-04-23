using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_4_FindAReturnMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleOperations op = new ConsoleOperations();

            Console.WriteLine("Input matrix size: ");
            int matrixSize = op.ReadNumberFromConsole();

            double[,] matrix = MatrixOperations.GenerateRandomMatrix(matrixSize);

            Console.WriteLine("Matrix: ");
            op.ShowMatrix(matrix);

            double[,] inverseMatrix = MatrixOperations.InvertMatrix(matrix);

            Console.WriteLine("Inverse matrix: ");
            op.ShowMatrix(inverseMatrix);
        }
    }
}

