using SocketServer;
using System;
using System.Text;
using System.Threading;

namespace WebSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            MySocketServer server = new MySocketServer(21111);

            Console.ReadKey();
        }
    }
}
