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
        public int ID { get; set; }
        [DataMember]
        public double DECIBEL { get; set; }
        [DataMember]
        public DateTime DATE { get; set; }

        public Measurments()
        {
            
        }

        public Measurments(int id, double decibel, DateTime date)
        {
            ID = id;
            DECIBEL = decibel;
            DATE = date;
        }


    }
}