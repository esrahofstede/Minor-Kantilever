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

        /// <summary>
        /// This function sends a bestelling to the BSBestellingBeheer service
        /// </summary>
        /// <param name="bestelling">The bestelling containing the products and the Klant data</param>
        /// <returns>Returns a BestellingPlaatsenResultMessage</returns>
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
