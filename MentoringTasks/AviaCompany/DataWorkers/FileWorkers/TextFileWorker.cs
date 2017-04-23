using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany.FileWorkers
{
    public class TextFileWorker : BaseFileWorker
    {
        public TextFileWorker(string filePath) : base(filePath)
        {

        }

        public override void Save(List<Plane> planes)
        {
            string planesToSave = "";
            foreach(var plane in planes)
            {
                if(plane is CargoAirplane)
                {
                    CargoAirplane cargoAirplane = plane as CargoAirplane;
                    planesToSave += string.Format("{0},{1},{2},{3},{4}\n", cargoAirplane.GetType().Name, cargoAirplane.Id, cargoAirplane.Name, cargoAirplane.FlightRange, cargoAirplane.Carrying);
                }
                else if (plane is PassengerAirplane)
                {
                    PassengerAirplane passengerAirplane = plane as PassengerAirplane;
                    planesToSave += string.Format("{0},{1},{2},{3},{4}\n", passengerAirplane.GetType().Name, passengerAirplane.Id, passengerAirplane.Name, passengerAirplane.FlightRange, passengerAirplane.Capacity);
                }
            }
            FileInfo fileInfo = new FileInfo(_filePath);
            using (TextWriter txtWriter = new StreamWriter(fileInfo.Open(FileMode.Create)))
            {
                txtWriter.Write(planesToSave);
            }
        }
        public override List<Plane> Load()
        {
            List<Plane> planes = null;
            FileInfo fileInfo = new FileInfo(_filePath);
            using (TextReader txtReader = new StreamReader(fileInfo.Open(FileMode.Open)))
            {
                string planesString = txtReader.ReadToEnd();
                string[] planesStrings = planesString.Split(new char[1]{'\n'}, StringSplitOptions.RemoveEmptyEntries);
                if(planesStrings.Length > 0)
                {
                    planes = new List<Plane>();
                }
                foreach(var planeString in planesStrings)
                {
                    string[] planeProperties = planeString.Split(',');
                    if(planeProperties[0] == "CargoAirplane")
                    {
                        //TODO::Add validation here
                        planes.Add(new CargoAirplane(int.Parse(planeProperties[1]), planeProperties[2], int.Parse(planeProperties[3]), int.Parse(planeProperties[4])));
                    }
                    else if (planeProperties[0] == "PassengerAirplane")
                    {
                        planes.Add(new PassengerAirplane(int.Parse(planeProperties[1]), planeProperties[2], int.Parse(planeProperties[3]), int.Parse(planeProperties[4])));
                    }
                }

            }
            return planes;
        }
    }
}
