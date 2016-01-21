using Case3.PcSBestellen.V1.Messages;
using case3pcsbestellen.v1.schema;

namespace Case3.FEBestellingen.Agent.Interfaces
{
    /// <summary>
    /// The PcSBestellen interface
    /// </summary>
    public interface IPcSBestellenAgent
    {
        /// <summary>
        /// This function Calls the PcsBestellen for the next Bestelling
        /// </summary>
        /// <param name="requestMessage">The requestmessage containing the parameters for the request</param>
        /// <returns>Returns A BestellingPcS Containing all the needed information</returns>
        BestellingPcS FindNextBestelling(FindNextBestellingRequestMessage requestMessage);
        /// <summary>
        /// This function updates the status of a Bestelling
        /// </summary>
        /// <param name="bestellingID">The ID of the Bestelling which has to be changed</param>
        void ChangeStatusOfBestelling(long bestellingID);
    }
}
