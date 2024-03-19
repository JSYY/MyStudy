using System;
using System.Threading;
using System.Threading.Tasks;

namespace CommandHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            ActionSyncController actionSync = new ActionSyncController();
            actionSync.AddAction(() =>
            {
                doWork(2);
            }, "action1");
            actionSync.AddAction(() =>
            {
                doWork(2);
                doWork(3);
            }, "action2");
            Thread.Sleep(2000);
            actionSync.AddAction(() =>
            {
                doWork(3);
            }, "action3");
            Console.ReadKey();
        }

        public static void doWork(int time)
        {
            Thread.Sleep(time * 1000);
        }
    }
}
