using XmlFeeder.Services.Models;

namespace XmlFeeder.Services
{
    public interface IMatchesService
    {
        MatchModel GetMatch(int id);
    }
}
