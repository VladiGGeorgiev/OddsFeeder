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

// 1. Create DB on app start
// 2. Should I display all of the information in the database, or only matches.
// 3. I can add templating engine in JavaScript for better quality.
// 4. Move xml deserialization in class