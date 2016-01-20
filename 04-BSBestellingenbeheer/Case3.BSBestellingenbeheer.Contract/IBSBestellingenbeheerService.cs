using Case3.BSBestellingenbeheer.V1.Messages;
using System.ServiceModel;

namespace Case3.BSBestellingenbeheer.Contract
{
    /// <summary>
    /// Contract for the BSBestellingenbeheerService
    /// </summary>
    [ServiceContract(Namespace = "Case3.GoudGeel.BsBestellingenbeheer")]
    public interface IBSBestellingenbeheerService
    {
        /// <summary>
        /// Method to find the first bestelling in the database
        /// </summary>
        /// <param name="requestMessage">The request message</param>
        /// <returns>The result message containing a Bestelling</returns>
        [OperationContract]
        FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage);

        /// <summary>
        /// Method to insert a bestelling to the database
        /// </summary>
        /// <param name="bestelling">The request message containing the Bestelling to insert</param>
        /// <returns>Returns an InsertBestellingResultMessage</returns>
        [OperationContract]
        InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage bestelling);

        /// <summary>
        /// Method to update a bestelling in the database
        /// </summary>
        /// <param name="bestelling">Request message containing an updated Bestelling</param>
        /// <returns>Returns an UpdateBestellinResultMessage</returns>
        [OperationContract]
        UpdateBestellingStatusResultMessage UpdateBestellingStatus(UpdateBestellingStatusRequestMessage bestellingID);
    }
}
