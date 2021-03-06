﻿using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.PcSBestellen.Agent.Exceptions;
using Case3.PcSBestellen.Agent.Interfaces;
using log4net;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Case3.PcSBestellen.Agent.Agents
{
    /// <summary>
    /// Responsible for connecting to the BSBestellingen 
    /// </summary>
    public class BSBestellingenbeheerAgent : IBSBestellingenbeheerAgent
    {
        private static ILog _logger;
        private IBSBestellingenbeheerService _agent;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public BSBestellingenbeheerAgent()
        {
            _logger = LogManager.GetLogger(typeof(BSBestellingenbeheerAgent));
            var factory = new ServiceFactory<IBSBestellingenbeheerService>("BSBestellingen");
            try
            {
                _agent = factory.CreateAgent();
        }
            catch (InvalidOperationException ex)
            {
                throw new TechnicalException("BSBestellingen kan niet bereikt worden.", ex.InnerException);
            }
            catch (Exception)
            {
                throw;
            }

        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IBSBestellingenbeheerService</param>
        public BSBestellingenbeheerAgent(IBSBestellingenbeheerService agent)
        {
            _agent = agent;
        }

        /// <summary>
        /// This function returns a FindFirstBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindFirstBestellingResultMessage</returns>
        public FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage)
        {
            FindFirstBestellingResultMessage result = _agent.FindFirstBestelling(requestMessage);
            if (result.BestellingOpdracht.BTWPercentage == null)
            {
                throw new FaultException("BTWpercentage is null in BSBestellingenAgent");
            }

            if (result.BestellingOpdracht.Klantgegevens == null)
            {
                throw new FaultException("BTWpercentage is null in BSBestellingenAgent");
            }

            if (result.BestellingOpdracht.Artikelen != null)
            {
                if (result.BestellingOpdracht.Artikelen.First().Product.Prijs == null)
                {
                    throw new FaultException("Prijs is null in BSBestellingenAgent");
                }
            }

            return result;
        }

        public BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusResultMessage UpdateBestellingStatus(BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusRequestMessage requestMessage)
        {
            _agent.UpdateBestellingStatus(requestMessage);
            return new BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusResultMessage();
        }

        public InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage bestelling)
        {
            if (bestelling == null)
            {
                _logger.Error("Bestelling magt niet null zijn");
                throw new TechnicalException("Bestelling mag niet null zijn");
            }
            try
            {
                _agent.InsertBestelling(bestelling);
            }
            catch (Exception ex)
            {
                _logger.Fatal("BSBestellingenbeheerAgent - InsertBestelling", ex);
                throw new TechnicalException("Bestelling kon niet toegevoegd worden", ex);
            }
            return new InsertBestellingResultMessage();
        }

        public InsertBestellingResultMessage InsertBestellingAsync(InsertBestellingRequestMessage bestelling)
        {
            if (bestelling == null)
            {
                _logger.Error("Bestelling magt niet null zijn");
                throw new TechnicalException("Bestelling mag niet null zijn");
            }
            try
            {
                Task.Factory.StartNew(() =>
                {
                    _agent.InsertBestellingAsync(bestelling);
                });
            }
            catch (Exception ex)
            {
                _logger.Fatal("BSBestellingenbeheerAgent - InsertBestelling", ex);
                throw new TechnicalException("Bestelling kon niet toegevoegd worden", ex);
            }
            return new InsertBestellingResultMessage();
        }
    }
}
