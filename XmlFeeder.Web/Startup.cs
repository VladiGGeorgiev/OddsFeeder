using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(XmlFeeder.Web.Startup))]
namespace XmlFeeder.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}