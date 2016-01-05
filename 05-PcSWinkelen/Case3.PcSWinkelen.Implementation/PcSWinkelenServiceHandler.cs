using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Contract;

namespace Case3.PcSWinkelen.Implementation
{
    public class PcSWinkelenServiceHandler : IPcSWinkelenService
    {
        public string SayHelloTest(string name)
        {
            return "Hello" + name + "! This is a test method.";
        }
    }
}
