using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;
using Case3.PcSWinkelen.Schema.ProductNS;
using log4net;
using Case3.PcSWinkelen.Agent.Exceptions;

namespace Case3.PcSWinkelen.Implementation
{
    public class PcSWinkelenServiceHandler : IPcSWinkelenService
    {
        /// <summary>
        /// Get list of Products with the Voorraad included
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static ILog _logger = LogManager.GetLogger(typeof(PcSWinkelenServiceHandler));

        public PcSWinkelenServiceHandler()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        
        public FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request)
        {

            CatalogusCollection catalogusCollection = new CatalogusCollection();

            if (request != null)
            {
                CatalogusManager catalogusManager = new CatalogusManager();

                IEnumerable<CatalogusProductItem> productVoorraadList = catalogusManager.GetVoorraadWithProductsList(request.Page, request.PageSize);
                foreach (CatalogusProductItem productVoorraad in productVoorraadList)
                {
                    catalogusCollection.Add(new CatalogusProductItem()
                    {
                        Product = productVoorraad.Product,
                        Voorraad = productVoorraad.Voorraad
                    });
                }
                
            }

            FindCatalogusResponseMessage findCatalogusResponseMessage = new FindCatalogusResponseMessage()
            {
                Products = catalogusCollection
            };
            return findCatalogusResponseMessage;
        }

        public AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request)
        {

            return new AddItemToWinkelmandResponseMessage {Succeeded = true};
        }

        public GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request)
        {
            return new GetWinkelmandResponseMessage
            {
                WinkelmandCollection = DummyData.Winkelmand,
                SessieId = Guid.NewGuid().ToString()
            };
        }

    }
}
