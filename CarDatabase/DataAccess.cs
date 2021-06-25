using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDatabase
{
    class DataAccess
    {
        private static OleDbConnection createConnection(string database = "Microsoft.ACE.OLEDB.12.0", string dataSource = "Hire.accdb")
        {   //Construct string for connection
            OleDbConnectionStringBuilder connBuilder = new OleDbConnectionStringBuilder();
            connBuilder.Add("Provider", database);
            connBuilder.Add("Data Source", dataSource);
            OleDbConnection conn = new OleDbConnection(connBuilder.ConnectionString);
            return conn;
        }
        public static List<Car> getAllCars()
        {   
            List<Car> carList = new List<Car>();
            try
            {
                OleDbConnection conn = createConnection();
                OleDbCommand cmd = conn.CreateCommand();
                conn.Open();
                //OleDb command
                OleDbCommand command = new OleDbCommand("select * from tblCar", conn);
                //Used to store the result from an OleDb statement
                OleDbDataReader dataReader = null;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Car tempCar = new Car();
                    tempCar.VehicleRegNo = dataReader[0].ToString();
                    tempCar.Make = dataReader[1].ToString();
                    tempCar.EngineSize = dataReader[2].ToString();
                    tempCar.DateRegistered = Convert.ToDateTime(dataReader[3].ToString());
                    tempCar.RentalPerDay = Convert.ToDouble(dataReader[4].ToString());
                    tempCar.Available = Convert.ToBoolean(dataReader[5].ToString());
                    carList.Add(tempCar);
                }
                dataReader.Close();
                command.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error***" + e.Message);
            }
            return carList;
        }
        public static void deleteCar(string vehicleReg)
        {
            try
            {
                OleDbConnection conn = createConnection();
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.DeleteCommand = new OleDbCommand("DELETE FROM tblCar WHERE VehicleRegNo ='" + vehicleReg + "'", conn);
                conn.Open();
                da.DeleteCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error***" + e.Message);
            }
        }
        public static void updateCar(string vehicleReg, string make, string engineSize, DateTime dateRegistered, double rentalPD, bool available)
        {
            try
            {
                OleDbConnection conn = createConnection();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("UPDATE tblCar SET Make=@Make, EngineSize=@ESize, DateRegistered=@DateReg, RentalPerDay=@RentalPD, Available=@Available" +
                                                     " WHERE VehicleRegNo=@Reg", conn);
                cmd.Parameters.AddWithValue("@Make", make);
                cmd.Parameters.AddWithValue("@ESize", engineSize);
                cmd.Parameters.AddWithValue("@DateReg", dateRegistered.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@RentalPD", rentalPD);
                cmd.Parameters.AddWithValue("@Available", Convert.ToByte(available));
                cmd.Parameters.AddWithValue("@Reg", vehicleReg);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error***" + e.Message);
            }
        }
        public static void addCar(string vehicleReg, string make, string engineSize, DateTime dateRegistered, double rentalPD, bool available)
        {
            try
            {
                OleDbConnection conn = createConnection();
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO tblCar VALUES" +
                        "(@Reg, @Make, @ESize, @DateReg, @RentalPD, @Available)", conn);
                    cmd.Parameters.Add(new OleDbParameter("@Reg", OleDbType.VarChar) { Value = vehicleReg });
                    cmd.Parameters.Add(new OleDbParameter("@Make", OleDbType.VarChar) { Value = make });
                    cmd.Parameters.Add(new OleDbParameter("@ESize", OleDbType.VarChar) { Value = engineSize });
                    cmd.Parameters.Add(new OleDbParameter("@DateReg", OleDbType.Date) { Value = dateRegistered });
                    cmd.Parameters.Add(new OleDbParameter("@RentalPD", OleDbType.Currency) { Value = rentalPD });
                    cmd.Parameters.Add(new OleDbParameter("@Available", OleDbType.Boolean) { Value = available });
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error***" + e.Message);
            }
        }
        public static List<Car> searchOperator(string type, string opType, string numberToCheck)
        {
            List<Car> carList = new List<Car>();
            try
            {
                OleDbConnection conn = createConnection();
                OleDbCommand cmd = conn.CreateCommand();
                if (type.Equals("RentalPerDay") || type == "Available")
                {
                    cmd.CommandText = "SELECT * FROM tblCar WHERE " + type + " " + opType + " " + numberToCheck + "";
                }
                else
                {   //Add quotes for varchar
                    cmd.CommandText = "SELECT * FROM tblCar WHERE " + type + " " + opType + " '" + numberToCheck + "'";
                }
                cmd.CommandType = CommandType.Text;
                conn.Open();
                OleDbDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Car tempCar = new Car();
                    tempCar.VehicleRegNo = dataReader[0].ToString();
                    tempCar.Make = dataReader[1].ToString();
                    tempCar.EngineSize = dataReader[2].ToString();
                    tempCar.DateRegistered = Convert.ToDateTime(dataReader[3].ToString());
                    tempCar.RentalPerDay = Convert.ToDouble(dataReader[4].ToString());
                    tempCar.Available = Convert.ToBoolean(dataReader[5].ToString());
                    carList.Add(tempCar);
                }
                dataReader.Close();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error***" + e.Message);
            }
            return carList;
        }
    }
}
