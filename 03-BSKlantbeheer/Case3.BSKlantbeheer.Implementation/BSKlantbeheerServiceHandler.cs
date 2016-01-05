using Case3.BSKlantbeheer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.BSKlantbeheer.Implementation
{
    public class BSKlantbeheerServiceHandler : IBSKlantbeheerService
    {
        public string SayHelloTest(string name)
        {
            return $"Hello {name}";
        }
    }
}
