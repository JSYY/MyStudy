using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Product
{
    public class HuaweiComputer:DefaultProduct
    {
        public HuaweiComputer(string size) : base(size)
        {
            Console.WriteLine("HuaweiComputer Generate!Size is {0}", new object[] { Size });
        }
    }
}
