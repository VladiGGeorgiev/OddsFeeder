namespace XmlFeeder.Services.Models
{
    using System.Collections.Generic;

    public class DataModel
    {
        public IEnumerable<XmlFeeder.Models.Sport> Sports { get; set; }

        public IEnumerable<XmlFeeder.Models.Event> Events { get; set; }

        public IEnumerable<XmlFeeder.Models.Match> Matches { get; set; }

        public IEnumerable<XmlFeeder.Models.Bet> Bets { get; set; }

        public IEnumerable<XmlFeeder.Models.Odd> Odds { get; set; }
    }
}
