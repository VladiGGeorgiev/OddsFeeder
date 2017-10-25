namespace XmlFeeder.Web
{
    using Microsoft.AspNet.SignalR;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // TODO: Think about passing DependencyResolver.
            JobScheduler.Start(DependencyResolver.Current);
        }
    }
}

// 1. Fix XML decimal in Odds. 1.1. Try to add big XML in DB. (Deserialize XML, map to db objects, save in DB) XmlReader 
// 2. Create DB on app start

// Questions:
// 1. Which time zone is the times returned by the API
// 2. Should I display all of the information in the database, or only matches.
// 3. I can add templating engine in JavaScript for better quality.