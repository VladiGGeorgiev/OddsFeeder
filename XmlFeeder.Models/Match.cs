namespace XmlFeeder.Models
{
    using System;
    using System.Collections.Generic;

    public class Match
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }

        public virtual List<Bet> Bets { get; set; }
    }
}
