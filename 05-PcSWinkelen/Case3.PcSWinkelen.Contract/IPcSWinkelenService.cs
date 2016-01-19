using Case3.PcSWinkelen.Schema.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Case3.PcSWinkelen.MessagesNS;
using Case3.Common.Faults;
using System.ServiceModel;
using System.Text;

namespace Case3.PcSWinkelen.Contract
{
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

        [OperationContract]
        AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request);

        [OperationContract]
        GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request);

        [OperationContract]
        WinkelmandBestellenResponseMessage WinkelmandBestellen(WinkelmandBestellenRequestMessage bestelling);

    }
}
