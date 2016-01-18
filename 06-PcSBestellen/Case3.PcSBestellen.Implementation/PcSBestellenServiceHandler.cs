using Case3.PcSBestellen.Contract;
using Case3.PcSBestellen.Implementation.Managers;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using log4net;

namespace Case3.PcSBestellen.Implementation
{
    /// <summary>
    /// Responsible for connecting to the BSBestellingen using the Agent and Converting it's values using the manager
    /// </summary>
    public class PcSBestellenServiceHandler : IPcSBestellenService
    {
        private static ILog _logger = LogManager.GetLogger(typeof(PcSBestellenServiceHandler));
        private IBSBestellingenManager _bestellingenManager;
        
        /// <summary>
        /// This is the default constructor
        /// </summary>
        public PcSBestellenServiceHandler()
        {
            log4net.Config.XmlConfigurator.Configure();
            _bestellingenManager = new BSBestellingenManager();
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of IBSBestellingenManager</param>
        public PcSBestellenServiceHandler(IBSBestellingenManager manager)
        {
            _bestellingenManager = manager;
        }

        
        /// <summary>
        /// This function returns a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindNextBestellingResultMessage</returns>
        public FindNextBestellingResultMessage FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            FindNextBestellingResultMessage resultMessage = _bestellingenManager.FindNextBestelling(requestMessage);
            return resultMessage;
        }

    }
}
