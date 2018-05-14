using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
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

        public bool DeleteMeasurements(Measurments measurment)
        {
            using (var sqlconnection = new SqlConnection())
            {
                string sqlquery = $"DELETE FROM Measurments WHERE Id = @Id";
                using (SqlCommand commandsql = new SqlCommand(sqlquery, sqlconnection))
                {
                    commandsql.Parameters.AddWithValue("@Id",  measurment.Id);
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

        //public Measurments GetMeasurments(string id)
        //{

        //    SqlConnection con = new SqlConnection(constr);
        //    con.Open();

        //    SqlCommand GetAllElements = new SqlCommand($"SELECT * FROM [dbo].[Measurments] WHERE id = {id}", con);
        //    SqlDataReader reader = GetAllElements.ExecuteReader();

        //    Measurments noise = new Measurments();

        //    if (reader.HasRows)
        //    {
        //        while (reader.Read())
        //        {
        //            noise.Id = reader.GetInt32(0);
        //            noise.Temperature = reader.GetInt32(0);
        //            noise.Date = reader.GetString(0);

                    


        //        }



        //    }
        //    con.Close();
        //    return noise;
        //}

        
    }
}
