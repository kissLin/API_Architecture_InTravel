using PayEasyApi.UI.WebSite.App_Start;
using PayEasyApi.UI.WebSite.Provider;
using PayEasyApi.UI.WebSite.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PayEasyApi.UI.WebSite
{
    // 注意: 如需啟用 IIS6 或 IIS7 傳統模式的說明，
    // 請造訪 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private TaskConfig TaskConfig = new TaskConfig();
        private TaskConfig1 TaskConfig1 = new TaskConfig1();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            TaskConfig.Initialize();
            TaskConfig1.Initialize();
            HangfireBootstrapper.Instance.Start();

            //ValueProviderFactories.Factories.Insert(0, new MyValueProviderFactory());
        }

        protected void Application_End()
        {
            TaskConfig.Sutdown();
            TaskConfig1.Sutdown();
            HangfireBootstrapper.Instance.Stop();

        }
    }
}