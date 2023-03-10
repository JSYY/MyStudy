using Grpc.Core;
using gRpcDemo;
using System;

namespace GrpcCommon.ServerImpl
{
    public class GrpcServer
    {
        private Server _server;
        private GrpcServerImpl _serverImpl;
        private string _name;
        private string _addr;

        public GrpcServer(Address address)
        {
            _serverImpl = new GrpcServerImpl();
            _name = address.Name;
            _addr = address.IP + ":" + address.Port;
            _server = new Server
            {
                Services = { GrpcService.BindService(_serverImpl) },
                Ports = { new ServerPort(address.IP, address.Port, ServerCredentials.Insecure) }
            };
            _server.Start();

        }

        public string GetAddr()
        {
            return _addr;
        }
        public string GetName()
        {
            return _name;
        }

        public void RegisterMessageHandler(int e, GrpcMessageHandler handler)
        {
            _serverImpl.RegisterMessageHandler(e, handler);
        }

        public void Close()
        {
            _server.ShutdownAsync().Wait();
        }
    }
}
