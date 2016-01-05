using Case3.BSBestellingenbeheer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSBestellingenbeheer.Implementation
{
    public class BSBestellingenServiceHandler : IBSBestellingenbeheerService
    {
        public string SayHelloTest(string name)
        {
            return $"Hello {name}";
        }
    }
}
