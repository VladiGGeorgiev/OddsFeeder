namespace XmlFeeder.Services
{
    using XmlFeeder.Data.Repositories;
    using XmlFeeder.Services.Models;

    public class SportsDataPopulationService : ISportsDataPopulationService
    {
        private readonly IRepository<XmlFeeder.Models.Sport> sportsRepository;
        private readonly IRepository<XmlFeeder.Models.Event> eventsRepository;
        private readonly IRepository<XmlFeeder.Models.Match> matchesRepository;
        private readonly IRepository<XmlFeeder.Models.Bet> betsRepository;
        private readonly IRepository<XmlFeeder.Models.Odd> oddsRepository;

        public SportsDataPopulationService(
            IRepository<XmlFeeder.Models.Sport> sportsRepository,
            IRepository<XmlFeeder.Models.Event> eventsRepository,
            IRepository<XmlFeeder.Models.Match> matchesRepository,
            IRepository<XmlFeeder.Models.Bet> betsRepository,
            IRepository<XmlFeeder.Models.Odd> oddsRepository)
        {
            this.sportsRepository = sportsRepository;
            this.eventsRepository = eventsRepository;
            this.matchesRepository = matchesRepository;
            this.betsRepository = betsRepository;
            this.oddsRepository = oddsRepository;
        }

        public void PupulateData(DataModel data)
        {
            sportsRepository.BulkMerge(data.Sports);
            eventsRepository.BulkMerge(data.Events);
            matchesRepository.BulkMerge(data.Matches);
            betsRepository.BulkMerge(data.Bets);
            oddsRepository.BulkMerge(data.Odds);
        }
    }
}
