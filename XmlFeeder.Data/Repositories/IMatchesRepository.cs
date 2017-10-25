namespace XmlFeeder.Data.Repositories
{
    using System.Linq;
    using XmlFeeder.Models;

    public interface IMatchesRepository
    {
        IQueryable<Match> GetAvailableMatches();
    }
}
