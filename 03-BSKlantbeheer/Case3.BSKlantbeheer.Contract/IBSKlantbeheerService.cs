using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Case3.BSKlantbeheer.Contract
{
    [ServiceContract]
    public interface IBSKlantbeheerService
    {
        [OperationContract]
        string SayHelloTest(string name);
    }
}
