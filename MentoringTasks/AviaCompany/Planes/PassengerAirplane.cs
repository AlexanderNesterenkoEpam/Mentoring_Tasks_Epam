using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany
{
    [Serializable]
	public class PassengerAirplane : Plane
	{
		public int Capacity { get; set; }

		public PassengerAirplane(int id, string name, int flightRange, int capacity) : base(id, name, flightRange)
		{
			this.Capacity = capacity;
		}

        public PassengerAirplane()
        {

        }

		public override string ToString()
		{
			return "Airliner: " + base.ToString() + "; Capacity: " + Capacity + " persons."; 
		}
	}
}
