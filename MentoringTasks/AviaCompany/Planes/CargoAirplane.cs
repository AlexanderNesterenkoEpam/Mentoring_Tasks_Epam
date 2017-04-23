using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany
{
    [Serializable]
	public class CargoAirplane : Plane
	{
		public int Carrying { get; set; }

		public CargoAirplane(int id, string name, int flightRange, int carrying) : base(id, name, flightRange)
		{
			this.Carrying = carrying;
		}

        public CargoAirplane()            
        {
            
        }

		public override string ToString()
		{
			return "Freighter: " + base.ToString() +"; Carrying: " + Carrying + "t.";
		}
	}
}
