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
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        [OperationContract]
        FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage);

        /// <summary>
        /// Method to insert a bestelling to the database
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        [OperationContract]
        InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage bestelling);

        /// <summary>
        /// Method to update a bestelling in the database
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        [OperationContract]
        UpdateBestellingResultMessage UpdateBestelling(UpdateBestellingRequestMessage bestelling);
    }
}
