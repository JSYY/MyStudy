using GrpcCommon;
using GrpcCommon.GrpcCommunication;
using System;

namespace ProcessB
{
    class Program
    {
        static void Main(string[] args)
        {
            GrpcCommunication grpcCommunication = new GrpcCommunication();
            grpcCommunication.StartServer(new Address("ProcessB", "localhost", 21002));
            grpcCommunication.AddClient(new Address("ProcessA", "localhost", 21001));

            grpcCommunication.SendMessage(new gRpcDemo.Message() { Sender = "ProcessB", Receiver = "ProcessA", ID = 100, BytesData = Google.Protobuf.ByteString.Empty });
            Console.ReadKey();
        }
    }
}
