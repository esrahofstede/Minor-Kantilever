
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Exceptions;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Agent.Managers
{
    public class CatalogusManager : ICatalogusManager
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
        public IEnumerable<CatalogusProductItem> GetVoorraadWithProductsList(int page, int pageSize)
        {
            List<Product> products = _bSCatalogusBeheerAgent.GetProducts(page, pageSize).ToList();

            List<CatalogusProductItem> resultProductVoorraad = new List<CatalogusProductItem>();

            if (products != null && products.Count > 0)
            {

                foreach (Product product in products)
                {
                    try
                    {
                        int voorraad = _bSVoorraadBeheerAgent.GetProductVoorraad(product.Id, product.LeveranciersProductId);

                        resultProductVoorraad.Add(new CatalogusProductItem() {
                            Product = product,
                            Voorraad = voorraad
                        });


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

            return resultProductVoorraad.ToList();
        }

    }
}
