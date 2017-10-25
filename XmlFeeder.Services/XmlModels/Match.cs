using System;
using System.Collections.Generic;
using XmlFeeder.Models;

namespace XmlFeeder.Services
{
    public class Match
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }
        
        public List<Bet> Bets { get; set; }
    }
}