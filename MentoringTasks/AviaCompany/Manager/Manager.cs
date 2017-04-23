using AviaCompany.DataWorkers;
using AviaCompany.Exceptions;
using AviaCompany.FileWorkers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany
{
	public class Manager
	{
		private ConsoleWorker _consoleWorker = new ConsoleWorker();

		public void StartWork(bool readFromDb)
		{
            AviaCompany aviaCompany;
            if (readFromDb)
            {

                aviaCompany = new AviaCompany("Belarus Airlines", LoadPlanes());
            }
            else
            {
                List<Plane> listOfPlanes = this.CreateListOfPlanes();

                aviaCompany = this.CreateAviaCompanyAndAddPlanes("Belarus Airlines", listOfPlanes);
            }
			
			Report report = new Report();
			
            int numberOfOperation;
            do
            {
                _consoleWorker.ClearConsole();
                report.ShowAviaCompanyPlanes(aviaCompany);

                int totalCapacity = this.ConuntTotalCapacity(aviaCompany);
                double totalCarrying = this.CountTotalCarrying(aviaCompany);

                report.ShowTotalCarrying(totalCarrying);
                report.ShowTotalCapacity(totalCapacity);

                report.ShowAviaCompanyPlanes(aviaCompany.SortPlanesByFlightRange());

                numberOfOperation = _consoleWorker.ChooseOperation();
                try
                {
                    aviaCompany = this.PerformOperation(aviaCompany, numberOfOperation);
                }                
                catch(FileNotFoundException ex)
                {
                    _consoleWorker.ShowException(ex);
                }
                catch(OutOfMemoryException ex)
                {
                    _consoleWorker.ShowException(ex);
                }
                catch(SerializationException ex)
                {
                    _consoleWorker.ShowException(ex);
                }
                catch(InvalidOperationException ex)
                {
                    _consoleWorker.ShowException(ex);
                }                
            } while (numberOfOperation != 0);
            
		}

		public List<Plane> CreateListOfPlanes()
		{
			List<Plane> planesListToAdd = new List<Plane>();

			PassengerAirplane airliner = new PassengerAirplane(1, "Airbus A380", 3000, 230);
			PassengerAirplane airliner2 = new PassengerAirplane(2, "Boeing 737", 2000, 150);
			PassengerAirplane airliner3 = new PassengerAirplane(3, "Airbus 370", 4000, 120);

			CargoAirplane freighter = new CargoAirplane(4, "Boeing C17", 2500, 250);
			CargoAirplane freighter2 = new CargoAirplane(5, "Boeing C16", 3500, 300);
			CargoAirplane freighter3 = new CargoAirplane(6, "Boeing C15", 4500, 150);

			planesListToAdd.Add(airliner);
			planesListToAdd.Add(airliner2);
			planesListToAdd.Add(airliner3);

			planesListToAdd.Add(freighter);
			planesListToAdd.Add(freighter2);
			planesListToAdd.Add(freighter3);

			return planesListToAdd;
		}

		public AviaCompany CreateAviaCompanyAndAddPlanes(string companyName, List<Plane> listOfPlanes)
		{
			AviaCompany aviaCompany = new AviaCompany(companyName, listOfPlanes);

			return aviaCompany;
		}

		public void AddPlaneToCompany(AviaCompany company, Plane plane)
		{
			company.ListOfPlanes.Add(plane);
		}

		public void RemovePlaneById(AviaCompany company, int id)
		{
			company.ListOfPlanes.Remove(company.ListOfPlanes.First(x => x.Id == id));
		}

		public int ConuntTotalCapacity(AviaCompany company)
		{
			int totalCapacity = 0;

			if(company.ListOfPlanes != null)
            {
                foreach (var plane in company.ListOfPlanes)
                {
                    if (plane is PassengerAirplane)
                    {
                        totalCapacity += ((PassengerAirplane)plane).Capacity;
                    }
                }
            }            

			return totalCapacity;
		}

		public int CountTotalCarrying(AviaCompany company)
		{
			int totalCarrying = 0;

			if(company.ListOfPlanes != null)
            {
                foreach (var plane in company.ListOfPlanes)
                {
                    if (plane is CargoAirplane)
                    {
                        totalCarrying += ((CargoAirplane)plane).Carrying;
                    }
                }
            }           

			return totalCarrying;
		}
	
		public Plane FindPlaneById(AviaCompany aviaCompany, int id)
		{
			Plane plane = aviaCompany.ListOfPlanes.Find(o => o.Id == id);
			return plane;
		}

        private List<Plane> LoadPlanes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            AdoNetWorker adoNetWorker = new AdoNetWorker(connectionString);
            try
            {
                return adoNetWorker.GetAll();
            }
            catch(OpenConnectionException ex)
            {
                _consoleWorker.ShowException(ex);
                return null;
            }
            
        }
        
        private AviaCompany PerformOperation(AviaCompany aviaCompany, int numberOfOperation)
        {
            AviaCompany changedAviacompany = aviaCompany;
            switch(numberOfOperation)
            {
                case 1:
                    Report report = new Report();
                    int numberOfPlaneKind = _consoleWorker.ChoseKindOfPlaneToFind();
                    Plane plane = this.FindPlane(aviaCompany, numberOfPlaneKind);
                    report.ShowFounedPlane(plane);
                    break;
                case 2:
                    changedAviacompany = FileOperation(new TextFileWorker("planes.txt"), aviaCompany);
                    break;
                case 3:
                    changedAviacompany = FileOperation(new BinFileWorker("planes.bin"), aviaCompany);
                    break;
                case 4:
                    changedAviacompany = FileOperation(new XmlFileWorker("planes.xml"), aviaCompany);
                    break;
                case 5:
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    changedAviacompany = DatabaseOperation(connectionString, aviaCompany);
                    break;

            }
            return changedAviacompany;
        }

        private AviaCompany DatabaseOperation(string connectionString, AviaCompany aviaCompany)
        {
            AviaCompany changedAviacompany = aviaCompany;
            int numberOfDatabaseOperation = _consoleWorker.ChooseDatabaseOperation();
            AdoNetWorker adoNetWorker = new AdoNetWorker(connectionString);
            try
            {
                switch (numberOfDatabaseOperation)
                {
                    case 1:
                        Plane newPlane = _consoleWorker.CreatePlane();
                        adoNetWorker.Create(newPlane);
                        break;
                    case 2:
                        Plane updatedPlane = _consoleWorker.UpdatePlane();
                        adoNetWorker.Update(updatedPlane);
                        break;
                    case 3:
                        Plane deletedPlane = _consoleWorker.DeletePlane();
                        adoNetWorker.Delete(deletedPlane);
                        break;
                }
            }
            catch (OpenConnectionException ex)
            {
                _consoleWorker.ShowException(ex);
            }
            catch (ExecuteNonQueryException ex)
            {
                _consoleWorker.ShowException(ex);
            }
            catch(NoDataChangedException ex)
            {
                _consoleWorker.ShowException(ex);
            }
            catch(SqlException ex)
            {
                _consoleWorker.ShowException(ex);
            }
            
            List<Plane> planes = adoNetWorker.GetAll();
            changedAviacompany = new AviaCompany(changedAviacompany.Name, planes);
            return changedAviacompany;
        }

        private AviaCompany FileOperation(BaseFileWorker fileWorker, AviaCompany aviaCompany)
        {
            AviaCompany changedAviacompany = aviaCompany;
            int numberOfFileOperation = _consoleWorker.ChooseFileOperation();
            switch (numberOfFileOperation)
            {
                case 1:
                    fileWorker.Save(aviaCompany.ListOfPlanes);
                    break;
                case 2:
                    changedAviacompany = new AviaCompany(aviaCompany.Name, fileWorker.Load());
                    break;
            }

            return changedAviacompany;
        }

		private Plane FindPlane(AviaCompany aviaCompany, int numberOfPlaneKind)
		{
			Plane plane = null;

			switch (numberOfPlaneKind)
			{	
				case 1 :
					int[] passengerPlaneAttributes = _consoleWorker.InputPassengerPlaneAttributesToFind();
					plane = FindPassengerAirlineByAttributes(aviaCompany, passengerPlaneAttributes);
					break;
				case 2:
					int[] cargoPlaneAttributes = _consoleWorker.InputCargoPlaneAttributesToFind();
					plane = FindCargoAirlineByAttributes(aviaCompany, cargoPlaneAttributes);
					break;
				default:
					plane = FindPassengerAirlineByAttributes(aviaCompany, _consoleWorker.InputPassengerPlaneAttributesToFind());
					break;
			}

			return plane;
		}

		private PassengerAirplane FindPassengerAirlineByAttributes(AviaCompany aviaCompany, int[] attributes)
		{
			foreach (var plane in aviaCompany.ListOfPlanes)
			{
				if (plane is PassengerAirplane)
				{
					if (((PassengerAirplane)plane).Capacity >= attributes[0] && ((PassengerAirplane)plane).Capacity <= attributes[1]
						&& ((PassengerAirplane)plane).FlightRange >= attributes[2] && ((PassengerAirplane)plane).FlightRange <= attributes[3])
					{
						return ((PassengerAirplane) plane);
					}
				}
			}

			return null;
		}

		private CargoAirplane FindCargoAirlineByAttributes(AviaCompany aviaCompany, int[] attributes)
		{
			foreach (var plane in aviaCompany.ListOfPlanes)
			{
				if (plane is CargoAirplane)
				{
					if (((CargoAirplane)plane).Carrying >= attributes[0] && ((CargoAirplane)plane).Carrying <= attributes[1]
						&& ((CargoAirplane)plane).FlightRange >= attributes[2] && ((CargoAirplane)plane).FlightRange <= attributes[3])
					{
						return ((CargoAirplane)plane);
					}
				}
			}

			return null;
		}
	}
}
