using System.Collections.Generic;

namespace XmlFeeder.Services
{
    public class Event
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int CategoryID { get; set; }
        
        public List<Match> Matches { get; set; }
    }
}