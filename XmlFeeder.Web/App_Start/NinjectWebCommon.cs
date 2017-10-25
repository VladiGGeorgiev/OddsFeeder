[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(XmlFeeder.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(XmlFeeder.Web.App_Start.NinjectWebCommon), "Stop")]

namespace XmlFeeder.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using XmlFeeder.Services;
    using XmlFeeder.Data.Repositories;
    using XmlFeeder.Data;
    using Quartz;
    using Quartz.Impl;
    using System.Web.Mvc;
    using Ninject.Web.Mvc;
    using Microsoft.AspNet.SignalR;
    using XmlFeeder.Web.Hubs;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                kernel.Bind<IScheduler>().ToMethod(x =>
                {
                    var sched = new StdSchedulerFactory().GetScheduler();
                    sched.JobFactory = new NinjectJobFactory(kernel);
                    return sched;
                });

                kernel.Bind<IHubContext>().ToMethod(x =>
                {
                    return GlobalHost.ConnectionManager.GetHubContext<FeedHub>();
                });

                DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
                                
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Services
            kernel.Bind<IXmlFeederRequester>().To<XmlFeederRequester>();
            kernel.Bind<ISportsRepository>().To<SportsRepository>();
            kernel.Bind<IMatchesRepository>().To<MatchesRepository>();
            kernel.Bind<IXmlFeederContext>().To<XmlFeederContext>();
            kernel.Bind<IMapper>().To<Mapper>();
            
            kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            kernel.Bind<ISportsDataPopulationService>().To<SportsDataPopulationService>();
        }        
    }
}
