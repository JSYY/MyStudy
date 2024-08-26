using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Product
{
    public class HuaweiMobilePhoneService : IProductService
    {
        private string Size;

        public HuaweiMobilePhoneService(string size)
        {
            Size = size;
        }

        public DefaultProduct CreateProduct()
        {
            return new Mate60(Size);
        }
    }
}
