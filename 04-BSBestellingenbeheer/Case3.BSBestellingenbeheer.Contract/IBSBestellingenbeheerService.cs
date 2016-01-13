using Case3.BSBestellingenbeheer.V1.Messages;
using System.ServiceModel;

namespace Case3.BSBestellingenbeheer.Contract
{
    [ServiceContract]
    public interface IBSBestellingenbeheerService
    {
        [OperationContract]
        FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage);
    }
}
