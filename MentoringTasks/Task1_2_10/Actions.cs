using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_10
{
	public class Actions
	{
		public static void ShowArray(string[] array)
		{
			foreach (string str in array)
			{
				Console.WriteLine(str);
			}
			Console.WriteLine();
		}

		public static string[] GenerateRandomStringsArray(int size = 5)
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

		public static string[] ReverseArray(string[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ReverseString(array[i]);
			}

			return array;
		}

		public static string ReverseString(string originalString)
		{
			char[] reversedCharArray = new char[originalString.Length];
			int i = 0;
			int j = originalString.Length - 1;
			while (i <= j)
			{
				reversedCharArray[i] = originalString[j];
				reversedCharArray[j] = originalString[i];
				i++; j--;
			}

			return new string(reversedCharArray);
		}
	}
}
