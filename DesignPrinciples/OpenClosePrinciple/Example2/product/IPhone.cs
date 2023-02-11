using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple.Example2
{
    public class IPhone: IMobilephone
    {
        public IPhone()
        {
            Console.WriteLine("IPhone mobile phone Generate");
        }
    }
}
