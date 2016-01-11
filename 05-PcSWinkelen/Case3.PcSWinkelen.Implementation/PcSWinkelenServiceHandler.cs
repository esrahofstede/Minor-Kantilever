using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CatalogusProd = Case3.BSCatalogusBeheer.Schema.Prod;
using VoorraadProd = Case3.BSVoorraadBeheer.Schema.Prod;
using CatalogusCategorie = Case3.BSVoorraadBeheer.Schema.Cat;
using VoorraadCategorie = Case3.BSCatalogusBeheer.Schema.Cat;
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

        [AutomapServiceBehavior]
        public FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<CatalogusCategorie.Categorie, VoorraadCategorie.Categorie>());
            Mapper.Initialize(cfg => cfg.CreateMap<VoorraadCategorie.Categorie, CatalogusCategorie.Categorie>());
            Mapper.Initialize(cfg => cfg.CreateMap<CatalogusProd.Product, VoorraadProd.Product>()
                .ForMember(dest => dest.CategorieLijst, opt => opt.Ignore())
                .ForMember(dest => dest.ExtensionData, opt => opt.Ignore()));


            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
            BSVoorraadBeheerAgent bSVoorraadBeheerAgent = new BSVoorraadBeheerAgent();
            CatalogusCollection catalogusCollection = new CatalogusCollection();

            var producten = bSCatalogusBeheerAgent.GetProducts().ToList();

            foreach (CatalogusProd.Product product in producten)
            {
                int voorraad = bSVoorraadBeheerAgent.GetProductVoorraad(product.Id,product.LeveranciersProductId);
                catalogusCollection.Add(new ProductVoorraad() { Product = Mapper.Map<VoorraadProd.Product>(product), Voorraad = voorraad });
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
