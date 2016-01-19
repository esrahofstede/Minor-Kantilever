using Case3.PcSWinkelen.MessagesNS;
using Case3.Common.Faults;
using System.ServiceModel;

namespace Case3.PcSWinkelen.Contract
{
    /// <summary>
    /// The interface for the PcSWinkelenService
    /// </summary>
    [ServiceContract(Namespace = "Case3.GoudGeel.PcSWinkelen")]
    public interface IPcSWinkelenService
    {
        /// <summary>
        /// Get list of Products with the Voorraad included
        /// </summary>
        /// <param name="request">The request message containing the pagination info</param>
        /// <returns>The response message containing the Catalogus collection</returns>
        [OperationContract]
        [FaultContract(typeof(ErrorLijst))]
        FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request);

        /// <summary>
        /// Adds a Product to the Winkelmand
        /// </summary>
        /// <param name="request">The request containing the product</param>
        /// <returns>The response message to see if the Product was successfully added to the Winkelmand</returns>
        [OperationContract]
        AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request);

        /// <summary>
        /// Gets all items from the winkelmand in the database
        /// </summary>
        /// <param name="request">The request containing the session id</param>
        /// <returns>The response message with all Winkelmand Items</returns>
        [OperationContract]
        GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request);

        /// <summary>
        /// Sends the winkelmand items to the PcSBestellen service
        /// </summary>
        /// <param name="bestelling">The session id of the client</param>
        /// <returns>The response message</returns>
        [OperationContract]
        WinkelmandBestellenResponseMessage WinkelmandBestellen(WinkelmandBestellenRequestMessage bestelling);

    }
}
