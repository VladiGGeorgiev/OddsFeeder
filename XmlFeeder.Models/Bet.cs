namespace XmlFeeder.Models
{
    using System.Collections.Generic;

    public class Bet
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int MatchId { get; set; }

        public Match Match { get; set; }

        public virtual List<Odd> Odds { get; set; }
    }
}
