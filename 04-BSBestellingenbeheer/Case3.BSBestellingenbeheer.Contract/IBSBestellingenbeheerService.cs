using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Case3.BSBestellingenbeheer.Contract
{
    [ServiceContract]
    public interface IBSBestellingenbeheerService
    {
        [OperationContract]
        string SayHelloTest(string name);
    }
}
