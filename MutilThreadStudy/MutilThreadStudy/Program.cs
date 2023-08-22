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

            //ManualResetEventTest resetEvent = new ManualResetEventTest();

            //Task.Run(() =>
            //{
            //    resetEvent.MyFunc();
            //});

            ////设置MyFunc运行任务10s后才开始，开始5s后暂停，10s后再继续开始
            //Thread.Sleep(10000);
            //resetEvent.SetTrue();
            //Thread.Sleep(5000);
            //resetEvent.SetFalse();
            //Thread.Sleep(10000);
            //resetEvent.SetTrue();

            //-----------------------------------------------------------
            //AutoResetEvent与ManualResetEvent的区别在于AutoResetEvent会在对信号设置为一次True后自动地重置为false，而Manual不会
            //AutoResetEventTest autoResetEventTest = new AutoResetEventTest();

            //Task.Run(() =>
            //{
            //    autoResetEventTest.MyFunc();
            //});

            //Thread.Sleep(5000);
            //autoResetEventTest.SetTrue();
            //Thread.Sleep(2000);
            //autoResetEventTest.SetTrue();

            //SemaphoreTest semaphoreTest = new SemaphoreTest();
            //semaphoreTest.Run();
            //Thread.Sleep(5000);
            //semaphoreTest.Set(2);

            ThreadCancelTest cancelTest = new ThreadCancelTest();
            cancelTest.ExcuetJob();

            Thread.Sleep(5000);
            cancelTest.cancelJob();

            Console.ReadKey();
        }
    }
}
