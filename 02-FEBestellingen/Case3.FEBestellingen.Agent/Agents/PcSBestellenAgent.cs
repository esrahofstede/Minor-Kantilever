using System;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Minor.ServiceBus.Agent.Implementation;
using case3pcsbestellen.v1.schema;

namespace Case3.FEBestellingen.Agent.Agents
{
    public class PcSBestellenAgent : IPcSBestellenAgent
    {
        private ServiceFactory<IPcSBestellenService> _factory;
        private IPcSBestellenService _agent;

        public PcSBestellenAgent()
        {
            _factory = new ServiceFactory<IPcSBestellenService>("PcSBestellingen");
            _agent = _factory.CreateAgent();
        }

        public PcSBestellenAgent(IPcSBestellenService agent)
        {
            _agent = agent;
        }
        public BestellingPcS FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            FindNextBestellingResultMessage result = _agent.FindNextBestelling(requestMessage);
            return result.BestellingOpdracht;
        }
    }
}
