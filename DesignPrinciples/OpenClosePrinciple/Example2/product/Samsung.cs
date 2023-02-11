using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple.Example2
{
    public class Samsung: IMobilephone
    {
        public Samsung()
        {
            Console.WriteLine("Samsung mobile phone Generate");
        }
    }
}
