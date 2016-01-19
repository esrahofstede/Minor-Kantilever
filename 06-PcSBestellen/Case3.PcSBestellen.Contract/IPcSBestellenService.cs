using Case3.PcSBestellen.V1.Messages;
using System.ServiceModel;

namespace Case3.PcSBestellen.Contract
{
    /// <summary>
    /// The PcSBestellenService Interface
    /// </summary>
    [ServiceContract(Namespace = "Case3.GoudGeel.PcSBestellen")]
    public interface IPcSBestellenService
    {
        /// <summary>
        /// This function returns a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindNextBestellingResultMessage</returns>
        [OperationContract]
        FindNextBestellingResultMessage FindNextBestelling(FindNextBestellingRequestMessage requestMessage);

        [OperationContract]
        BestellingPlaatsenResultMessage BestellingPlaatsen(BestellingPlaatsenRequestMessage bestelling);

        /// <summary>
        /// This function updates a Bestelling
        /// </summary>
        /// <param name="request">The request message containing an updated Bestelling</param>
        /// <returns>Returns an UpdateBestellingStatusResultMessage</returns>
        [OperationContract]
        UpdateBestellingStatusResultMessage UpdateBestelling(UpdateBestellingStatusRequestMessage request);
    }
   
}
