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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
        public string SayHelloTest(string name)
        {
            return "Hello" + name;
        }
    }
}
