using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class MySocketServer
    {
        private Socket sc;
        private int _port;

        public MySocketServer(int port)
        {
            _port = port;
            Init();
            WaitForAccept();
        }

        public int GetIpPort()
        {
            return _port;
        }

        private void Init()
        {
            sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //监控 ip4 地址，套接字类型为 TCP ，协议类型为 TCP

            IPAddress iP = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new IPEndPoint(iP, _port);
            sc.Bind(iPEndPoint);
            sc.Listen(10);
        }

        private void WaitForAccept()
        {
            Task.Run(()=> {
                while (true)
                {
                    Socket clientSc = sc.Accept();
                    Console.WriteLine("clinet {0} connect!",clientSc.RemoteEndPoint.ToString());
                    clientSc.Send(Encoding.UTF8.GetBytes("already connect to Server"));
                    Task.Run(() =>
                    {
                        ReceiveMessage(clientSc);
                    }); 
                }
            });
        }

        private void ReceiveMessage(Socket socket)
        {
            byte[] buffer = new byte[1024 * 1024 * 2];
            while (true)
            {
                try
                {
                    //获取从客户端发来的数据
                    int length = socket.Receive(buffer);
                    Console.WriteLine("receive message {0} from client {1}", Encoding.UTF8.GetString(buffer, 0, length), socket.RemoteEndPoint.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("connect to {0} closed",socket.RemoteEndPoint.ToString());
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    break;
                }
            }
        }
    }
}
