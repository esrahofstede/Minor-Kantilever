using System;
using System.Threading.Tasks;
using PcSBestellenNS = Case3.PcSBestellen.MessagesNS;
using Case3.PcSBestellen.SchemaNS;
using Case3.PcSWinkelen.Agent.Interfaces;
using log4net;
using Minor.ServiceBus.Agent.Implementation;


namespace Case3.PcSWinkelen.Agent.Agents
{
    /// <summary>
    /// Agent class for the communication with the PcSBestellen service
    /// </summary>
    public class PcSBestellenAgent : IPcSBestellenAgent
    {
        private static ILog _logger;
        private readonly IPcSBestellenService _agent;

        /// <summary>
        /// Default constructor
        /// </summary>
        public PcSBestellenAgent()
        {
            _logger = LogManager.GetLogger(typeof(PcSBestellenAgent));
            var factory = new ServiceFactory<IPcSBestellenService>("PcSBestellen");
            try
            {
                _agent = factory.CreateAgent();
            }
            catch (InvalidOperationException ex)
            {
                throw new TechnicalException("PcSBestellen kan niet bereikt worden.", ex.InnerException);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to plaats a bestelling
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>

        public PcSBestellenAgent(IPcSBestellenService agent, ILog logger)
        {
            _agent = agent;
            _logger = logger;
        }
        
        public bool BestellingPlaatsen(BestellingPcS bestelling)
        {
            if (bestelling == null)
            {
                _logger.Error("Bestelling magt niet null zijn");
                throw new TechnicalException("Bestelling mag niet null zijn");
            }
            try
            {  
                _agent.BestellingPlaatsen(new PcSBestellenNS.BestellingPlaatsenRequestMessage { BestellingPcS = bestelling});
            }
            catch (Exception ex)
            {
                _logger.Fatal("PcSBestellenAgent - BestellingPlaatsen", ex);
                throw new TechnicalException("Er is iets misgegaan met het versturen van de bestelling", ex);
            }
            return true;
        }

        public async Task<bool> BestellingPlaatsenAsync(BestellingPcS bestelling)
        {
            if (bestelling == null)
            {
                _logger.Error("Bestelling magt niet null zijn");
                throw new TechnicalException("Bestelling mag niet null zijn");
            }
            try
            {
                await Task.Factory.StartNew(() =>
                {
                    _agent.BestellingPlaatsenAsync(new PcSBestellenNS.BestellingPlaatsenRequestMessage { BestellingPcS = bestelling });
                });
            }
            catch (Exception ex)
            {
                _logger.Fatal("PcSBestellenAgent - BestellingPlaatsenAsync", ex);
                throw new TechnicalException("Er is iets misgegaan met het versturen van de bestelling async", ex.InnerException);
            }
            
            return true;
        }

    }
}
