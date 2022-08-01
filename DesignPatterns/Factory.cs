using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    #region Factory
    public interface IFactory 
    {
        public IProduct CreateProduct();
    }
    public class CarFactory : IFactory
    {
        private IProduct _product;
        public CarFactory()
        {
            _product = new Car();
        }
        public IProduct CreateProduct()
        {
            _product.makeProduct();
            return _product;
        }
    }
    public class PhoneFactory : IFactory
    {
        private IProduct _product;
        public PhoneFactory()
        {
            _product = new Phone();
        }
        public IProduct CreateProduct()
        {
            _product.makeProduct();
            return _product;
        }
    }

    #endregion

    #region Product
    public interface IProduct
    {
        public abstract void makeProduct();
    }
    public class Car : IProduct
    {
        public void makeProduct()
        {
            Console.WriteLine("Car build");
        }
    }
    public class Phone : IProduct
    {
        public void makeProduct()
        {
            Console.WriteLine("Phone build");
        }
    }

    #endregion
}
