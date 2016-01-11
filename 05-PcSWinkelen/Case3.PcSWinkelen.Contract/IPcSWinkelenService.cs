using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Case3.PcSWinkelen.Schema;
using Case3.PcSWinkelen.Messages;
using System.Text;

namespace Case3.PcSWinkelen.Contract
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "urn:minor:case3:pcswinkelen:v1")]
    public interface IPcSWinkelenService
    {
        [OperationContract]
        FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request);



        [OperationContract]
        string SayHelloTest(string name);



    }
}
