using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlFeeder.Services
{
    [Serializable()]
    public class Event
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        [XmlAttribute("CategoryID")]
        public int CategoryID { get; set; }

        [XmlElement("Match")]
        public List<Match> Matches { get; set; }
    }
}