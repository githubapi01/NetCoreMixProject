using NetCoreMixProject.Common;
using NetCoreMixProject.Jobs;
using NetCoreMixProject.Models;
using NetCoreMixProject.Test;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace NetCoreMixProject
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.Info("app start");

            ITest test = new DOITest();
            test.Test();

            //Task t = MainAsync();
            "any key to exit...".C();
            Console.ReadKey();
            LogHelper.Info("app end");
        }
        static async Task MainAsync()
        {
            JobManager jobManager = new JobManager();
            //await jobManager.ExecuteTestJob();
            await jobManager.ExecuteSendEmailJob();
            //await jobManager.ExecuteRemoveExistsIdJob();
            "调度任务管理已启动".C();
        }
    }
}
