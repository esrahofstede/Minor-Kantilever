using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.PcSBestellen.Agent.Agents;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;

namespace Case3.PcSBestellen.Implementation.Managers
{
    /// <summary>
    /// Responsible for connecting to the BSBestellingen using the Agent and Converting it's values
    /// </summary>
    public class BSBestellingenManager : IBSBestellingenManager
    {
        private IBsBestellingenbeheerAgent _bsBestellingenAgent;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public BSBestellingenManager()
        {
            _bsBestellingenAgent = new BsBestellingenbeheerAgent();
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IBsBestellingenbeheerAgent</param>
        public BSBestellingenManager(IBsBestellingenbeheerAgent agent)
        {
            _bsBestellingenAgent = agent;
        }


        /// <summary>
        /// This function converts a FindNextBestellingRequestMessage to a FindFirstBestellingRequestMessage
        /// </summary>
        /// <param name="findNextRequestMessage">The requestmessage which has to be converted</param>
        /// <returns>Returns a FindFirstBestellingRequestMessage<returns>
        public FindNextBestellingResultMessage ConvertFindFirstResultMessageToFindNextResultMessage(FindFirstBestellingResultMessage findFirstResultMessage)
        {
            return new FindNextBestellingResultMessage
            {
                BestellingOpdracht = findFirstResultMessage.BestellingOpdracht,
            };
        }

        /// <summary>
        /// This function converts a FindFirstBestellingResultMessage to a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="findFirstResultMessage">The resultmessage which has to be converted</param>
        /// <returns>Returns a FindNextBestellingResultMessage<returns>
        public FindFirstBestellingRequestMessage ConvertFindNextRequestMessageToFindFirstRequestMessage(FindNextBestellingRequestMessage findNextRequestMessage)
        {
            return new FindFirstBestellingRequestMessage()
            {
                //There is nothing to convert at this time, but this method has already been made for possible additions
            };
        }

        /// <summary>
        /// This function returns a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindNextBestellingResultMessage</returns>
        public FindNextBestellingResultMessage FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            //Convert the incoming requestMessage to the required requestMessage for the BsBestellingenbeheer
            var findFirstRequestMessage = ConvertFindNextRequestMessageToFindFirstRequestMessage(requestMessage);
            //Get the first bestelling from the BsBestellingenbeheer using the agent
            var findFirstResultMessage = _bsBestellingenAgent.FindFirstBestelling(findFirstRequestMessage);
            //Convert the incoming resultMessage to the correct outgoing resultMessage for FEBestellen
            var findNextResultMessage = ConvertFindFirstResultMessageToFindNextResultMessage(findFirstResultMessage);

            return findNextResultMessage;
        }
    }
}
