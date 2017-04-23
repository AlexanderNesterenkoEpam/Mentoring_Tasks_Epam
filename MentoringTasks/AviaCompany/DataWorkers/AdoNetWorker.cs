using AviaCompany.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaCompany.DataWorkers
{
    public class AdoNetWorker
    {
        private string _connectionString;
        private SqlConnection connection;

        public AdoNetWorker(string connectionString)
        {
            _connectionString = connectionString;
            connection = new SqlConnection(_connectionString);
        }

        public void Create(Plane plane)
        {
            string sqlExpression = null;
            if(plane is CargoAirplane)
            {
                CargoAirplane cargoAirplane = plane as CargoAirplane;
                int id = GetMaxId("CargoAirplaneID", "CargoAirplanes") + 1;
                sqlExpression = String.Format("INSERT INTO CargoAirplanes (CargoAirplaneID, Name, FlightRange, Carrying) VALUES ({0}, '{1}', {2}, {3})", id, cargoAirplane.Name, cargoAirplane.FlightRange, cargoAirplane.Carrying);
            }
            else if(plane is PassengerAirplane)
            {
                PassengerAirplane cargoAirplane = plane as PassengerAirplane;
                int id = GetMaxId("PassengerAirplaneID", "PassengerAirplanes") + 1;
                sqlExpression = String.Format("INSERT INTO PassengerAirplanes (PassengerAirplaneID, Name, FlightRange, Capacity) VALUES ({0}, '{1}', {2}, {3})", id, cargoAirplane.Name, cargoAirplane.FlightRange, cargoAirplane.Capacity);
            }

            OpenConnection();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = ExecuteNonQuery(command);

            CloseConnection();
        }

        public void Update(Plane plane)
        {
            if (plane.Name != null)
            {
                string sqlExpression = null;
                if (plane is CargoAirplane)
                {
                    sqlExpression = String.Format("UPDATE CargoAirplanes SET Name = '{0}' WHERE CargoAirplaneId = {1}", plane.Name, plane.Id);
                }
                else if (plane is PassengerAirplane)
                {
                    sqlExpression = String.Format("UPDATE PassengerAirplanes SET Name = '{0}' WHERE PassengerAirplaneId = {1}", plane.Name, plane.Id);
                }

                OpenConnection();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = ExecuteNonQuery(command);
                
                CloseConnection();

                if(number == 0)
                {
                    throw new NoDataChangedException();
                }
            }            
        }

        public void Delete(Plane plane)
        {
            string sqlExpression = null;
            if (plane is CargoAirplane)
            {
                sqlExpression = String.Format("DELETE CargoAirplanes WHERE CargoAirplaneId = {0}", plane.Id);
            }
            else if (plane is PassengerAirplane)
            {
                sqlExpression = String.Format("DELETE PassengerAirplanes WHERE PassengerAirplaneId = {0}", plane.Id);
            }

            OpenConnection();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int number = ExecuteNonQuery(command);

            CloseConnection();

            if (number == 0)
            {
                throw new NoDataChangedException();
            }
        }

        public List<Plane> GetAll()
        {
            List<Plane> planes = new List<Plane>();
            planes.AddRange(GetPassengerAirplanes());
            planes.AddRange(GetCargoAirplanes());         
            return planes;
        }

        private List<PassengerAirplane> GetPassengerAirplanes()
        {
            List<PassengerAirplane> planes = new List<PassengerAirplane>();
            OpenConnection();
            string sqlExpression = "SELECT * FROM PassengerAirplanes";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    planes.Add(new PassengerAirplane()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        FlightRange = reader.GetInt32(2),
                        Capacity = reader.GetInt32(3)
                    });
                }
            }
            reader.Close();

            CloseConnection();
            return planes;
        }

        private List<CargoAirplane> GetCargoAirplanes()
        {
            List<CargoAirplane> planes = new List<CargoAirplane>();
            OpenConnection();
            string sqlExpression = "SELECT * FROM CargoAirplanes";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    planes.Add(new CargoAirplane()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        FlightRange = reader.GetInt32(2),
                        Carrying = reader.GetInt32(3)
                    });
                }
            }
            reader.Close();

            CloseConnection();

            return planes;
        }

        private int GetMaxId(string idColumnName, string tableName)
        {
            int maxId = 0;
            string sqlExpression = string.Format("SELECT MAX({0}) FROM {1}", idColumnName, tableName);

            OpenConnection();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) 
            {
                reader.Read();
                if(reader.IsDBNull(0) == false)
                {
                    maxId = reader.GetInt32(0);
                }                
            }

            reader.Close();

            CloseConnection();
            return maxId;            
        }

        private int ExecuteNonQuery(SqlCommand command)
        {
            int number = 0;
            try
            {
                number = command.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                CloseConnection();
                throw new ExecuteNonQueryException(ex);
            }
            return number;
        }

        private void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch(SqlException ex)
            {
                CloseConnection();
                throw new OpenConnectionException(ex);
            }
            
        }

        private void CloseConnection()
        {
            connection.Close();
        }
    }
}
