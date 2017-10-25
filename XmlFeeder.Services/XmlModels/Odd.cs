using RestSharp.Deserializers;
using System;
using System.Xml.Serialization;

namespace XmlFeeder.Services
{
    public class Odd
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        [DeserializeAs(Attribute = false, Name = "value")]
        public string TheValue { get; set; }

       // [DeserializeAs(Attribute = true, Name = "SpecialBetValue")]
        //public string SpecialBetValue { get; set; }
    }
}