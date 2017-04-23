using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_1_TransposeAMatrix
{
    public class Program
    {
        // Task was done using array of arrays
        public static void Main(string[] args)
        {
            ConsoleOperations op = new ConsoleOperations();

            Console.WriteLine("Input number of rows: ");
            int rows = op.ReadNumberFromConsole();

            Console.WriteLine("Input number of columns: ");
            int columns = op.ReadNumberFromConsole();
          
            int [][] matrix = MatrixOperations.GenerateRandomMatrix(rows, columns);
            Console.WriteLine("Matrix: ");
            op.ShowMatrix(matrix);

            int[][] transposedMatrix = MatrixOperations.TransposeMatrix(matrix);
            Console.WriteLine("Transposed matrix: ");
            op.ShowMatrix(transposedMatrix);
        }

    }
}
