using GrpcCommon.ClientImpl;
using GrpcCommon.ServerImpl;
using gRpcDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcCommon.GrpcCommunication
{
    public class GrpcCommunication
    {
        private GrpcServer _server;
        private Dictionary<string, GrpcClient> _clientDic;

        public GrpcCommunication()
        {
            _clientDic = new Dictionary<string, GrpcClient>();
        }

        public void StartServer(Address addressInfo)
        {
            _server = new GrpcServer(addressInfo);
            System.Console.WriteLine("listen on:" + addressInfo.Port);
        }

        public void AddClient(Address address)
        {
            RemoveClient(address.Name);
            _clientDic.Add(address.Name, new GrpcClient(address));
        }

        public void RemoveClient(string name)
        {
            if (_clientDic.ContainsKey(name))
                _clientDic.Remove(name);
        }

        public Relay SendMessage(Message message)
        {

            message.Sender = _server.GetName();
            if (_clientDic.ContainsKey(message.Receiver))
            {
                return _clientDic[message.Receiver].SendMessage(message);
            }
            return null;
        }

        public int RegisterMessageHandler(int cmd, GrpcMessageHandler handler)
        {
            if (handler == null)
                return 1;
            _server.RegisterMessageHandler(cmd, handler);
            return 0;
        }
    }
}
