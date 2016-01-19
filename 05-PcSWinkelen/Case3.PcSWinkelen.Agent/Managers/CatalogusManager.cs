using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Exceptions;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.SchemaNS;
using case3common.v1.faults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Case3.PcSWinkelen.Agent.Managers
{
    /// <summary>
    /// Class which arrange the communication for the catalogus
    /// </summary>
    public class CatalogusManager : ICatalogusManager
    {
        private IBSVoorraadBeheerAgent _bSVoorraadBeheerAgent;
        private IBSCatalogusBeheerAgent _bSCatalogusBeheerAgent;

        /// <summary>
        /// Creates an instance of the CatalogusManager
        /// </summary>
        public CatalogusManager()
        {
            try {
                _bSVoorraadBeheerAgent = new BSVoorraadBeheerAgent();
                _bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
            }
            catch (TechnicalException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates an instance with an interface which could include mocks for testing purposes
        /// </summary>
        /// <param name="catalogusBeheer"></param>
        /// <param name="voorraadBeheer"></param>
        public CatalogusManager(IBSCatalogusBeheerAgent catalogusBeheer, IBSVoorraadBeheerAgent voorraadBeheer)
        {
            _bSVoorraadBeheerAgent = voorraadBeheer;
            _bSCatalogusBeheerAgent = catalogusBeheer;
        }

        /// <summary>
        /// Returns a list of Products with the Voorraad of the Products included.
        /// If a product has no voorraad, but it is still leverbaar, then set voorraad to 0. 
        /// If a product has no voorraad and it is not leverbaar anymore, don't return.
        /// </summary>
        /// <param name="page">Pagenumber for products</param>
        /// <param name="pageSize">Amount of products in the submitted page.</param>
        /// <returns>A list of products with voorraad.</returns>
        public IEnumerable<CatalogusProductItem> GetVoorraadWithProductsList(int page, int pageSize)
        {
            List<Product> products = _bSCatalogusBeheerAgent.GetProducts(page, pageSize).ToList();
            List<CatalogusProductItem> resultProductVoorraad = new List<CatalogusProductItem>();
            if (products.Count > 0)
            {
                foreach (Product product in products)
                {
                    int voorraad = 0;
                    try
                    {
                        voorraad = _bSVoorraadBeheerAgent.GetProductVoorraad(product.Id, product.LeveranciersProductId);
                        resultProductVoorraad.Add(new CatalogusProductItem() //Add product with actual voorraad to list
                        {
                            Product = product,
                            Voorraad = voorraad
                        });
                    }
                    catch (ProductVoorraadNotFoundException) //Product voorraad not found
                    {
                        if (product.LeverbaarTot > DateTime.Now) //If products is still leverbaar
                        {
                            resultProductVoorraad.Add(new CatalogusProductItem() //Add product with voorraad 0 to list
                            {
                                Product = product,
                                Voorraad = 0
                            });
                        } //If product not leverbaar, don't add to list.
                    }
                    
                }
            }
            return resultProductVoorraad.ToList();
        }

    }
}
