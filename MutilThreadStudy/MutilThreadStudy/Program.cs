using System;
using System.Threading;
using System.Threading.Tasks;

namespace MutilThreadStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTest threadTest = new ThreadTest();
            //threadTest.Run();

            ResetEventTest resetEvent = new ResetEventTest();

            Task.Run(() =>
            {
                resetEvent.MyFunc();
            });

            //设置MyFunc运行任务10s后才开始，开始5s后暂停，10s后再继续开始
            Thread.Sleep(10000);
            resetEvent.SetTrue();
            Thread.Sleep(5000);
            resetEvent.SetFalse();
            Thread.Sleep(10000);
            resetEvent.SetTrue();
       

            Console.ReadKey();
        }
    }
}
