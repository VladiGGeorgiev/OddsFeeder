namespace XmlFeeder.Web.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class FeedHub : Hub
    {
        public void UpdateFeed(XmlFeeder.Services.Models.SportsModel sports)
        {
            Clients.All.updateFeed(sports);
        }

        public static void Update(XmlFeeder.Services.Models.SportsModel sports)
        {
            var feedContext = GlobalHost.ConnectionManager.GetHubContext<FeedHub>();
            feedContext.Clients.All.updateFeed(sports);
        }
    }
}