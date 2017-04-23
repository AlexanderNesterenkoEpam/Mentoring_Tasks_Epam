using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_7_And_1_2_8_SortArrayByVowels_Consonants
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

		public string[] SortArrayByConsonants(string[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (NumberOfConsonants(array[i]) < NumberOfConsonants(array[j]))
					{
						string temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}

			return array;
		}

		public string[] SortArrayByVowels(string[] array)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (NumberOfVowels(array[i]) < NumberOfVowels(array[j]))
					{
						string temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}

			return array;
		}

		public static int NumberOfConsonants(string str)
		{
			int numberOfConsonants = 0;

			char[] consonants =
			{
				'q', 'w', 'r', 't', 'p', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b',
				'n', 'm'
			};

			char[] arrayOfLetters = str.ToCharArray();

			for (int j = 0; j < arrayOfLetters.Length; j++)
			{
				if (consonants.Contains(arrayOfLetters[j]))
				{
					numberOfConsonants++;
				}
			}

			return numberOfConsonants;
		}

		public static int NumberOfVowels(string str)
		{
			int numberOfVowels = 0;

			char[] consonants =
			{
				'a', 'i', 'u', 'e', 'o', 'y'
			};

			char[] arrayOfLetters = str.ToCharArray();

			for (int j = 0; j < arrayOfLetters.Length; j++)
			{
				if (consonants.Contains(arrayOfLetters[j]))
				{
					numberOfVowels++;
				}
			}

			return numberOfVowels;
		}

		public void ShowArray(string[] array)
		{
			foreach (string str in array)
			{
				Console.WriteLine(str);
			}
			Console.WriteLine();
		}
	}
}
