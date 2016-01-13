using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;
using Case3.PcSWinkelen.Schema.ProductNS;
using log4net;
using Case3.PcSWinkelen.Agent.Exceptions;
using System.ServiceModel;
using case3common.v1.faults;

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

                try
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
                catch
                {

                    throw new FaultException("Er is een fout opgetreden in het ophalen van de catalogus");

                    /*throw new FaultException<FunctionalErrorList>(new FunctionalErrorList()
                    {
                        new FunctionalErrorDetail()
                        {
                            Message = "Er is een fout opgetreden in het ophalen van de catalogus",
                            ErrorCode = 1001,
                        }
                    }, "Error");*/
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
