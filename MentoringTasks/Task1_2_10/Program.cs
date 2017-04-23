using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_2_10
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Revert strings of list or array 
			string[] originalArray = Actions.GenerateRandomStringsArray();
			Console.WriteLine("Original array: ");
			Actions.ShowArray(originalArray);

			string[] arrayWithReversedStrings = Actions.ReverseArray(originalArray);
			Console.WriteLine("Array with reversed strings: ");
			Actions.ShowArray(originalArray);
		}
	}
}
