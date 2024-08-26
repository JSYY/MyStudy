using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Product
{
    public abstract class DefaultProduct
    {
        public DefaultProduct(string size)
        {
            Size = size;
        }
        public string Size { get; set; }
    }
}
