using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.PcSBestellen.Agent.Interfaces;
using Minor.ServiceBus.Agent.Implementation;

namespace Case3.PcSBestellen.Agent.Agents
{
    /// <summary>
    /// Responsible for connecting to the BSBestellingen 
    /// </summary>
    public class BsBestellingenbeheerAgent : IBsBestellingenbeheerAgent
    {
        private ServiceFactory<IBSBestellingenbeheerService> _factory;
        private IBSBestellingenbeheerService _agent;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public BsBestellingenbeheerAgent()
        {
            _factory = new ServiceFactory<IBSBestellingenbeheerService>("BSBestellingen");
            _agent = _factory.CreateAgent();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IBSBestellingenbeheerService</param>
        public BsBestellingenbeheerAgent(IBSBestellingenbeheerService agent)
        {
            _agent = agent;
        }

        /// <summary>
        /// This function returns a FindFirstBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindFirstBestellingResultMessage</returns>
        public FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage)
        {
            FindFirstBestellingResultMessage result = _agent.FindFirstBestelling(requestMessage);
             
            return result;
        }
    }
}
