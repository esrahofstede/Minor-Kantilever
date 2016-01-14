using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.PcSWinkelen.Messages;
using Case3.PcSWinkelen.Schema;
using case3common.v1.faults;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.ServiceModel;

namespace Case3.FEWebwinkel.Agent
{
    public class PcSWinkelenAgent : IPcSWinkelenAgent
    {
        private ServiceFactory<IPcSWinkelenService> _factory;
        private IPcSWinkelenService _agent;

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public PcSWinkelenAgent()
        {
            _factory = new ServiceFactory<IPcSWinkelenService>("PcSWinkelen");
            try
            {
                _agent = _factory.CreateAgent();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSWinkelenService</param>
        public PcSWinkelenAgent(IPcSWinkelenService agent)
        {
            _agent = agent;
        }

        /// <summary>
        /// This function calls the PcSWinkelen to get the products based on the page and pagesize
        /// </summary>
        /// <param name="page">this is the pagenumber</param>
        /// <param name="pageSize">this is the pagesize</param>
        /// <returns></returns>
        public CatalogusCollection GetProducts(int page, int pageSize)
        {
            FindCatalogusResponseMessage result = _agent.GetCatalogusItems(new FindCatalogusRequestMessage() { Page = page, PageSize = pageSize });
            return result.Products;
        }

        /// <summary>
        /// This function returns the complete CatalogusCollection
        /// </summary>
        /// <returns>The Complete CatalogusCollection</returns>
        public CatalogusCollection GetProducts()
        {
            int pageSize = 50, page = 1;
            CatalogusCollection result = new CatalogusCollection();

            try
            {
                var products = _agent.GetCatalogusItems(new FindCatalogusRequestMessage() { Page = page, PageSize = pageSize }).Products;
                result.AddRange(products);

                while (products.Count > 1 && products.Count == pageSize)
                {
                    page++;
                    products = _agent.GetCatalogusItems(new FindCatalogusRequestMessage() { Page = page, PageSize = pageSize }).Products;
                    result.AddRange(products);
                }
            }
            catch (FaultException)
            {

            }
            return result;
        }

        public WinkelMandCollection GetWinkelmand(string sessionId)
        {
            //var winkelmandCollection = new WinkelMandCollection
            //{
            //                 new WinkelmandjeItem { Product = new Product { Id = 1,Naam = "Fietsbel",Prijs = 4.95M,AfbeeldingURL = "fietsbel.gif",LeverancierNaam = "Gazelle",},Aantal = 2,},
            //                 new WinkelmandjeItem { Product = new Product { Id = 2,Naam = "Zadelpen",Prijs = 12.50M,AfbeeldingURL = "zadelpen.gif",LeverancierNaam = "Giant",},Aantal = 1,},
            //};
            //return winkelmandCollection;
            GetWinkelmandResponseMessage result = _agent.GetWinkelmand(new GetWinkelmandRequestMessage() { SessieId = sessionId });
            return result.WinkelmandCollection;
        }
    }
}