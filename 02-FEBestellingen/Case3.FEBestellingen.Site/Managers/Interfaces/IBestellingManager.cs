using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using case3pcsbestellen.v1.schema;

namespace Case3.FEBestellingen.Site.Managers.Interfaces
{
    /// <summary>
    /// The BestellingManager interface
    /// </summary>
    public interface IBestellingManager
    {
        /// <summary>
        /// This function gets the latest Bestelling from the PcS
        /// </summary>
        /// <param name="requestMessage">The FindNextBestellingRequestMessage</param>
        /// <returns>Returns a BestellingViewModel with the first Bestelling</returns>
        BestellingViewModel FindNextBestelling(FindNextBestellingRequestMessage requestMessage);
        /// <summary>
        /// This function converts a Bestelling to a BestellingViewModel
        /// </summary>
        /// <param name="bestelling">The Bestelling which has to be converted</param>
        /// <returns>Returns a BestellingViewModel<returns>
        BestellingViewModel ConvertBestellingToBestellingViewModel(BestellingPcS bestelling);
        /// <summary>
        /// This function changes the status of a Bestelling
        /// </summary>
        /// <param name="bestellingID">The Id of the Bestelling Which's status has to be changed</param>
        void ChangeStatusOfBestelling(long bestellingID);
    }
}
