using PayEasyApi.UI.WebSite.Task;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayEasyApi.UI.WebSite
{
    public class TaskConfig
    {
        public IScheduler _schedular = null;

        public void Initialize()
        {
            var schedulerFactory = new Quartz.Impl.StdSchedulerFactory();
            _schedular = schedulerFactory.GetScheduler();

            IJobDetail job = JobBuilder.Create<SendMailTaskTest>()
                          .WithIdentity("SendMailJob")
                          .Build();

            // 建立觸發器
            ITrigger trigger = TriggerBuilder.Create()
                                    .WithCronSchedule("0 0/1 * * * ?")  // 每一分鐘觸發一次。
                                    .WithIdentity("SendMailTrigger")
                                    .Build();

            // 把工作加入排程
            _schedular.ScheduleJob(job, trigger);

            // 啟動排程器
            _schedular.Start();
        }

        public void Sutdown()
        {
            _schedular.Shutdown(false);
        }
    }
}