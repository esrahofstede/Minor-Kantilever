

using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Schema.Messages;
using Case3.PcSWinkelen.Schema.ProductNS;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Agent.Agents
{
    public class BSCatalogusBeheerAgent : IBSCatalogusBeheerAgent
    {
        private ServiceFactory<ICatalogusBeheer> _factory;
        private ICatalogusBeheer _agent;

        /// <summary>
        /// Instantiate a ServiceFactory with a reference to the described service
        /// </summary>
        public BSCatalogusBeheerAgent()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
            _agent = _factory.CreateAgent();
        }

        /// <summary>
        /// For testing purposes, possible to inject a mock class
        /// </summary>
        /// <param name="agent"></param>
        public BSCatalogusBeheerAgent(ICatalogusBeheer agent)
        {
            _agent = agent;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>IEnumerable of Product entities</returns>
        public IEnumerable<Product> GetProducts()
        {
            MsgFindProductsResult result = _agent.FindProducts(new MsgFindProductsRequest() { Page = 1, PageSize = 20 });
            return result.Products;
        }
        
        /// <summary>
        /// Get products by page and page length
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>IEnumerable of Product entities</returns>
        public IEnumerable<Product> GetProducts(int page, int pageSize)
        {
            MsgFindProductsResult result = _agent.FindProducts(new MsgFindProductsRequest() { Page = page, PageSize = pageSize });
            return result.Products;
        }

    }
}
