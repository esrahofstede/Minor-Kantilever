using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Contract;
using log4net;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Schema;
using Case3.PcSWinkelen.Schema.Product;

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
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
            CatalogusCollection catalogusCollection = new CatalogusCollection();
            foreach(Product product in bSCatalogusBeheerAgent.GetProducts())
            {
                catalogusCollection.Add(new ProductVoorraad() { Product =  product, Voorraad = 1 });
            }

            FindCatalogusResponseMessage findCatalogusResponseMessage = new FindCatalogusResponseMessage()
            {
                Products = catalogusCollection
            };


            return Products;
        }

        public string SayHelloTest(string name)
        {
            string greeting = "";

            try
            {
                greeting = "Hello" + name + "! This is a test method.";
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.Message);
            }
            return greeting;
        }
    }
}
