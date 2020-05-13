using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryProductionCalculator
{
    class ProductComparitor : IEqualityComparer<Product>
    {
        public bool Equals(Product prodOne, Product prodTwo)
        {
            return prodOne.ProductId == prodTwo.ProductId;
        }

        public int GetHashCode(Product prod)
        {
            return prod.ProductId.GetHashCode();
        }
    }
}
