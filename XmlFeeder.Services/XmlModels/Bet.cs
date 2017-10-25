using System.Collections.Generic;

namespace XmlFeeder.Services
{
    public class Bet
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }
        
        public List<Odd> Odds { get; set; }
    }
}