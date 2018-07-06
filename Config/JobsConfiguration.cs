using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using HeyTask.Jobs;
using Quartz;

namespace HeyTask.Config
{

    public static class JobsConfiguration
    {

        public static IEnumerable<JobConfigItem> Jobs()
        {

            var tasks = new List<JobConfigItem>();
            var config = ConfigurationManager.AppSettings;

            foreach (var configName in config.AllKeys)
            {

                if (!configName.Contains("T_")) { continue; }

                MethodInfo method = typeof(JobsConfiguration).GetMethod(configName.Replace("T_", ""));
                tasks.Add((JobConfigItem)method.Invoke(null, new object[] { config[configName] }));

            }

            return tasks;

        }

        private static ITrigger TriggerInterval(IJobDetail job, string expression)
        {
            return TriggerBuilder
                    .Create()
                    .WithIdentity("t" + job.Key.Name, job.Key.Group)
                    .StartNow()
                    .WithCronSchedule(expression)
                    .ForJob(job.Key.Name, job.Key.Group)
                    .Build();
        }

        #region declaration Jobs if necessary datamaps

        public static JobConfigItem SayHelloTask(string interval)
        {
            var job = JobBuilder.Create<SayHelloTask>().WithIdentity("SayHelloTask", "GSayHelloTask").Build();
            job.JobDataMap.Put("simpleParam", "rolling stone");
            return new JobConfigItem(TriggerInterval(job, interval), job);
        }

        public static JobConfigItem SayByeTask(string interval)
        {
            var job = JobBuilder.Create<SayByeTask>().WithIdentity("SayByeTask", "GSayByeTask").Build();
            job.JobDataMap.Put("simpleParam", "yellow submarine");
            return new JobConfigItem(TriggerInterval(job, interval), job);
        }

        #endregion

    }

}