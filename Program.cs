using System;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using HeyTask.Config;

namespace HeyTask
{
    public class Program
    {
        private static void Main(string[] args)
        {
            RunProgramRunExample().GetAwaiter().GetResult();
        }

        private static async Task RunProgramRunExample()
        {
            try
            {
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                await scheduler.Start();

                foreach (var tjob in JobsConfiguration.Jobs())
                {
                    await scheduler.ScheduleJob(tjob.Job, tjob.Trigger);
                }

                await Task.Delay(-1);
                await scheduler.Shutdown();

            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
    }

}