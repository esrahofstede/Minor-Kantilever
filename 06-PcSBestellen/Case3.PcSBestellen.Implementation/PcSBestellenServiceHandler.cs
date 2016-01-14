using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSBestellen.Contract;
using log4net;
using Case3.PcSBestellen.Agent.Agents;
using Case3.PcSBestellen.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Messages;

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
            BsBestellingenbeheerAgent bsBestellingenBeheerAgent = new BsBestellingenbeheerAgent();
            FindFirstBestellingResultMessage findNextBestellingResultMessage = bsBestellingenBeheerAgent.FindFirstBestelling(new FindFirstBestellingRequestMessage());
            return new FindNextBestellingResultMessage()
            {
                BestellingOpdracht = findNextBestellingResultMessage.BestellingOpdracht,
            };
        }

    }
}
