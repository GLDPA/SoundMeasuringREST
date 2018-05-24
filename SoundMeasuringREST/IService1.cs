using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoundMeasuringREST
{
    [ServiceContract]
    public interface IService1
    {


        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAllMeasurments/")]
        IList<Measurments> GetAllMeasurments();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAverage/")]
        double GetAverage();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAverageToday/")]
        double GetAverageToday();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "GetAverageWeek/")]
        double GetAverageWeek();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Current/")]
        Measurments CurrentMeasurment();

        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Delete/{id}")]
        bool DeleteMeasurements(string id);



    }
}
