using System;
using Case3.PcSBestellen.MessagesNS;
using Case3.PcSBestellen.SchemaNS;
using Case3.PcSWinkelen.Agent.Interfaces;
using Minor.ServiceBus.Agent.Implementation;

namespace Case3.PcSWinkelen.Agent.Agents
{
    public class PcSBestellenAgent : IPcSBestellenAgent
    {
        private ServiceFactory<IPcSBestellenService> _factory;
        private IPcSBestellenService _agent;

        public PcSBestellenAgent()
        {
            _factory = new ServiceFactory<IPcSBestellenService>("PcSBestellen");
            try
            {
                _agent = _factory.CreateAgent();
            }
            catch (InvalidOperationException ex)
            {
                throw new TechnicalException("PcSBestellen kan niet bereikt worden.", ex.InnerException);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool BestellingPlaatsen(BestellingPcS bestelling)
        {
            var result = _agent.BestellingPlaatsen(new BestellingPlaatsenRequestMessage { BestellingPcS = bestelling});
            return true;
        }

        public bool BestellingPlaatsenAsync(BestellingPcS bestelling)
        {

            var result = _agent.BestellingPlaatsen(new BestellingPlaatsenRequestMessage { BestellingPcS = bestelling });
            return true;
        }

    }
}
