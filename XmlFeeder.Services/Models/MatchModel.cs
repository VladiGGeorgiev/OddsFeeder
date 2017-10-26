namespace XmlFeeder.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using XmlFeeder.Models;

    public class MatchModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string StartDateFormatted
        {
            get
            {
                return string.Format("{0} {1}", this.StartDate.ToShortDateString(), this.StartDate.ToShortTimeString());
            }
        }

        public string MatchType { get; set; }

        public IEnumerable<BetModel> Bets { get; set; }
    }
}