using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_9
{
    class Program
    {
        //Change by places first and last letters in each second string of list or array 

        public static void Main(string[] args)
        {
            Actions action = new Actions();

            string[] arrayOfStrings = action.GenerateRandomStringsArray(10);
            Console.WriteLine("Array: ");
            action.ShowArray(arrayOfStrings);

            string[] modifiedArray = action.ReplaceLetters(arrayOfStrings);
            Console.WriteLine("Modified array: ");
            action.ShowArray(modifiedArray);
        }    
    }
}
