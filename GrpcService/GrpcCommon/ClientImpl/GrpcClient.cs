using Grpc.Core;
using gRpcDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcCommon.ClientImpl
{
    public class GrpcClient
    {
        GrpcService.GrpcServiceClient _clientBase;
        private string _target;
        public bool _enable = false;

        public GrpcClient(Address address)
        {
            _target = address.IP + ":" + address.Port;
            CreateClient(_target);
        }

        private void CreateClient(string target)
        {
            if (target == string.Empty)
                return;
            var channel = new Channel(target, ChannelCredentials.Insecure);
            _clientBase = new GrpcService.GrpcServiceClient(channel);
            _enable = true;
        }

        public Relay SendMessage(Message message)
        {
            var result = _clientBase.SendMessage(message);
            return result;
        }
    }
}
