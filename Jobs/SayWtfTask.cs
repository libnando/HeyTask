using System;
using System.Threading.Tasks;
using Quartz;

namespace HeyTask.Jobs
{

    public class SayWtfTask : IJob
    {

        public async Task Execute(IJobExecutionContext context)
        {

            await Console.Out.WriteLineAsync("-------------------- SayWtfTask - Begin " + DateTime.Now.ToString() + " --------------------");

            try
            {

                await Console.Out.WriteLineAsync("Wtf! ¬¬");

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync($" Error ... {e.Message}  \n");
            }

            await Console.Out.WriteLineAsync("-------------------- SayWtfTask - End__ " + DateTime.Now.ToString() + " -------------------- \n");


        }
    }



}