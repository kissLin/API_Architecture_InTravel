using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PayEasyApi.UI.WebSite.Task
{
    public class SendXmlTask : IJob
    {
        private void Log(string msg)
        {
            System.IO.File.AppendAllText(@"C:\Temp\logxml.txt", msg + Environment.NewLine);
        }

        public void DoSendMail()
        {
            Log("Entering DoSendMail() at " + DateTime.Now.ToString());
            // 發送 email。這裡只固定輸出一筆文字訊息至 log 檔案，方便觀察測試。
            // 每發送一封 email 就檢查一次 IntervalTask.Current.SuttingDown 以配合外部的終止事件。
            string msg = String.Format("DoSendMail() at {0:yyyy/MM/dd HH:mm:ss}", DateTime.Now);
            Log(msg);
            Thread.Sleep(2000);
        }

        public void Execute(IJobExecutionContext context)
        {
            DoSendMail();
        }
    }
}