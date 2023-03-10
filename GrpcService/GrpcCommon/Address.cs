using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcCommon
{
    public class Address
    {
        public Address(string name, string ip, int port, NodeType type = NodeType.NetBase)
        {
            this.Name = name;
            this.IP = ip;
            this.Port = port;
            this.Type = type;
        }
        public enum NodeType
        {
            NetBase = 1,
            GRPC = 2
        }
        /// <summary>
        /// The name for communication proxy
        /// </summary>
        public string Name { get; private set; }

        public string IP { get; private set; }

        public int Port { get; private set; }

        public NodeType Type { get; private set; }
    }
}
