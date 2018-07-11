using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(PayEasyApi.UI.WebSite.Startup))]

namespace PayEasyApi.UI.WebSite
{
    public class Startup
    {
         public void Configuration(IAppBuilder app)
        {
            // 指定Hangfire使用記憶體儲存任務
            GlobalConfiguration.Configuration.UseMemoryStorage();
            // 啟用HanfireServer
            app.UseHangfireServer();
            // 啟用Hangfire的Dashboard
            app.UseHangfireDashboard();

            //RecurringJob.AddOrUpdate(
            //               () => Console.WriteLine("Recurring minuto!"),
            //               Cron.Minutely());
        }

    }
}