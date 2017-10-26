namespace XmlFeeder.Services
{
    using XmlFeeder.Data.Repositories;
    using XmlFeeder.Services.Models;

    public class MatchesService : IMatchesService
    {
        private readonly IRepository<XmlFeeder.Models.Match> matchesRepository;
        private readonly IMapper mapper;

        public MatchesService(IRepository<XmlFeeder.Models.Match> matchesRepository, IMapper mapper)
        {
            this.matchesRepository = matchesRepository;
            this.mapper = mapper;
        }

        public MatchModel GetMatch(int id)
        {
            var match = this.matchesRepository.Find(id);
            MatchModel matchVM = this.mapper.MapMatchToMatchViewModel(match);

            return matchVM;
        }
    }
}
