using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.PcSBestellen.Agent.Agents;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Contract;
using Case3.PcSBestellen.Implementation.Managers;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Case3.PcSBestellen.V1.Schema;
using log4net;
using UpdateBestellingStatusRequestMessage = Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusRequestMessage;
using UpdateBestellingStatusResultMessage = Case3.PcSBestellen.V1.Messages.UpdateBestellingStatusResultMessage;

namespace Case3.PcSBestellen.Implementation
{
    /// <summary>
    /// Responsible for connecting to the BSBestellingen using the Agent and Converting it's values using the manager
    /// </summary>
    public class PcSBestellenServiceHandler : IPcSBestellenService
    {
        //private static ILog _logger = LogManager.GetLogger(typeof(PcSBestellenServiceHandler));
        private IBSBestellingenManager _bestellingenManager;
        private IBSBestellingenbeheerAgent _bestellingenbeheerAgent;
        /// <summary>
        /// This is the default constructor
        /// </summary>
        public PcSBestellenServiceHandler()
        {
            log4net.Config.XmlConfigurator.Configure();
            _bestellingenManager = new BSBestellingenManager();
            _bestellingenbeheerAgent = new BSBestellingenbeheerAgent();
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of IBSBestellingenManager</param>
        public PcSBestellenServiceHandler(IBSBestellingenManager manager, IBSBestellingenbeheerAgent bestellingenbeheerAgent)
        {
            _bestellingenManager = manager;
            _bestellingenbeheerAgent = bestellingenbeheerAgent;
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

        public BestellingPlaatsenResultMessage BestellingPlaatsen(BestellingPlaatsenRequestMessage bestellingRequestMessage)
        {
            Mapper.Initialize(asd => asd.CreateMap<KlantgegevensPcS, Klantgegevens>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter());
            var klantgegevens = Mapper.Map<Klantgegevens>(bestellingRequestMessage.BestellingPcS.Klantgegevens);

            Mapper.CreateMap<BestelItemPcS, BestelItem>()
              .ForMember(d => d.Aantal, opt => opt.MapFrom(s => s.Aantal))
              .ForMember(d => d.Product,
                         opt => opt.MapFrom(s => Mapper.Map<Product, Product>(s.Product)));
            var artikelen = Mapper.Map<Artikelen>(bestellingRequestMessage.BestellingPcS.ArtikelenPcS);


            var BSBestelling = new InsertBestellingRequestMessage
            {
                 Bestelling = new Bestelling
        {
                     Klantgegevens = klantgegevens,
                     Artikelen = artikelen,
                     Status = 0
                 },
            };

            _bestellingenbeheerAgent.InsertBestelling(BSBestelling);
            
            return new BestellingPlaatsenResultMessage();
        }

        /// <summary>
        /// This function updates a Bestelling
        /// </summary>
        /// <param name="request">The request message containing an updated Bestelling</param>
        /// <returns>Returns an UpdateBestellingStatusResultMessage</returns>
        public UpdateBestellingStatusResultMessage UpdateBestelling(UpdateBestellingStatusRequestMessage request)
        {
            UpdateBestellingStatusResultMessage resultMessage = _bestellingenManager.UpdateBestelling(request);
            return resultMessage;
        }
    }
}
