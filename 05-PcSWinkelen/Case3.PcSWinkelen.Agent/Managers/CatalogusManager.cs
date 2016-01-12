using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Exceptions;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Schema.Messages;
using Case3.PcSWinkelen.Schema.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Agent.Managers
{
    public class CatalogusManager
    {

        private IBSVoorraadBeheerAgent _bSVoorraadBeheerAgent;
        private IBSCatalogusBeheerAgent _bSCatalogusBeheerAgent;
        
        public CatalogusManager()
        {
            _bSVoorraadBeheerAgent = new BSVoorraadBeheerAgent();
            _bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
        }

        public CatalogusManager(IBSCatalogusBeheerAgent catalogusBeheer, IBSVoorraadBeheerAgent voorraadBeheer)
        {
            _bSVoorraadBeheerAgent = voorraadBeheer;
            _bSCatalogusBeheerAgent = catalogusBeheer;
        }

        // TODO: return xsd list of products with voorraad
        public List<Product> GetVoorraadWithProductsList(List<Product> products)
        {
            IEnumerable<Product> result = _bSCatalogusBeheerAgent.GetProducts(1, 20);

            if (products != null && products.Count > 0)
            {

                foreach (Product product in products)
                {
                    try
                    {
                        _bSVoorraadBeheerAgent.GetProductVoorraad(product.Id, product.LeveranciersProductId);
                        
                    }
                    catch (ProductVoorraadNotFoundException)
                    {
                        throw;
                    }

                    // result[index].Voorraad = voorraad;

                }

                /*
                Parallel.ForEach<Product>(result.Products, (index, product) =>
                {
                });
                */
            }

            return result.ToList();
        }

    }
}
