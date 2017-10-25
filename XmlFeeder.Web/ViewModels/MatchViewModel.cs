namespace XmlFeeder.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using XmlFeeder.Models;

    public class MatchViewModel
    {
        public static Expression<Func<Match, MatchViewModel>> ToModel
        {
            get
            {
                return x => new MatchViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    MatchType = x.MatchType,
                    Bets = x.Bets.Select(b => new BetViewModel
                    {
                        Id = b.Id,
                        Name = b.Name,
                        IsLive = b.IsLive,
                        Odds = b.Odds.Select(o => new OddViewModel
                        {
                            Id = o.Id,
                            Name = o.Name,
                            Value = o.Value,
                            SpecialBetValue = o.SpecialBetValue
                        })
                    })
                };
            }
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }

        public IEnumerable<BetViewModel> Bets { get; set; }
    }
}