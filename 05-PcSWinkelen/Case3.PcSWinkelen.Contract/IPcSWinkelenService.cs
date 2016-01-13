using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Case3.PcSWinkelen.MessagesNS;

namespace Case3.PcSWinkelen.Contract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "urn:case3-pcswinkelen:v1")]
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
