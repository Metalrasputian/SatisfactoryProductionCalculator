using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryProductionCalculator
{
    class Product
    {
        private string productId;
        private string productName;
        private double productionRate;
        private List<string> componentIds;

        public string ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        {
            get { return productName;  }
            set { productName = value; }                
        }

        public double ProductionRate
        {
            get { return productionRate;  }
            set { productionRate = value; }
        }

        public List<string> ComponentIds
        {
            get { return componentIds; }
        }

        public Product(string id, string name, double rate, List<string> comps)
        {
            componentIds = new List<string>();
            productId = id;
            productName = name;
            productionRate = rate;

            if (comps != null)
            {
                foreach (string prod in comps)
                    this.AddComponent(prod);
            }
        }

        public void AddComponent(string prodId)
        {
            componentIds.Add(ProductDictionaryController.GetProduct(prodId).ProductId);
        }

        public double GetTotalProduction(int sourceCount)
        {
            return productionRate * sourceCount;
        }
    }
}
