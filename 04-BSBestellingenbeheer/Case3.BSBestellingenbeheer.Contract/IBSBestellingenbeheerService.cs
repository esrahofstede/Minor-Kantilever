using Case3.BSBestellingenbeheer.V1.Messages;
using System.ServiceModel;

namespace Case3.BSBestellingenbeheer.Contract
{
    [ServiceContract(Namespace = "urn:minor:case3:bsbestellingenbeheer:v1")]
    public interface IBSBestellingenbeheerService
    {
        [OperationContract]
        FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage);

        [OperationContract]
        InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage bestelling);

        [OperationContract]
        UpdateBestellingResultMessage UpdateBestelling(UpdateBestellingRequestMessage bestelling);
    }
}
