using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
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
            throw new NotImplementedException();
        }

        public AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request)
        {
            var products = new ProductCollection();
            products.Add(new Product());
            return new GetWinkelmandResponseMessage
            {
                Products = products
            };
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