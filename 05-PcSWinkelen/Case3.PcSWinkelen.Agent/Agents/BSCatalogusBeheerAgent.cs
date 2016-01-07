using Case3.FEWebwinkel.Schema.Messages;
using Case3.FEWebwinkel.Schema.Product;
using Case3.PcSWinkelen.Agent.Interfaces;
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

        public BSCatalogusBeheerAgent()
        {
            _factory = new ServiceFactory<ICatalogusBeheer>("BSCatalogusBeheer");
            _agent = _factory.CreateAgent();
        }

        public BSCatalogusBeheerAgent(ICatalogusBeheer agent)
        {
            _agent = agent;
        }

        public List<Product> GetProducts(int page, int pageSize)
        {
            MsgFindProductsResult result = _agent.FindProducts(new MsgFindProductsRequest() { Page = page, PageSize = pageSize });
            return result.Products;
        }

        public List<Product> GetProducts()
        {
            MsgFindProductsResult result = _agent.FindProducts(new MsgFindProductsRequest() { Page = 1, PageSize = 20 });
            return result.Products;
        }
    }
}
