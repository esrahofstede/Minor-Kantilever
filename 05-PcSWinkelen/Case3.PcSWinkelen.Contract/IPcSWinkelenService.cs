using Case3.PcSWinkelen.Schema.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Case3.PcSWinkelen.MessagesNS;
using case3common.v1.faults;
using System.ServiceModel;
using System.Text;

namespace Case3.PcSWinkelen.Contract
{
    /// <summary>
    /// Contract for connecting to PcSWinkelen service
    /// </summary>
    [ServiceContract(Name = "urn:minor:case3:pcswinkelen:v1")]
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
        /// Adds product to winkelwagen
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request);

        /// <summary>
        /// Retrieves the full winkelmand list
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [OperationContract]
        GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request);

        /// <summary>
        /// Bestelt winkelmand
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        [OperationContract]
        WinkelmandBestellenResponseMessage WinkelmandBestellen(WinkelmandBestellenRequestMessage bestelling);

    }
}
