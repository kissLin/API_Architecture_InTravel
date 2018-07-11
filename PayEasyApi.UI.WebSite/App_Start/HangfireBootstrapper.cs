using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PayEasyApi.UI.WebSite.App_Start
{
    public class HangfireBootstrapper : IRegisteredObject
    {
        public static readonly HangfireBootstrapper Instance = new HangfireBootstrapper();
        private readonly object _lockObject = new object();
        private bool _started;
        private BackgroundJobServer _backgroundJobServer;
        private HangfireBootstrapper()
        {

        }

        public void Start()
        {
            if (_started) return;
            _started = true;
            HostingEnvironment.RegisterObject(this);
            GlobalConfiguration.Configuration.UseSqlServerStorage("Data Source=10.1.6.33;Initial Catalog=EricDB;User ID=sa;Password=1q2w3e4r");
            _backgroundJobServer = new BackgroundJobServer();

        }

        public void Stop()
        {
            if (_backgroundJobServer != null)
            {
                _backgroundJobServer.Dispose();
            }
            HostingEnvironment.UnregisterObject(this);
        }

        void IRegisteredObject.Stop(bool immediate)
        {
            Stop();
        }

    }
}