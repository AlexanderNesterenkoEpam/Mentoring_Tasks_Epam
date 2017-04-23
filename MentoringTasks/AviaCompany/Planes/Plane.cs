using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AviaCompany
{
    [Serializable]
    [XmlInclude(typeof(PassengerAirplane))]
    [XmlInclude(typeof(CargoAirplane))]
    public abstract class Plane
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int FlightRange { get; set; }

		protected Plane(int id, string name, int flightRange)
		{
			Id = id;
			Name = name;
			FlightRange = flightRange;
		}

        public Plane()
        {
        }

		public override string ToString()
		{
			return "Id: " + Id + "; Name: " + Name + "; Flight range: " + FlightRange + " km.";
		}
	}
}
