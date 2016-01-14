using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.PcSBestellen.Agent.Interfaces;
using Minor.ServiceBus.Agent.Implementation;
using System;

namespace Case3.PcSBestellen.Agent.Agents
{
    public class BsBestellingenbeheerAgent : IBsBestellingenbeheerAgent
    {
        private ServiceFactory<IBSBestellingenbeheerService> _factory;
        private IBSBestellingenbeheerService _agent;

        public BsBestellingenbeheerAgent()
        {
            _factory = new ServiceFactory<IBSBestellingenbeheerService>("BSBestellen");
            _agent = _factory.CreateAgent();
        }

        public BsBestellingenbeheerAgent(IBSBestellingenbeheerService agent)
        {
            _agent = agent;
        }

        public FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage)
        {
            FindFirstBestellingResultMessage result = _agent.FindFirstBestelling(requestMessage);
             
            return result;
        }
    }
}
