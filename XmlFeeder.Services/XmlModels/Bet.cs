using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlFeeder.Services
{
    [Serializable()]
    public class Bet
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        [XmlElement("Odd")]
        public List<Odd> Odds { get; set; }
    }
}