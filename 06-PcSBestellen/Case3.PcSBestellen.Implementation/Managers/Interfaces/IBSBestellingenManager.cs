using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.PcSBestellen.V1.Messages;

namespace Case3.PcSBestellen.Implementation.Managers.Interfaces
{
    /// <summary>
    /// The BSBestellingen interface
    /// </summary>
    public interface IBSBestellingenManager
    {
        /// <summary>
        /// This function returns a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindNextBestellingResultMessage</returns>
        FindNextBestellingResultMessage FindNextBestelling(FindNextBestellingRequestMessage requestMessage);

        /// <summary>
        /// This function converts a FindNextBestellingRequestMessage to a FindFirstBestellingRequestMessage
        /// </summary>
        /// <param name="findNextRequestMessage">The requestmessage which has to be converted</param>
        /// <returns>Returns a FindFirstBestellingRequestMessage<returns>
        FindFirstBestellingRequestMessage ConvertFindNextRequestMessageToFindFirstRequestMessage(FindNextBestellingRequestMessage findNextRequestMessage);

        /// <summary>
        /// This function converts a FindFirstBestellingResultMessage to a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="findFirstResultMessage">The resultmessage which has to be converted</param>
        /// <returns>Returns a FindNextBestellingResultMessage<returns>
        FindNextBestellingResultMessage ConvertFindFirstResultMessageToFindNextResultMessage(FindFirstBestellingResultMessage findFirstResultMessage);
        
        /// <summary>
        /// This function updates the Bestelling and returns a UpdateBestellingStatusResultMessage
        /// </summary>
        /// <param name="request">The Request Message</param>
        /// <returns>Returns a UpdateBestellingStatusResultMessage</returns>
        V1.Messages.UpdateBestellingStatusResultMessage UpdateBestelling(V1.Messages.UpdateBestellingStatusRequestMessage request);
    }
}
