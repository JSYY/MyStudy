using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class SocketServer
    {
        public SocketServer()
        {
            Socket sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //监控 ip4 地址，套接字类型为 TCP ，协议类型为 TCP

            IPAddress iP = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iP, 19112);
            sc.Bind(iPEndPoint);
            sc.Listen(10);
            sc.Accept();
        }
    }
}
