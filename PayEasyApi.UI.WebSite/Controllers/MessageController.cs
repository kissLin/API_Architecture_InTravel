using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PayEasyApi.UI.WebSite.Controllers
{
    public class MessageController : ApiController
    {
        public IHttpActionResult Post()
        {
            RecurringJob.AddOrUpdate(() => Console.Write("Recurring"), Cron.Minutely());
            return Ok(); 
        }

        public IHttpActionResult Task()
        {
            BackgroundJob.Enqueue(() => Send());
            return Ok();

        }

        public static void Send()
        {
            Console.Write("由Hangfire發送的訊息:{message}, 時間:{DateTime.Now}");
        }

    }
}
