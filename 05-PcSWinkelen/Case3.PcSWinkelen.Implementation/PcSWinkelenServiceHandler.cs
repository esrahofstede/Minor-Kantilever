using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;

namespace Case3.PcSWinkelen.Implementation
{
    public class PcSWinkelenServiceHandler : IPcSWinkelenService
    {
        /// <summary>
        /// Get list of Products with the Voorraad included
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request)
        {

            CatalogusManager catalogusManager = new CatalogusManager();

            IEnumerable<CatalogusProductItem> productVoorraadList = catalogusManager.GetVoorraadWithProductsList(1, 20);
            
            CatalogusCollection catalogusCollection = new CatalogusCollection();

            foreach(CatalogusProductItem productVoorraad in productVoorraadList)
            {
                catalogusCollection.Add(new CatalogusProductItem()
                {
                    Product = productVoorraad.Product,
                    Voorraad = productVoorraad.Voorraad
                });
            }

            FindCatalogusResponseMessage findCatalogusResponseMessage = new FindCatalogusResponseMessage()
            {
                Products = catalogusCollection
            };
                        
            return findCatalogusResponseMessage;
        }

    }
}
