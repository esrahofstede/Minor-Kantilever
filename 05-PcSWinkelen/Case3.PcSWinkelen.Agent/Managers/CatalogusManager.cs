﻿using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Exceptions;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.SchemaNS;
using System.Collections.Generic;
using System.Linq;

namespace Case3.PcSWinkelen.Agent.Managers
{
    public class CatalogusManager : ICatalogusManager
    {

        private IBSVoorraadBeheerAgent _bSVoorraadBeheerAgent;
        private IBSCatalogusBeheerAgent _bSCatalogusBeheerAgent;

        /// <summary>
        /// Creates an instance of the CatalogusManager
        /// </summary>
        public CatalogusManager()
        {
            _bSVoorraadBeheerAgent = new BSVoorraadBeheerAgent();
            _bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
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
        /// Returns a list of Products with the Voorraad of the Products included
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<CatalogusProductItem> GetVoorraadWithProductsList(int page, int pageSize)
        {
            List<Product> products = _bSCatalogusBeheerAgent.GetProducts(page, pageSize).ToList();

            List<CatalogusProductItem> resultProductVoorraad = new List<CatalogusProductItem>();

            if (products.Count > 0)
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
                }
            }

            return resultProductVoorraad.ToList();
        }

    }
}
