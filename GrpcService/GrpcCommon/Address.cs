using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcCommon
{
    public class Address
    {
        public Address(string name, string ip, int port)
        {
            this.Name = name;
            this.IP = ip;
            this.Port = port;
        }

        /// <summary>
        /// The name for communication proxy
        /// </summary>
        public string Name { get; private set; }

        public string IP { get; private set; }

        public int Port { get; private set; }
    }
}
