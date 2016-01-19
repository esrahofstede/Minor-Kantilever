using System.ServiceModel;

namespace Case3.BSKlantbeheer.Contract
{
    [ServiceContract(Namespace = "Case3.GoudGeel.BsKlantbeheer")]
    public interface IBSKlantbeheerService
    {
        [OperationContract]
        string SayHelloTest(string name);
    }
}
