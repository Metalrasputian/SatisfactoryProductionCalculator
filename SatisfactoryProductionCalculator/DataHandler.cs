using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryProductionCalculator
{
    struct RawProduct
    {
        public string ProductId;
        public string ProductName;
        public double ProductionRate;
        public List<string> ComponentIds;
    }
    static class DataHandler
    {
        static public List<Product> GetProductDictionaryJSON(string path)
        {
            List<Product> products = new List<Product>();

            using (StreamReader sr = new StreamReader(path))
            {
                string jsonPacket = sr.ReadToEnd();

                products = JsonConvert.DeserializeObject<List<Product>>(jsonPacket);
            }

            return products;
        }
    }
}
