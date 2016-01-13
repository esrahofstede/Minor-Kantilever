using Case3.BSBestellingenbeheer.V1.Messages;
using System.ServiceModel;

namespace Case3.BSBestellingenbeheer.Contract
{
    [ServiceContract(Namespace = "Case3.GoudGeel.BsBestellingenbeheer")]
    public interface IBSBestellingenbeheerService
    {
        [OperationContract]
        FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage);
    }
}
