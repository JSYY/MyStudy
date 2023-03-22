using Google.Protobuf;
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

            GrpcData data = new GrpcData() { IntData = 1, StringData = "2" };

            var res = grpcCommunication.SendMessage(new gRpcDemo.Message() { Sender = "ProcessB", Receiver = "ProcessA", ID = 100, BytesData = data.ToByteString() });
            var s = GrpcData.Parser.ParseFrom(res.BytesData.ToByteArray());
            Console.WriteLine(s.ToString());
            Console.ReadKey();
        }
    }
}
