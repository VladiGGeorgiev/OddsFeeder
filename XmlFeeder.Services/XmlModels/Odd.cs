using RestSharp.Deserializers;
using System;
using System.Xml.Serialization;

namespace XmlFeeder.Services
{
    [Serializable()]
    public class Odd
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public string Value { get; set; }

        [XmlAttribute("SpecialBetValue")]
        public string SpecialBetValue { get; set; }
    }
}