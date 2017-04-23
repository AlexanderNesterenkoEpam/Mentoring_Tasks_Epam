using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_7_And_1_2_8_SortArrayByVowels_Consonants
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Actions action = new Actions();
			string[] strignsArray = action.GenerateRandomStringsArray(10);
			Console.WriteLine("Array: ");
			action.ShowArray(strignsArray);

			string[] sortedByCountOfConsonantsArray = action.SortArrayByConsonants(strignsArray);
			Console.WriteLine("Sorted by count of consonants array: ");
			action.ShowArray(sortedByCountOfConsonantsArray);

			string[] sortedByCountOfVowelsArray = action.SortArrayByVowels(strignsArray);
			Console.WriteLine("Sorted by count of vowels array: ");
			action.ShowArray(sortedByCountOfVowelsArray);
		}
	}
}
