using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutilThreadStudy
{
    public class ThreadTest
    {
        //进程会等待所有的前台线程完成后再结束本工作；但是如果只剩下后台线程，
        //则会直接结束本工作，不会等待后台线程完成后再结束本工作。

        private Thread thread1;
        private Thread thread2;

        public ThreadTest()
        {
            thread1 = new Thread(Func1);
            thread2 = new Thread(Func2);
        }

        private static void Func1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Func" + i);
            }
        }

        private static void Func2()
        {
            for (int i = 20; i < 30; i++)
            {
                Console.WriteLine("Func" + i);
            }
        }

        public void Run()
        {
            Console.WriteLine("Start Run!!!");
            thread1.Start();
            thread1.Join();
            Console.WriteLine("Run Finish!!!");
        }
    }
}
