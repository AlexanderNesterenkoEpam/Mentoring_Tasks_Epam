using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAMatrixDeterminant
{
    public class Program
    {
      public static void Main(string[] args)
      {
        ConsoleOpetations op = new ConsoleOpetations();
        Console.WriteLine("Input matrix size: ");
        int matrixSize = op.ReadNumberFromConsole();

        float[,] randomRectangularMatrix = MatrixOperations.GenerateRandomMatrix(matrixSize);
        op.ShowMatrix(randomRectangularMatrix);

        float determinant = MatrixOperations.MatrixDeterminant(randomRectangularMatrix);

        Console.WriteLine("Determinant  = " + determinant.ToString("F1"));
      }
    }
}
