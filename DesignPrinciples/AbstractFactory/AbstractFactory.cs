using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    public abstract class AbstractFactory
    {
        protected Dictionary<ProductType, Func<string,IProductService>> _keyValuePairs = new Dictionary<ProductType, Func<string, IProductService>>();

        public virtual IProductService CreateProductService(ProductType type,string size)
        {
            if (_keyValuePairs.ContainsKey(type))
            {
                return _keyValuePairs[type](size);
            }
            return null;
        }
    }

    public enum ProductType
    {
        mobilePhone,
        computer,
    }
}
