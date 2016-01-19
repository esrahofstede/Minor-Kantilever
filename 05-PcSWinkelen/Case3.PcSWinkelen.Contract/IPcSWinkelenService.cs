using Case3.PcSWinkelen.MessagesNS;
using case3common.v1.faults;
using System.ServiceModel;

namespace Case3.PcSWinkelen.Contract
{
    /// <summary>
    /// Contract for the PcSWinkelenService 
    /// </summary>
    [ServiceContract(Namespace = "Case3.GoudGeel.PcSWinkelen")]
    public interface IPcSWinkelenService
    {
        /// <summary>
        /// Get list of Products with the Voorraad included
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ErrorLijst))]
        FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request);

        /// <summary>
        /// Adds product to winkelmand
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request);

        /// <summary>
        /// Retrieves the winkelmand with content
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request);

        /// <summary>
        /// Bestellen van winkelwagen
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        [OperationContract]
        WinkelmandBestellenResponseMessage WinkelmandBestellen(WinkelmandBestellenRequestMessage bestelling);

    }
}
