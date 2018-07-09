using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TB.AspNetCore.Quarzt.Service.Quartz
{
    public class HttpJob : IJob
    {
        

        public async Task Execute(IJobExecutionContext context)
        {
            //更具任务组执行具体的任务
            //MyLogger.WriteMessage("gogogo");
            await Console.Out.WriteLineAsync("Greetings from HelloJob!");
        }
    }
}
