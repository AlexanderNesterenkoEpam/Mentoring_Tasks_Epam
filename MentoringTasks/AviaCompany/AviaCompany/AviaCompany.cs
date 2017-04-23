using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany
{
	public class AviaCompany
	{
		public List<Plane> ListOfPlanes { get; private set; }
		public string Name { get; private set; }

		public AviaCompany(string name)
		{
			Name = name;
			ListOfPlanes = new List<Plane>();
		}

		public AviaCompany(string name, List<Plane> listOfPlanes)
		{
			Name = name;
			this.ListOfPlanes = listOfPlanes;
		}

		public AviaCompany SortPlanesByFlightRange()
		{
            if(this.ListOfPlanes != null)
            {
                this.ListOfPlanes = this.ListOfPlanes.OrderBy(o => o.FlightRange).ToList();
            }

			return this;
		}

	}
}
