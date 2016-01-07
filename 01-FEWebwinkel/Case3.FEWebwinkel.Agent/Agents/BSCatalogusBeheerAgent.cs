using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Schema.Messages;
using Case3.FEWebwinkel.Schema.Product;
using Minor.ServiceBus.Agent.Implementation;
using System.Collections.Generic;
using System;

namespace Case3.FEWebwinkel.Agent
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