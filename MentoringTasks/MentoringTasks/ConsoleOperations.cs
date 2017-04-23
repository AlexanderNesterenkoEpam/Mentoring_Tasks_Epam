using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1_ConsoleCalculator
{
    public class ConsoleOperations
    {
        public double EnterNumber()
        {
            bool isParsed = false;
            double number = 0;
            int wrongInputCount = 0;

            do
            {
                wrongInputCount++;

                if (wrongInputCount > 1)
                {
                    Console.WriteLine("Wrong input! You must input only numbers.");
                }

                Console.WriteLine("Input number: ");
                isParsed = Double.TryParse(Console.ReadLine(), out number);
            }
            while (isParsed == false);

            return number;
        }

        public char EnterOperation()
        {
            char[] operationsArray = { '+', '-', '*', '/' };
            int wrongInputCount = 0;
            char operation = '\0';

            bool isParsed = false;
            bool isCorrectOperation = false;


            do
            {
                if (wrongInputCount >= 1)
                {
                    Console.WriteLine("Wrong input! It is not an arithmetic operation!");
                }

                Console.WriteLine("Choose operations '+', '-', '*', '/': ");
                isParsed = Char.TryParse(Console.ReadLine(), out operation);
                isCorrectOperation = operationsArray.Contains(operation);
                wrongInputCount++;

            } while (!isParsed && !isCorrectOperation);

            return operation;
        }

        public void ShowResult(double result)
        {
            if (result > Double.MaxValue || result < Double.MinValue)
            {
                Console.WriteLine("Result is out of allowable range.");
            }
            else
            {
                Console.WriteLine("Result: " + result);
            }
        }
    }
}
