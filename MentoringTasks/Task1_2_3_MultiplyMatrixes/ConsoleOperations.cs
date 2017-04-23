using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_3_MultiplyMatrixes
{
    public class ConsoleOperations
    {
        public int ReadNumberFromConsole()
        {
            bool isParsed = false;
            int number = 0;
            int wrongInputCount = 0;

            do
            {
                wrongInputCount++;

                if (wrongInputCount > 1)
                {
                    Console.WriteLine("Wrong input! You must input only numbers. Try again: ");
                }

                isParsed = Int32.TryParse(Console.ReadLine(), out number);
            }
            while (isParsed == false);

            return number;
        }
        public void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
