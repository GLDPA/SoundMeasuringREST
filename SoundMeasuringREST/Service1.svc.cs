using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand GetAllElements = new SqlCommand("SELECT * FROM [dbo].[Measurments]", con);

            SqlDataReader reader = GetAllElements.ExecuteReader();
            List<Measurments> measurmentList = new List<Measurments>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Measurments noise = new Measurments();

                    noise.ID = reader.GetInt32(0);
                    noise.DECIBEL = reader.GetInt32(0);
                    noise.DATE = reader.GetDateTime(1);

                    measurmentList.Add(noise);

                }
            }

            con.Close();
            return measurmentList;




        }

        public Measurments GetMeasurments(string id)
        {

            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand GetAllElements = new SqlCommand($"SELECT * FROM [dbo].[Measurments] WHERE id = {id}", con);
            SqlDataReader reader = GetAllElements.ExecuteReader();

            Measurments noise = new Measurments();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    noise.ID = reader.GetInt32(0);
                    noise.DECIBEL = reader.GetInt32(0);
                    noise.DATE = reader.GetDateTime(0);

                    


                }



            }
            con.Close();
            return noise;
        }

        
    }
}
