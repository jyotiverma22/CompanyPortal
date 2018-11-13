using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyPortal.JobScheduling
{
    public class JobScheduler   
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<JobClass>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                                .WithIdentity("trigger1", "group1")
                                .WithCronSchedule("0 30 16 ? * 2-6",x=>x.WithMisfireHandlingInstructionIgnoreMisfires())
                                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}