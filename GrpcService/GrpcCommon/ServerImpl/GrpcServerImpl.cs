using Google.Protobuf;
using Grpc.Core;
using gRpcDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcCommon.ServerImpl
{
    public delegate int GrpcMessageHandler(byte[] input, out byte[] output, object context=null);
    public class GrpcServerImpl: GrpcService.GrpcServiceBase
    {
        public Dictionary<int, GrpcMessageHandler> _grpcHandlerDic;

        public GrpcServerImpl()
        {
            _grpcHandlerDic = new Dictionary<int, GrpcMessageHandler>();
        }

        public override Task<Relay> SendMessage(Message e, ServerCallContext context)
        {
            Relay relay = new Relay();
            byte[] output = null;
            if (_grpcHandlerDic != null && _grpcHandlerDic.ContainsKey(e.ID))
            {
                relay.ResultID = _grpcHandlerDic[e.ID](e.BytesData.ToByteArray(), out output, e.Sender);
            }
            relay.BytesData = output != null ? ByteString.CopyFrom(output) : ByteString.Empty;
            return Task.FromResult(relay);
        }

        public void RegisterMessageHandler(int id, GrpcMessageHandler handler)
        {
            if (_grpcHandlerDic.ContainsKey(id) || handler == null)
                return;
            _grpcHandlerDic.Add(id, handler);
        }
    }
}
