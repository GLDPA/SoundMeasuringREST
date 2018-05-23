using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;
using Dapper;

namespace SoundMeasuringREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string constr =
            "Server=tcp:davids-sql-server.database.windows.net,1433;Initial Catalog=Davids sql server;Persist Security Info=False;User ID=davidmalmberg;Password=Dak/Tha12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IList<Measurments> GetAllMeasurments()
        {
            string sqlQuery = "SELECT * FROM Measurments";

            using (IDbConnection tempMeasurement = new SqlConnection(constr))
            {
                var tempList = tempMeasurement.Query<Measurments>(sqlQuery).ToList();
                return tempList;
            }

        }

        public double GetAverage()
        {
            var m = GetAllMeasurments();
            
            double avg = 0;
            double sum = 0;
                
            foreach (var temp in GetAllMeasurments())
            {
                sum = sum + temp.Temperature;
            }

            avg = sum / m.Count;
            return avg;
        }

        public double GetAverageToday()
        {
            var m = GetAllMeasurments();

            double avg = 0;
            double sum = 0;

            foreach (var temp in GetAllMeasurments())
            {
                if (temp.Date = DateTime.Today)
                {
                    sum = sum + temp.Temperature;
                }
                avg = sum / m.Count;
            }
            return avg;
        }

        public double GetAverageWeek()
        {
            
            var m = GetAllMeasurments();

            double avg = 0;
            double sum = 0;

            foreach (var temp in GetAllMeasurments())
            {
                if (temp.Date = DateTime.Today.AddDays(-7))
                {
                     sum = sum + temp.Temperature;
                }
                 avg = sum / m.Count;
            }
            return avg;
        }


        public bool DeleteMeasurements(string id)
        {
            using (var sqlconnection = new SqlConnection(constr))
            {
                string sqlquery = $"DELETE FROM Measurments WHERE id = @Id";
                using (SqlCommand commandsql = new SqlCommand(sqlquery, sqlconnection))
                {
                    commandsql.Parameters.AddWithValue("@Id",  id);
                    sqlconnection.Open();
                    int resualt = commandsql.ExecuteNonQuery();
                    if (resualt < 0)
                    {
                        Console.WriteLine("ERROR!");
                    }

                    return true;
                }
            }
        }

        public Measurments CurrentMeasurment()
        {
            string sqlQuery = "SELECT * FROM Measurments";

            using (IDbConnection tempMeasurement = new SqlConnection(constr))
            {
                var tempList = tempMeasurement.Query<Measurments>(sqlQuery).ToList();

               var getCurrentMeasurment = tempList.Count - 1;

                return tempList[getCurrentMeasurment];
            }

        }


        



    }
}
