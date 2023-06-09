using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient
{
    public class MySocketClient
    {
        private Socket sc;
        private int _port;

        public MySocketClient(int port)
        {
            _port = port;
            Init();
            Receive();
        }

        public void Receive()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (sc.Connected)
                    {
                        var buffer = new byte[1024 * 1024 * 2];
                        sc.Receive(buffer);
                        Console.WriteLine("receive message from server {0}", sc.RemoteEndPoint.ToString());
                    }
                }
            });
        }

        public void Connect(int port)
        {
            IPAddress iP = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iP, port);
            sc.Connect(iPEndPoint);
        }

        public bool SendMessage(byte[] data)
        {
            var res = sc.Send(data);
            return res==data.Length ;
        }

        private void Init()
        {
            sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //监控 ip4 地址，套接字类型为 TCP ，协议类型为 TCP

            IPAddress iP = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iP, _port);
            sc.Bind(iPEndPoint);
        }
    }
}
