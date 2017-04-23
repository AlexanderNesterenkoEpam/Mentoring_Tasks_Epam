using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1_2_6_And_1_2_7_FindTheSecondLongestStringInList_SortList
{
	public class Actions
	{
		public void ShowList(List<string> list)
		{
			foreach (var str in list)
			{
				Console.WriteLine(str);
			}
		}

		public List<string> GenerateRandomList(int size)
		{
			int minLengthOfWord = 3;
			int maxLengthOfWord = 13;
			int asciiCodeOfFirstSymb = 97;
			int asciiCodeOfLastSymb = 122;
			Random rand = new Random();
			List<string> randomList = new List<string>();

			for (int i = 0; i < size; i++)
			{
				string randomString = string.Empty;

				for (int j = 0; j < rand.Next(minLengthOfWord, maxLengthOfWord) + 1; j++)
				{
					int randomInt = rand.Next(asciiCodeOfFirstSymb, asciiCodeOfLastSymb) + 1;
					char symbol = (char)randomInt;
					randomString += symbol;
				}

				randomList.Add(randomString);
			}

			return randomList;
		}

		public List<string> SortList(List<string> list)
		{
			var sortedList = from s in list
							 orderby s.Length descending
							 select s;
			return sortedList.ToList<string>();
		}

		public string FindSecondByLengthString(List<string> list)
		{
			string elementWithMaxLength = list.ElementAt(0);
			string secondByLengthString = string.Empty;

			foreach (var el in list)
			{
				if (el.Length < elementWithMaxLength.Length)
				{
					secondByLengthString = el;
					break;
				}
			}

			if (secondByLengthString == string.Empty)
			{
				Console.WriteLine("All strings have equal lengths");
				Environment.Exit(0);
			}

			return secondByLengthString;
		}
	}
}
