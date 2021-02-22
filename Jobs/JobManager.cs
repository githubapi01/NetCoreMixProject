using NetCoreMixProject.Common;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreMixProject.Jobs
{
    public class JobManager
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler;

        public JobManager()
        {
            _schedulerFactory = new StdSchedulerFactory();
        }

        public async Task<long> ExecuteRemoveExistsIdJob()
        {
            //1、通过调度工厂获得调度器
            _scheduler = await _schedulerFactory.GetScheduler();
            //2、开启调度器
            await _scheduler.Start();
            //3、触发器 ，定义触发时间，使用core表达式来定义
            ITrigger trigger = TriggerBuilder.Create()
                       .WithCronSchedule("0 30 4 * * ?")// 
                       .UsingJobData("key1", 321)//参数
                       .UsingJobData("key2", "trigger-key2")
                       .Build();
            //4、Job ,具体业务实现，继承Quartz.IJob
            IJobDetail job = JobBuilder.Create<RemoveExistsIDJob>()
                            .WithIdentity("job", "group")
                            .Build();

            DateTimeOffset result = await _scheduler.ScheduleJob(job, trigger);
            "ExecuteRemoveExistsIdJob start...".C();
            //返回结果
            return await Task.FromResult(result.Ticks);
        }

        public async Task<long> ExecuteSendEmailJob()
        {
            _scheduler = await _schedulerFactory.GetScheduler();
            await _scheduler.Start();

            ITrigger trigger = TriggerBuilder.Create()
                .WithCronSchedule("0 10 9 ? * MON-FRI")
                //.WithCronSchedule("1/20 * * * * ? ")//test
                .Build();

            IJobDetail job = JobBuilder.Create<SendEmailJob>()                
                .Build();

            DateTimeOffset result = await _scheduler.ScheduleJob(job ,trigger);
            "ExecuteSendEmailJob start...".C();
            return result.Ticks;
        }

        public async Task<long> ExecuteTestJob()
        {
            _scheduler = await _schedulerFactory.GetScheduler();
            await _scheduler.Start();
            ITrigger trigger = TriggerBuilder.Create()
                .WithCronSchedule("1/10 * * * * ? ")
                .Build();

            IJobDetail job = JobBuilder.Create<TestJob>()
                .WithIdentity("testjob","group1")
                .Build();

            DateTimeOffset result = await _scheduler.ScheduleJob(job ,trigger);
            "ExecuteTestJob start...".C();
            return await Task.FromResult(result.Ticks);
        }
    }
}
