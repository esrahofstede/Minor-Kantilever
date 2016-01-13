using Case3.PcSWinkelen.Agent.Exceptions;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.Schema.VoorraadMessages;
using Minor.ServiceBus.Agent.Implementation;

namespace Case3.PcSWinkelen.Agent.Agents
{
    public class BSVoorraadBeheerAgent : IBSVoorraadBeheerAgent
    {
        private ServiceFactory<IVoorraadBeheer> _factory;
        private IVoorraadBeheer _agent;

        /// <summary>
        /// Instantiate a ServiceFactory with a reference to the described service
        /// </summary>
        public BSVoorraadBeheerAgent()
        {
            _factory = new ServiceFactory<IVoorraadBeheer>("BSVoorraadBeheer");
            _agent = _factory.CreateAgent();
        }

        /// <summary>
        /// For testing purposes, possible to inject a mock class
        /// </summary>
        /// <param name="agent"></param>
        public BSVoorraadBeheerAgent(IVoorraadBeheer agent)
        {
            _agent = agent;
        }
        /// <summary>
        /// This method retrieves the actual voorraad for the input product.
        /// </summary>
        /// <param name="productId">Optional productId from a product, which identifies the product.</param>
        /// <param name="leveranciersProductId">The ProductId, specific for the leverancier from the product.</param>
        /// <returns></returns>
        public int GetProductVoorraad(int? productId, string leveranciersProductId)
        {
            ProductRef productRef = CreateProductRef(productId, leveranciersProductId);
            MsgFindVoorraadResult result = _agent.FindVoorraad(new MsgFindVoorraadRequest() { Product = productRef });
            if (result.Succes)
            {
                return result.ProductVoorraad.Voorraad;
            } else
            {
                throw new ProductVoorraadNotFoundException(result.Foutmelding.Bron, result.Foutmelding.Melding, 
                    result.Foutmelding.Nummer, result.Foutmelding.Niveau);
            }
        }
        /// <summary>
        /// Creates a ProductRef which is required within the MsgFindVoorraadRequest class
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="leveranciersProductId"></param>
        /// <returns></returns>
        private static ProductRef CreateProductRef(int? productId, string leveranciersProductId)
        {
            return new ProductRef()
            {
                Id = productId ?? -1, //Product
                LeveranciersProductId = leveranciersProductId
            };
        }
    }
}
