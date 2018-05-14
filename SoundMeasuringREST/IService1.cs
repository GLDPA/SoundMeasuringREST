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

        //[OperationContract]
        //[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "Measurments/{id}")]
        //Measurments GetMeasurments(string id);



        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "Delete/")]
        bool DeleteMeasurements(Measurments measurment);

    }
}
