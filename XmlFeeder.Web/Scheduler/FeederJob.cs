namespace XmlFeeder.Web
{
    using Microsoft.AspNet.SignalR;
    using Quartz;
    using System.Linq;
    using XmlFeeder.Data.Repositories;
    using XmlFeeder.Services;
    using XmlFeeder.Web.Hubs;
    using XmlFeeder.Web.ViewModels;

    public class FeederJob : IJob
    {
        private readonly IXmlFeederRequester requester;
        private readonly ISportsDataPopulationService populationService;
        private readonly IMapper mapper;
        private readonly IMatchesRepository matchesRepository;

        public FeederJob(
            IXmlFeederRequester requester, 
            ISportsDataPopulationService populationService,
            IMapper mapper,
            IMatchesRepository matchesRepository)
        {
            this.requester = requester;
            this.populationService = populationService;
            this.mapper = mapper;
            this.matchesRepository = matchesRepository;
        }

        public void Execute(IJobExecutionContext context)
        {
            var xmlFeed = this.requester.GetFeed();
            var sportsData = this.mapper.MapXmlSportsToDataModels(xmlFeed.Sports);
            populationService.PupulateData(sportsData);

            var matches = this.matchesRepository.GetAvailableMatches();
            var matchesVM = matches.Select(MatchViewModel.ToModel);
            // TODO: Think about FeedHubServer class
            FeedHub.Update(matchesVM);
        }
    }
}
