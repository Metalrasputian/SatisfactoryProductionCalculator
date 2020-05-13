using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactoryProductionCalculator
{    
    struct StarvedInput
    {
        public double desiredInputRate;
        public double currentInputRate;
        public string inputName;

        public StarvedInput(double dir, double cir, string iName)
        {
            desiredInputRate = dir;
            currentInputRate = cir;
            inputName = iName;
        }
    }
    
    class ProductionNode
    {
        List<ProductionNode> inputs;
        Product output;
        int structureCount;
        double productionMultiplier;
        int id;

        public ProductionNode(Product outP, List<ProductionNode> inP)
        {
            output = outP;
            inputs = inP;
            structureCount = 1;
            productionMultiplier = 1;
        }

        public double GetTotalProduction()
        {
            return output.GetTotalProduction(structureCount) * productionMultiplier;
        }

        public List<StarvedInput> StarvedInputs()
        {
            List<StarvedInput> results = new List<StarvedInput>();

            foreach (string prodId in output.ComponentIds)
            {
                Product prod = ProductDictionaryController.GetProduct(prodId);
                double consumption = prod.GetTotalProduction(structureCount);

                double input = inputs.First(x => x.output.ProductId == prod.ProductId).GetTotalProduction();

                if (consumption > input)
                    results.Add(new StarvedInput(consumption, input, prod.ProductName));
            }

            return results;
        }
    }
}
