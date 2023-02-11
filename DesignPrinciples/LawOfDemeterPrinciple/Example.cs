using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOfDemeterPrinciple
{
    public class Customer
    {
        public Product BuyProduct(SuperMarket superMarket)
        {
            Console.WriteLine("Customer buy a product");
            return superMarket.ProvideProduct();
        }
    }

    public class SuperMarket
    {
        public Product ProvideProduct()
        {
            Console.WriteLine("SuperMarket provide a product");
            return new Product();
        }
        
        public void GetProductFromFactory(ProductFactory productFactory)
        {
            Console.WriteLine("Get a lot of Products from Factory");
            productFactory.ProvideProducts();
        }
    }

    public class ProductFactory 
    {
        public IList<Product> ProvideProducts()
        {
            Console.WriteLine("Factory Generate Products");
            return new List<Product>();
        }
    }

    public class Product
    {

    }
}
