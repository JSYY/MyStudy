using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutilThreadStudy
{
    public class ThreadCancelTest
    {
        private CancellationTokenSource cancellationToken;
        //使用CancellationTokenSource 在异步任务进行中时通过外部控制来将任务取消掉
        public ThreadCancelTest()
        {

        }

        public void cancelJob()
        {
            cancellationToken.Cancel();
        }

        public void ExcuetJob()
        {
            cancellationToken = new CancellationTokenSource();
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        //模拟异步任务进行中，持续检测是否取消掉
                        cancellationToken.Token.ThrowIfCancellationRequested();
                        Thread.Sleep(1000);
                        Console.WriteLine("Run");
                    }
                }
                catch(OperationCanceledException e)
                {
                    Console.WriteLine("catch exception: {0}",new object[] { e.Message });
                }
            },cancellationToken.Token);
        }
    }
}
