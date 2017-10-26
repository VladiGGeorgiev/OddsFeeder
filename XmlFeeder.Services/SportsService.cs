using System;
using System.Collections.Generic;
using System.Linq;
using XmlFeeder.Data.Repositories;
using XmlFeeder.Services.Models;

namespace XmlFeeder.Services
{
    public class SportsService : ISportsService
    {
        private const string MatchWinner = "Match Winner";
        private readonly IRepository<XmlFeeder.Models.Sport> sportsRepository;

        public SportsService(IRepository<XmlFeeder.Models.Sport> sportsRepository)
        {
            this.sportsRepository = sportsRepository;
        }

        public IEnumerable<SportModel> GetAllSports()
        {
            var tommorow = DateTime.UtcNow.AddDays(1);
            var now = DateTime.UtcNow;
            var sports = this.sportsRepository.All()
                .Where(x => x.Events.Any(e => e.Matches.Any(m => m.StartDate > now &&
                    m.StartDate < tommorow &&
                    m.Bets.Any(b => b.Odds.Any()))))
                .Select(x => new SportModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Events = x.Events
                        .Where(ev => ev.Matches.Any(m => m.StartDate > now &&
                            m.StartDate < tommorow &&
                            m.Bets.Any(b => b.Odds.Any())))
                        .Select(ev => new EventModel
                        {
                            Id = ev.Id,
                            Name = ev.Name,
                            IsLive = ev.IsLive,
                            CategoryId = ev.CategoryId,
                            Matches = ev.Matches
                                .Where(m => m.StartDate > now &&
                                    m.StartDate < tommorow &&
                                    m.Bets.Any(b => b.Odds.Any()))
                                .Select(m => new MatchModel
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                    StartDate = m.StartDate,
                                    MatchType = m.MatchType,
                                    Bets = m.Bets
                                        .Where(b => b.Name.Trim().Equals(MatchWinner))
                                        .Select(b => new BetModel
                                        {
                                            Id = b.Id,
                                            Name = b.Name,
                                            IsLive = b.IsLive,
                                            Odds = b.Odds.Select(o => new OddModel
                                            {
                                                Id = o.Id,
                                                Name = o.Name,
                                                Value = o.Value,
                                                SpecialBetValue = o.SpecialBetValue
                                            })
                                        })
                                })
                        })
                })
                .ToList();

            return sports;
        }
    }
}
