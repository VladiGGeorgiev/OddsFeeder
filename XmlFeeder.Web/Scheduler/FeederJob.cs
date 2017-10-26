namespace XmlFeeder.Web
{
    using Quartz;
    using System.Linq;
    using XmlFeeder.Services;
    using XmlFeeder.Services.Models;
    using XmlFeeder.Web.Hubs;

    public class FeederJob : IJob
    {
        private readonly IXmlFeederRequester requester;
        private readonly ISportsDataPopulationService populationService;
        private readonly IMapper mapper;
        private readonly ISportsService sportsService;
        private readonly IXmlFeederSerializer serializer;

        public FeederJob(
            IXmlFeederRequester requester, 
            ISportsDataPopulationService populationService,
            IMapper mapper,
            ISportsService sportsService,
            IXmlFeederSerializer serializer)
        {
            this.requester = requester;
            this.populationService = populationService;
            this.mapper = mapper;
            this.sportsService = sportsService;
            this.serializer = serializer;
        }

        public void Execute(IJobExecutionContext context)
        {
            var xmlFeedString = this.requester.GetFeed();
            var xmlSports = this.serializer.Deserialize(xmlFeedString);
            var sportsData = this.mapper.MapXmlSportsToDataModels(xmlSports.Sports.ToList());
            populationService.PupulateData(sportsData);

            var sportsModel = new SportsModel { Sports = this.sportsService.GetAllSports() };
            // TODO: Think about FeedHubServer class
            FeedHub.Update(sportsModel);
        }
    }
}
