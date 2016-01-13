using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;
using Case3.PcSWinkelen.Schema.ProductNS;
using log4net;

namespace Case3.PcSWinkelen.Implementation
{
    public class PcSWinkelenServiceHandler : IPcSWinkelenService
    {
        private static ILog _logger = LogManager.GetLogger(typeof(PcSWinkelenServiceHandler));

        public PcSWinkelenServiceHandler()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        
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

        public string SayHelloTest(string name)
        {
            string greeting = "";

            try
            {
                greeting = "Hello" + name + "! This is a test method.";
            }
            catch (AggregateException ex)
            {
                _logger.Fatal(ex.Message);
            }
            return greeting;
        }

    }
}
