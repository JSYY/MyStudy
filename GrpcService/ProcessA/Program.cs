using GrpcCommon;
using GrpcCommon.GrpcCommunication;
using System;

namespace ProcessA
{
    class Program
    {
        static void Main(string[] args)
        {
            GrpcCommunication grpcCommunication = new GrpcCommunication();
            grpcCommunication.StartServer(new Address("ProcessA", "localhost", 21001));
            grpcCommunication.AddClient(new Address("ProcessB", "localhost", 21002));
            grpcCommunication.RegisterMessageHandler(100, handler);
            Console.ReadKey();
        }

        private static int handler(byte[] input, out byte[] output, object context)
        {
            output = null;
            return 0;
        }
    }
}
