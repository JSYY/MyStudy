using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread
{
    public class Test
    {
        static ConcurrentQueue<SellTicket> cqsellTickets = new ConcurrentQueue<SellTicket>();
        static int ticketsMax = 10;
        static int number = 1;
        static void Main(string[] args)
        {
            //创建两个线程
            ThreadStart threadStart1 = new ThreadStart(Saler);
            Thread thread1 = new Thread(threadStart1);
            ThreadStart threadStart2 = new ThreadStart(Saler);
            Thread thread2 = new Thread(threadStart2);
            ThreadStart threadStart3 = new ThreadStart(Producer);
            Thread thread3 = new Thread(threadStart3);
            ThreadStart threadStart4 = new ThreadStart(Producer);
            Thread thread4 = new Thread(threadStart4);

            thread1.Start();//启动线程1
            thread2.Start();//启动线程2
            thread3.Start();
            thread4.Start();
        }
        static void Producer()
        {
            while (true)
            {
                if (cqsellTickets.Count < ticketsMax)
                {
                    SellTicket sellTicket = new SellTicket();
                    Process process = Process.GetCurrentProcess();
                    sellTicket.count = number + "";
                    sellTicket.name = "张" + number;
                    cqsellTickets.Enqueue(sellTicket);//入队
                    Console.WriteLine("{0} produce ticket {1}",new object[] { process.Id,sellTicket.count });
                    number++;
                    if (number > 200)
                    {
                        break;
                    }
                }
            }
        }
        static void Saler()
        {
            while (true)
            {
                if (cqsellTickets.Count > 0)
                {
                    SellTicket sellTicket = new SellTicket();
                    cqsellTickets.TryDequeue(out sellTicket);//出队，赋值到sellTicket
                    Process process = Process.GetCurrentProcess();
                    Console.WriteLine("{0} -购票人姓名：{1} 座位号：{2}",new object[] { process.Id,sellTicket.name,sellTicket.count });
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
