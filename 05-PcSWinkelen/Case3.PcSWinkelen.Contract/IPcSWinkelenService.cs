using Case3.PcSWinkelen.MessagesNS;
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
        FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request);
    }
}
