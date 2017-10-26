using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using XmlFeeder.Models;

namespace XmlFeeder.Services
{
    [Serializable()]
    public class Match
    {
        [XmlAttribute("ID")]
        public int ID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("StartDate")]
        public DateTime StartDate { get; set; }

        [XmlAttribute("MatchType")]
        public string MatchType { get; set; }

        [XmlElement("Bet")]
        public List<Bet> Bets { get; set; }
    }
}