namespace XmlFeeder.Services.Models
{
    using System.Collections.Generic;

    public class EventModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int CategoryId { get; set; }
        
        public IEnumerable<MatchModel> Matches { get; set; }
    }
}