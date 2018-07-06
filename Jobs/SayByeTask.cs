using System;
using System.Threading.Tasks;
using Quartz;

namespace HeyTask.Jobs
{

    public class SayByeTask : IJob
    {

        private string simpleParam;

        public async Task Execute(IJobExecutionContext context)
        {

            await Console.Out.WriteLineAsync("-------------------- SayByeTask - Begin " + DateTime.Now.ToString() + " --------------------");


            try
            {
                simpleParam = (string)context.MergedJobDataMap["simpleParam"];

                //..

                await Console.Out.WriteLineAsync("Bye! ¬¬");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync($" Error ... {e.Message}  \n");
            }

            await Console.Out.WriteLineAsync("-------------------- SayByeTask - End__ " + DateTime.Now.ToString() + " -------------------- \n");


        }
    }



}