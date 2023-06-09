using SocketClient;
using System;
using System.Text;
using System.Threading;

namespace WebSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            MySocketClient client = new MySocketClient(21112);
            client.Connect(21111);

            Thread.Sleep(5000);
            client.SendMessage(Encoding.UTF8.GetBytes("Hello"));

            Console.ReadKey();
        }
    }
}
