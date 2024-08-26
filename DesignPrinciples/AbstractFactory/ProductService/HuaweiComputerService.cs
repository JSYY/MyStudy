using AbstractFactory.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.ProductService
{
    public class HuaweiComputerService : IProductService
    {
        private string Size;

        public HuaweiComputerService(string size)
        {
            Size = size;
        }

        public DefaultProduct CreateProduct()
        {
            return new HuaweiComputer(Size);
        }
    }
}
