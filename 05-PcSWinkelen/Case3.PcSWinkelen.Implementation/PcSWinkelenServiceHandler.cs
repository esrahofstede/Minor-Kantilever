using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogusProd = Case3.BSCatalogusBeheer.Schema.Prod;
using VoorraadProd = Case3.BSVoorraadBeheer.Schema.Prod;
using Case3.PcSWinkelen.Contract;
using log4net;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Messages;
using Case3.PcSWinkelen.Schema;

namespace Case3.PcSWinkelen.Implementation
{
    public class PcSWinkelenServiceHandler : IPcSWinkelenService
    {
        private static ILog _logger = LogManager.GetLogger(typeof(PcSWinkelenServiceHandler));

        public PcSWinkelenServiceHandler()
        {
            log4net.Config.XmlConfigurator.Configure();
            Mapper.Initialize(cfg => cfg.CreateMap<CatalogusProd.Product, VoorraadProd.Product>());
            Mapper.Initialize(cfg => cfg.CreateMap<VoorraadProd.Product, CatalogusProd.Product>());
        }

        public FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request)
        {
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
            CatalogusCollection catalogusCollection = new CatalogusCollection();
            foreach(CatalogusProd.Product product in bSCatalogusBeheerAgent.GetProducts().ToList())
            {
                catalogusCollection.Add(new ProductVoorraad() { Product = Mapper.Map<VoorraadProd.Product>(product), Voorraad = 1 });
            }

            FindCatalogusResponseMessage findCatalogusResponseMessage = new FindCatalogusResponseMessage()
            {
                Products = catalogusCollection
            };


            return findCatalogusResponseMessage;
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
