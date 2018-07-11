using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace PayEasyApi.UI.WebSite.Task
{
    public class SendMailTask
    {
        public bool _stopping = false;

        public SendMailTask()
        {

        }

        public void Run()
        {
            var aThread = new Thread(TaskLoop);
            aThread.IsBackground = true;
            aThread.Priority = ThreadPriority.BelowNormal;
            aThread.Start();
        }

        public void Stop()
        {
            _stopping = true;
        }

        private void Log(string msg)
        {
            System.IO.File.AppendAllText(@"C:\Temp\log.txt", msg + Environment.NewLine);
        }

        private void TaskLoop()
        {
            const int LoopIntervalInMinutes = 1000 * 60 * 1;

            Log("TaskLoop on thread ID: " + Thread.CurrentThread.ManagedThreadId.ToString());
            while (!_stopping)
            {
                try
                {
                    DoSendMail();
                }
                catch (Exception ex)
                {
                    // 發生意外時只記在 log 裡，不拋出 exception，以確保迴圈持續執行.
                    Log(ex.ToString());
                }
                finally
                {
                    // 每一輪工作完成後的延遲.
                    System.Threading.Thread.Sleep(LoopIntervalInMinutes);
                }
            }
        }

        private void DoSendMail()
        {
            // 發送 email。這裡只固定輸出一筆文字訊息至 log 檔案，方便觀察測試結果。
            string msg = String.Format("DoSendMail() at {0:yyyy/MM/dd HH:mm:ss}", DateTime.Now);
            Log(msg);
        }
    }
}