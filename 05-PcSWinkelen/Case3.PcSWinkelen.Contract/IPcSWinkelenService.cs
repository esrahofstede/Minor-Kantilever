using Case3.PcSWinkelen.MessagesNS;
using case3common.v1.faults;
using System.ServiceModel;

namespace Case3.PcSWinkelen.Contract
{
    [ServiceContract]
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
        

        
    }
}
