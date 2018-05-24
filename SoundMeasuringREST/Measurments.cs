using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SoundMeasuringREST
{
    [DataContract]
    public class Measurments
    {       

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public double Temperature { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

        public Measurments()
        {
            
        }

        public Measurments(double temperature, DateTime date)
        {           
            Temperature = temperature;
            Date = date;
        }

        public Measurments(double temperature)
        {
            Temperature = temperature;
        }
    }
}