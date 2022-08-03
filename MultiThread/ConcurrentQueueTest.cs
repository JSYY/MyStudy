using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    public class Test
    {
        static ConcurrentQueue<SellTicket> cqsellTickets = new ConcurrentQueue<SellTicket>();
        static void Main(string[] args)
        {
            for (int i = 1; i < 10; i++)
            {
                SellTicket sellTicket = new SellTicket();
                sellTicket.count = i + "";
                sellTicket.name = "张" + i;
                cqsellTickets.Enqueue(sellTicket);//入队
            }
            //创建两个线程
            ThreadStart threadStart1 = new ThreadStart(StartThedad1);
            Thread thread1 = new Thread(threadStart1);
            ThreadStart threadStart2 = new ThreadStart(StartThedad2);
            Thread thread2 = new Thread(threadStart2);

            thread1.Start();//启动线程1
            thread2.Start();//启动线程2
        }
        static void StartThedad1()
        {
            while (true)
            {
                if (cqsellTickets.Count > 0)
                {
                    SellTicket sellTicket = new SellTicket();
                    cqsellTickets.TryDequeue(out sellTicket);//出队，赋值到sellTicket
                    Console.WriteLine("thread1   购票人姓名：" + sellTicket.name + "座位号：" + sellTicket.count);
                }
            }
        }

        static void StartThedad2()
        {
            while (true)
            {
                if (cqsellTickets.Count > 0)
                {
                    SellTicket sellTicket = new SellTicket();
                    cqsellTickets.TryDequeue(out sellTicket);//出队，赋值到sellTicket
                    Console.WriteLine("thread2   购票人姓名：" + sellTicket.name + "座位号：" + sellTicket.count);
                }
            }
        }
    }
    class SellTicket
    {
        public string name { get; set; }
        public string count { get; set; }
    }
}
