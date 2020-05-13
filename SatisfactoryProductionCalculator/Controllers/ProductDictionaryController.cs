using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryProductionCalculator
{
    class ProductDictionaryController
    {
        public static List<Product> productDictionary = new List<Product>();

        public static void AddProduct(Product prod)
        {
            ProductComparitor prodComp = new ProductComparitor();
            if (!productDictionary.Contains(prod, prodComp))
                productDictionary.Add(prod);
            else
                throw new Exception(String.Format("A product with id \'{0}\' already exists", prod.ProductId));
        }

        public static Product GetProduct(string productId)
        {
            return productDictionary.First(x => x.ProductId == productId);
        }

        public static void RemoveProduct(Product prod)
        {
            productDictionary.Remove(prod);
        }
    }
}
