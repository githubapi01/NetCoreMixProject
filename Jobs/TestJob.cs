using NetCoreMixProject.Common;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreMixProject.Jobs
{
    public class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(()=>{
                "TestJob Start...".C();
                LogHelper.Error("TestJob Start...");
                System.Threading.Thread.Sleep(3000);
                "TestJob Finished...".C();
                LogHelper.Error("TestJob Finished...");
                LogHelper.Error("error test ",new Exception("excepton by self"));
            });
        }
    }
}
