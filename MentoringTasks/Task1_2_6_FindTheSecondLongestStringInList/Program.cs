using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1_2_6_And_1_2_7_FindTheSecondLongestStringInList_SortList
{
    class Program
    {
        public static void Main(string[] args)
        {
			Actions action = new Actions();
			int listSize = 20;

			List<string> randomList = action.GenerateRandomList(listSize);
			Console.WriteLine("Random list: ");
			action.ShowList(randomList);
	        Console.WriteLine();
			

			Console.WriteLine("Random sorted by length list: ");
			List<string> sortedByLengthList = action.SortList(randomList).ToList<string>();
			action.ShowList(sortedByLengthList);

			string secondByLengthString = action.FindSecondByLengthString(sortedByLengthList);
			Console.WriteLine();
			Console.WriteLine("Second string with max length: " + secondByLengthString);
        }
	}
 }

