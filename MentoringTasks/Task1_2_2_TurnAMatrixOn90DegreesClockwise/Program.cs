using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_2_TurnAMatrixOn90DegreesClockwise
{
    public class Program
    {
        // Task was done using multidimensional array
        public static void Main(string[] args)
        {
            ConsoleOperations op = new ConsoleOperations();

            Console.WriteLine("Input number of rows: ");
            int rows = op.ReadNumberFromConsole();

            Console.WriteLine("Input number of collumns: ");
            int colls = op.ReadNumberFromConsole();

            int[,] matrix = MatrixOperations.GenerateRandomMatrix(rows, colls);
            Console.WriteLine("Matrix: ");
            op.ShowMatrix(matrix);

            Console.WriteLine("Rotated matrix: ");
            int[,] rotatedMatrix = MatrixOperations.RotateMatrixOn90DegreesClockwise(matrix);
            op.ShowMatrix(rotatedMatrix);
        }
    }
}

