using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany
{
	public class ConsoleWorker
	{
        public void ClearConsole()
        {
            Console.Clear();
        }

        public void ShowException(Exception ex)
        {
            Console.WriteLine(ex.Message);
            if(ex.InnerException != null)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public int ChooseOperation()
        {
            int number = 0;
            int[] numbers = new[] { 0, 1, 2, 3, 4, 5 };

            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose operation: ");
                Console.WriteLine("1 - Find Plane");
                Console.WriteLine("2 - Txt file - Save/Load");
                Console.WriteLine("3 - Binary file - Save/Load");
                Console.WriteLine("4 - XML file - Save/Load");
                Console.WriteLine("5 - Database");
                Console.WriteLine("0 - Exit");

                number = ReadIntegerNumberFromConsole();

            } while (!numbers.Contains(number));

            if (number == 0)
            {
                Environment.Exit(1);
            }

            return number;
        }

        public int ChooseFileOperation()
        {
            int number = 0;
            int[] numbers = new[] { 0, 1, 2 };

            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose operation with file:");
                Console.WriteLine("1 - Save planes");
                Console.WriteLine("2 - Load planes");
                Console.WriteLine("0 - Exit");

                number = ReadIntegerNumberFromConsole();

            } while (!numbers.Contains(number));

            if (number == 0)
            {
                Environment.Exit(1);
            }

            return number;
        }

        public int ChooseDatabaseOperation()
        {
            int number = 0;
            int[] numbers = new[] { 0, 1, 2, 3 };

            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose operation with database:");
                Console.WriteLine("1 - Create plane");
                Console.WriteLine("2 - Update plane name");
                Console.WriteLine("3 - Delete plane by id");
                Console.WriteLine("0 - Exit");

                number = ReadIntegerNumberFromConsole();

            } while (!numbers.Contains(number));

            if (number == 0)
            {
                Environment.Exit(1);
            }

            return number;
        }

        public Plane CreatePlane()
        {
            int number = 0;
            int[] numbers = new[] { 0, 1, 2 };

            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose type of plane to create:");
                Console.WriteLine("1 - Passenger airplane");
                Console.WriteLine("2 - Cargo airplane");
                Console.WriteLine("0 - Exit");

                number = ReadIntegerNumberFromConsole();

            } while (!numbers.Contains(number));

            if (number == 0)
            {
                Environment.Exit(1);
            }

            if(number == 1)
            {
                PassengerAirplane passengerAirplane = new PassengerAirplane();
                Console.Write("Name: ");
                passengerAirplane.Name = Console.ReadLine();
                Console.Write("Flight range: ");
                passengerAirplane.FlightRange = ReadIntegerNumberFromConsole();
                Console.Write("Capacity: ");
                passengerAirplane.Capacity = ReadIntegerNumberFromConsole();
                return passengerAirplane;
            }
            else if(number == 2)
            {
                CargoAirplane cargoAirplane = new CargoAirplane();
                Console.Write("Name: ");
                cargoAirplane.Name = Console.ReadLine();
                Console.Write("Flight range: ");
                cargoAirplane.FlightRange = ReadIntegerNumberFromConsole();
                Console.Write("Carrying: ");
                cargoAirplane.Carrying = ReadIntegerNumberFromConsole();
                return cargoAirplane;
            }

            return null;
        }

        public Plane UpdatePlane()
        {
            int number = 0;
            int[] numbers = new[] { 0, 1, 2 };

            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose type of plane to update:");
                Console.WriteLine("1 - Passenger airplane");
                Console.WriteLine("2 - Cargo airplane");
                Console.WriteLine("0 - Exit");

                number = ReadIntegerNumberFromConsole();

            } while (!numbers.Contains(number));

            if (number == 0)
            {
                Environment.Exit(1);
            }

            Plane plane = null;
            if (number == 1)
            {
                plane = new PassengerAirplane();
            }
            else if (number == 2)
            {
                plane = new CargoAirplane();
            }

            if(plane != null)
            {
                Console.Write("Id: ");
                plane.Id = ReadIntegerNumberFromConsole();
                Console.Write("New name (leave empty to not update): ");
                plane.Name = Console.ReadLine();
            }

            return plane;
        }

        public Plane DeletePlane()
        {
            int number = 0;
            int[] numbers = new[] { 0, 1, 2 };

            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose type of plane to delete:");
                Console.WriteLine("1 - Passenger airplane");
                Console.WriteLine("2 - Cargo airplane");
                Console.WriteLine("0 - Exit");

                number = ReadIntegerNumberFromConsole();

            } while (!numbers.Contains(number));

            if (number == 0)
            {
                Environment.Exit(1);
            }

            Plane plane = null;
            if (number == 1)
            {
                plane = new PassengerAirplane();
            }
            else if (number == 2)
            {
                plane = new CargoAirplane();
            }

            if (plane != null)
            {
                Console.Write("Id: ");
                plane.Id = ReadIntegerNumberFromConsole();
            }

            return plane;
        }

		public int ChoseKindOfPlaneToFind()
		{
			int number = 0;
			int[] numbers = new[] {0, 1, 2};

			do
			{
				Console.WriteLine();
				Console.WriteLine("Find Plane: ");
				Console.WriteLine("Which type of planes do you want to find?");
				Console.WriteLine("1 - Passenger airplane");
				Console.WriteLine("2 - Cargo airplane");
				Console.WriteLine("0 - Exit");

				number = ReadIntegerNumberFromConsole();

			} while (!numbers.Contains(number));

			if (number == 0)
			{
				Environment.Exit(1);
			}

			return number;
		}

		private static int ReadIntegerNumberFromConsole()
		{
			bool isParsed = false;
			int number = 0;
			int wrongInputCount = 0;

			do
			{
				wrongInputCount++;

				if (wrongInputCount > 1)
				{
					Console.WriteLine("Wrong input! You must input only numbers. Try again: ");
				}

				isParsed = Int32.TryParse(Console.ReadLine(), out number);
			}
			while (isParsed == false || number < 0);

			return number;
		}

		public int[] InputPassengerPlaneAttributesToFind()
		{
			Console.WriteLine("You finding Passenger airplanes: ");
			Console.WriteLine("Input capacity from: ");
			int capacityFrom = ReadIntegerNumberFromConsole();
			Console.WriteLine("Input capacity to: ");
			int capacityTo = ReadIntegerNumberFromConsole();

			Console.WriteLine("Input flight range from: ");
			int flightRangeFrom = ReadIntegerNumberFromConsole();
			Console.WriteLine("Input flight range to: ");
			int flightRangeTo = ReadIntegerNumberFromConsole();

			int[] attributes = { capacityFrom, capacityTo, flightRangeFrom, flightRangeTo};

			return attributes;
		}

		public int[] InputCargoPlaneAttributesToFind()
		{
			Console.WriteLine("You finding cargo airplanes: ");
			Console.WriteLine("Input carrying from: ");
			int carryingFrom = ReadIntegerNumberFromConsole();
			Console.WriteLine("Input carrying to: ");
			int carryingTo = ReadIntegerNumberFromConsole();

			Console.WriteLine("Input flight range from: ");
			int flightRangeFrom = ReadIntegerNumberFromConsole();
			Console.WriteLine("Input flight range to: ");
			int flightRangeTo = ReadIntegerNumberFromConsole();

			int[] attributes = { carryingFrom, carryingTo, flightRangeFrom, flightRangeTo };

			return attributes;
		}
	}
}
