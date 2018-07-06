using System;
using System.Threading.Tasks;
using Quartz;

namespace HeyTask.Jobs
{

    public class SayHelloTask : IJob
    {

        private string simpleParam;

        public async Task Execute(IJobExecutionContext context)
        {

            await Console.Out.WriteLineAsync("-------------------- SayHelloTask - Begin " + DateTime.Now.ToString() + " --------------------");


            try
            {
                simpleParam = (string)context.MergedJobDataMap["simpleParam"];

                //..

                await Console.Out.WriteLineAsync("Hello! ¬¬");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync($" Error ... {e.Message}  \n");
            }

            await Console.Out.WriteLineAsync("-------------------- SayHelloTask - End__ " + DateTime.Now.ToString() + " -------------------- \n");


        }
    }



}