namespace XmlFeeder.Data.Repositories
{
    using System;
    using System.Linq;
    using XmlFeeder.Models;

    public class MatchesRepository : GenericRepository<Match>, IMatchesRepository
    {
        public MatchesRepository(IXmlFeederContext context) : base(context)
        {
        }

        public IQueryable<Match> GetAvailableMatches()
        {
            var tommorow = DateTime.UtcNow.AddDays(1);
            var matches = this.All()
                .Where(x =>
                    x.StartDate > DateTime.UtcNow &&
                    x.StartDate < tommorow &&
                    x.Bets.Any(b => b.Odds.Any()));

            return matches;
        }
    }
}
