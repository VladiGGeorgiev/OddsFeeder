namespace XmlFeeder.Web.Hubs
{
    using Microsoft.AspNet.SignalR;
    using System.Collections.Generic;
    using XmlFeeder.Models;
    using XmlFeeder.Web.ViewModels;

    public class FeedHub : Hub
    {
        public void UpdateFeed(IEnumerable<MatchViewModel> matches)
        {
            Clients.All.updateFeed(matches);
        }

        public static void Update(IEnumerable<MatchViewModel> matches)
        {
            var feedContext = GlobalHost.ConnectionManager.GetHubContext<FeedHub>();
            feedContext.Clients.All.updateFeed(matches);
        }
    }
}