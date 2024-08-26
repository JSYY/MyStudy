using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Product
{
    public class Mate60: DefaultProduct
    {
        public Mate60(string size):base(size)
        {
            Console.WriteLine("Mate60 Generate!Size is {0}",new object[] { Size });
        }
    }
}
