namespace XmlFeeder.Web
{
    using Quartz;
    using Quartz.Impl;
    using System.Web.Mvc;
    using XmlFeeder.Services;

    public class JobScheduler
    {
        public static void Start(IDependencyResolver dependencyResolver)
        {
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            IScheduler scheduler = dependencyResolver.GetService<IScheduler>();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<FeederJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(60).RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}
