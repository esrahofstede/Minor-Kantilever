using System;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Minor.ServiceBus.Agent.Implementation;
using case3pcsbestellen.v1.schema;
using Case3.BSCatalogusBeheer.Schema.ProductNSPcS;

namespace Case3.FEBestellingen.Agent.Agents
{
    /// <summary>
    /// Responsible for connecting to the PcSBestellen
    /// </summary>
    public class PcSBestellenAgent : IPcSBestellenAgent
    {
        private ServiceFactory<IPcSBestellenService> _factory;
        private IPcSBestellenService _agent;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public PcSBestellenAgent()
        {
            _factory = new ServiceFactory<IPcSBestellenService>("PcSBestellen");
            _agent = _factory.CreateAgent();
        }

        /// <summary>
        /// This is the controller for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSBestellenService</param>
        public PcSBestellenAgent(IPcSBestellenService agent)
        {
            _agent = agent;
        }
        /// <summary>
        /// This function Calls the PcsBestellen for the next Bestelling
        /// </summary>
        /// <param name="requestMessage">The requestmessage containing the parameters for the request</param>
        /// <returns>Returns A BestellingPcS Containing all the needed information</returns>
        public BestellingPcS FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            FindNextBestellingResultMessage result = _agent.FindNextBestelling(requestMessage);
            if (result.BestellingOpdracht.BTWPercentage == null)
            {
                throw new Exception("BTWpercentage is null in PcSBestellenAgent");
            }
            if (result.BestellingOpdracht.Klantgegevens == null)
            {
                throw new Exception("Klantgegevens is null in PcSBestellenAgent");
            }
            return result.BestellingOpdracht;
        }

        /// <summary>
        /// This function updates the status of a Bestelling
        /// </summary>
        /// <param name="bestellingID">The ID of the Bestelling which has to be changed</param>
        public void ChangeStatusOfBestelling(long bestellingID)
        {
            var requestMessage = new UpdateBestellingStatusRequestMessage
            {
                BestellingID = bestellingID,
            };

            _agent.UpdateBestelling(requestMessage);
        }
    }
}
