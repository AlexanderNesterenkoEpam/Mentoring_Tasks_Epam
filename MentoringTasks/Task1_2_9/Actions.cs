using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_9
{
    public class Actions
    {
        public string[] GenerateRandomStringsArray(int size)
        {
            int minLengthOfWord = 3;
            int maxLengthOfWord = 13;
            int asciiCodeOfFirstSymb = 97;
            int asciiCodeOfLastSymb = 122;
            Random rand = new Random();
            string[] randomArrayStrings = new string[size];

            for (int i = 0; i < size; i++)
            {
                string randomString = string.Empty;

                for (int j = 0; j < rand.Next(minLengthOfWord, maxLengthOfWord) + 1; j++)
                {
                    int randomInt = rand.Next(asciiCodeOfFirstSymb, asciiCodeOfLastSymb) + 1;
                    char symbol = (char)randomInt;
                    randomString += symbol;
                }

                randomArrayStrings[i] = randomString;
            }

            return randomArrayStrings;
        }

        public void ShowArray(string[] array)
        {
            foreach (string str in array)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
        }

        public string[] ReplaceLetters(string[] array)
        {
            for (int i = 1; i <= array.Length; i++)
            {
                if (i % 2 == 0 && i != 0)
                {
                    array[i - 1] = Swap(array[i - 1]);
                }
            }

            return array;
        }

        private static string Swap(string str)
        {
            char[] arrayOfLetters = str.ToCharArray();

            char temp = arrayOfLetters[0];
            arrayOfLetters[0] = arrayOfLetters[arrayOfLetters.Length - 1];
            arrayOfLetters[arrayOfLetters.Length - 1] = temp;

            return new string(arrayOfLetters);
        }
    }
}
