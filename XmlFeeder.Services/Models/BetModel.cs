using System.Collections.Generic;

namespace XmlFeeder.Services.Models
{
    public class BetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public IEnumerable<OddModel> Odds { get; set; }
    }
}