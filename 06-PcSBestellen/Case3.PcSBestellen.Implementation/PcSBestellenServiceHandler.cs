﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSBestellen.Contract;

namespace Case3.PcSBestellen.Implementation
{
    public class PcSBestellenServiceHandler : IPcSBestellenService
    {
        public string SayHelloTest(string name)
        {
            return "Hello" + name + "! This is a test method.";
        }
    }
}
