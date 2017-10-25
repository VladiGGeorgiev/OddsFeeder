namespace XmlFeeder.Models
{
    using System.Collections.Generic;

    public class Event
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int CategoryId { get; set; }

        public int SportId { get; set; }

        public Sport Sport { get; set; }

        public virtual List<Match> Matches { get; set; }
    }
}
