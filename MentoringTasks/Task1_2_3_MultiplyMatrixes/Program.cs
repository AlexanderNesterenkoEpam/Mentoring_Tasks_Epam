using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_3_MultiplyMatrixes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleOperations op = new ConsoleOperations();
            Console.WriteLine("Input number of rows first matrix: ");
            int firstMatrixRows = op.ReadNumberFromConsole();
            Console.WriteLine("Input number of columns first matrix: ");
            int firstMatrixColumns = op.ReadNumberFromConsole();

            int[,] firstMatrix = MatrixOperations.GenerateRandomMatrix(firstMatrixRows, firstMatrixColumns);

            Console.WriteLine("Input number of rows second matrix: ");
            int secondMatrixRows = op.ReadNumberFromConsole();
            Console.WriteLine("Input number of columns secons matrix: ");
            int secondMatrixColumns = op.ReadNumberFromConsole();

            int[,] secondMatrix = MatrixOperations.GenerateRandomMatrix(secondMatrixRows, secondMatrixColumns);

            Console.WriteLine("First matrix: ");
            op.ShowMatrix(firstMatrix);

            Console.WriteLine("Second matrix: ");
            op.ShowMatrix(secondMatrix);

            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                Console.WriteLine("Matrices cannot multiplicate.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Result matrix: ");
                int[,] resultMatix = MatrixOperations.MultiplicateMatrices(firstMatrix, secondMatrix);
                op.ShowMatrix(resultMatix); 
            }    
        }
    }
}
