using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSBestellen.Contract;
using Case3.PcSBestellen.V1.Messages;
using log4net;

namespace Case3.PcSBestellen.Implementation
{
    public class PcSBestellenServiceHandler : IPcSBestellenService
    {
        private static ILog _logger = LogManager.GetLogger(typeof(PcSBestellenServiceHandler));

        public PcSBestellenServiceHandler()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public FindNextBestellingResultMessage FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            throw new NotImplementedException();
        }

        public string SayHelloTest(string name)
        {
            string greeting = "";

            try
            {
                greeting = "Hello" + name + "! This is a test method.";
            }
            catch (Exception ex) //TODO nog een duidelijkere exception opvangen
            {
                _logger.Fatal(ex.Message);
            }
            return greeting;
        }
    }
}
