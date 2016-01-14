using System;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Minor.ServiceBus.Agent.Implementation;
using Case3.BSBestellingenbeheer.V1.SchemaNSPcS;

namespace Case3.FEBestellingen.Agent.Agents
{
    public class PcSBestellenAgent : IPcSBestellenAgent
    {
        private ServiceFactory<IPcSBestellenService> _factory;
        private IPcSBestellenService _agent;

        public PcSBestellenAgent()
        {
            //_factory = new ServiceFactory<IPcSWinkelenService>("PcSWinkelen");
            //_agent = _factory.CreateAgent();
        }

        public PcSBestellenAgent(IPcSBestellenService agent)
        {
            _agent = agent;
        }
        public Bestelling FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            FindNextBestellingResultMessage result = _agent.FindNextBestelling(requestMessage);
            return result.BestellingSummary;
        }
    }
}
