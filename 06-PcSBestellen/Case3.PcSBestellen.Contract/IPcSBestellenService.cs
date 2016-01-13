using Case3.PcSBestellen.V1.Messages;
using System.ServiceModel;

namespace Case3.PcSBestellen.Contract
{
    [ServiceContract(Namespace = "Case3.GoudGeel.PcSBestellen")]
    public interface IPcSBestellenService
    {
        [OperationContract]
        FindNextBestellingResultMessage FindNextBestelling(FindNextBestellingRequestMessage requestMessage);
    }
   
}
