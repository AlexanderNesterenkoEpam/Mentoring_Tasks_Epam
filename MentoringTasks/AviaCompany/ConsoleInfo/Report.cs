using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany
{
	public class Report
	{
		public void ShowAviaCompanyPlanes(AviaCompany company)
		{
			Console.WriteLine("----------------------------Airline: " + company.Name + " ---------------------------------");
			Console.WriteLine();

			if(company.ListOfPlanes != null)
            {
                foreach (var plane in company.ListOfPlanes)
                {
                    Console.WriteLine(plane);
                }
            }
		}

		public void ShowTotalCarrying(double carrying)
		{
			Console.WriteLine("Total carrying: " + carrying + " t.");
		}

		public void ShowTotalCapacity(int capacity)
		{
			Console.WriteLine("Total capacity: " + capacity + " persons.");
		}

		public void ShowFounedPlane(Plane plane)
		{
			Console.WriteLine();
			if (plane == null)
			{
				Console.WriteLine("Plane not found :( ");
			}
			else
			{
				Console.WriteLine("Found plane: " + plane);
			}	
		}
	}
}
