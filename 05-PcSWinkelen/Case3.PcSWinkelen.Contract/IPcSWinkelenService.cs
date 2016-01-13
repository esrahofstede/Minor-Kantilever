using Case3.PcSWinkelen.MessagesNS;
using System.ServiceModel;

namespace Case3.PcSWinkelen.Contract
{
    [ServiceContract]
    public interface IPcSWinkelenService
    {
        [OperationContract]
        FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request);

        [OperationContract]
        AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request);

        [OperationContract]
        GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request);
        
        [OperationContract]
        string SayHelloTest(string name);
        
    }
}
