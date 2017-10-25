namespace XmlFeeder.Services
{
    using MoreLinq;
    using System.Collections.Generic;
    using System.Linq;
    using XmlFeeder.Services.Models;

    public class Mapper : IMapper
    {
        public DataModel MapXmlSportsToDataModels(List<Sport> sports)
        {
            var sportsList = sports.Select(x => new XmlFeeder.Models.Sport
            {
                Id = x.ID,
                Name = x.Name
            });

            var events = sports
                .SelectMany(x => x.Events, (sport, ev) => new { SportId = sport.ID, Event = ev });
            var eventsList = events.Select(x => new XmlFeeder.Models.Event
            {
                Id = x.Event.ID,
                CategoryId = x.Event.CategoryID,
                IsLive = x.Event.IsLive,
                Name = x.Event.Name,
                SportId = x.SportId,
            });
            eventsList = eventsList.DistinctBy(x => x.Id);

            var matches = events.Select(x => x.Event).SelectMany(x => x.Matches, (ev, match) => new
            {
                EventId = ev.ID,
                Match = match
            });
            var matchesList = matches.Select(x => new XmlFeeder.Models.Match
            {
                Id = x.Match.ID,
                Name = x.Match.Name,
                StartDate = x.Match.StartDate,
                MatchType = x.Match.MatchType,
                EventId = x.EventId,
            });

            var bets = matches.Select(x => x.Match).SelectMany(x => x.Bets, (match, bet) => new
            {
                MatchId = match.ID,
                Bet = bet
            });
            var betsList = bets.Select(x => new XmlFeeder.Models.Bet
            {
                Id = x.Bet.ID,
                Name = x.Bet.Name,
                IsLive = x.Bet.IsLive,
                MatchId = x.MatchId
            });

            var odds = bets.Select(x => x.Bet).SelectMany(x => x.Odds, (bet, odd) => new
            {
                BetId = bet.ID,
                Odd = odd
            });
            var oddsList = odds.Select(x => new XmlFeeder.Models.Odd
            {
                Id = x.Odd.ID,
                Name = x.Odd.Name,
                Value = x.Odd.TheValue,
                //SpecialBetValue = x.Odd.SpecialBetValue
                BetId = x.BetId
            });


            return new DataModel
            {
                Sports = sportsList,
                Matches = matchesList,
                Events = eventsList,
                Bets = betsList,
                Odds = oddsList
            };
        }
    }
}
