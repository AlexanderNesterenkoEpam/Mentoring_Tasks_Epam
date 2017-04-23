using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_1_ConsoleCalculator
{
    class Calculator
    {
        public void Start()
        {
            ConsoleOperations op = new ConsoleOperations();
            double firstNum = op.EnterNumber();
            char arithmeticOperation = op.EnterOperation();
            double secondNum = op.EnterNumber();
            double result = CalculateResult(firstNum, secondNum, arithmeticOperation);
            op.ShowResult(result);
        }

        public static double CalculateResult(double firstNum, double secondNum, char operation)
        {
            double result = 0;

            switch (operation)
            {
                case '+': result = firstNum + secondNum;
                    break;
                case '-': result = firstNum - secondNum;
                    break;
                case '*': result = firstNum * secondNum;
                    break;
                case '/': result = CheckDivisionByZeroAndCalculate(firstNum, secondNum);
                    break;
                default:
                    Console.WriteLine("Unknown arithmetic operation.");
                    Environment.Exit(1);
                    break;
            }

            return result;
        }

        private static double CheckDivisionByZeroAndCalculate(double firstNum, double secondNum)
        {
            double rezultOfDivision = 0;
            if (secondNum == 0.0)
            {
                Console.WriteLine("Division by zero");
                Environment.Exit(0);
            }

            rezultOfDivision = firstNum / secondNum;

            return rezultOfDivision;
        }

    }
}
