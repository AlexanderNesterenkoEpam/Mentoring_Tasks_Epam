using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany
{
	public class Program
	{
		public static void Main(string[] args)
		{
            bool readFromDb = true;
			Manager manager = new Manager();
			manager.StartWork(readFromDb);
		}
	}
}
