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
        public string Date { get; set; }

        public Measurments()
        {
            
        }

        public Measurments(int id, double temperature, string date)
        {
            Id = id;
            Temperature = temperature;
            Date = date;
        }


    }
}