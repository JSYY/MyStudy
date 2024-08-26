using AbstractFactory.Product;
using AbstractFactory.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factory
{
    public class HuaweiFactory: AbstractFactory
    {
        public HuaweiFactory()
        {
            _keyValuePairs.Add(ProductType.mobilePhone, CreateMobilePhone);
            _keyValuePairs.Add(ProductType.computer, CreateComputer);
        }

        private IProductService CreateMobilePhone(string size)
        {
            return new HuaweiMobilePhoneService(size);
        }

        private IProductService CreateComputer(string size)
        {
            return new HuaweiComputerService(size);
        }
    }
}
