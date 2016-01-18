using Case3.BSBestellingenbeheer.V1.SchemaNSPcS;
using Case3.FEBestellingen.Agent.Agents;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using System.Linq;

namespace Case3.FEBestellingen.Site.Managers
{
    /// <summary>
    /// Responsible for connecting to the PcSBestellen with the Agent and Converting it's values
    /// </summary>
    public class BestellingManager : IBestellingManager
    {
        private IPcSBestellenAgent _pcsBestellenAgent;

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public BestellingManager()
        {
            _pcsBestellenAgent = new PcSBestellenAgent();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSBestellenAgent</param>
        public BestellingManager(IPcSBestellenAgent agent)
        {
            _pcsBestellenAgent = agent;
        }

        /// <summary>
        /// This function gets the latest Bestelling from the PcS
        /// </summary>
        /// <returns>Returns a BestellingViewModel with the first Bestelling</returns>
        public BestellingViewModel FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            //Get Bestelling from PcSBestellen
            Bestelling bestelling = _pcsBestellenAgent.FindNextBestelling(requestMessage);
            //Convert the Bestelling to a BestellingViewModel
            BestellingViewModel bestellingViewModel = ConvertBestellingToBestellingViewModel(bestelling);

            return bestellingViewModel;
        }

        /// <summary>
        /// This function converts a Bestelling to a BestellingViewModel
        /// </summary>
        /// <param name="bestelling">The Bestelling which has to be converted</param>
        /// <returns>Returns a BestellingViewModel<returns>
        public BestellingViewModel ConvertBestellingToBestellingViewModel(Bestelling bestelling)
        {
            //Create Artikelen based on the Bestelling
            var artikelen = bestelling.Artikelen.Select(art => new ArtikelViewModel
            {
                Naam = art.Product.Naam,
                Leveranciersnaam = art.Product.LeverancierNaam,
                Leverancierscode = art.Product.LeveranciersProductId,
                Aantal = art.Aantal,
            }).ToList();

            //Add the Artikelen to the BestellingViewModel
            BestellingViewModel bestellingModel = new BestellingViewModel { Artikelen = artikelen};

            return bestellingModel;
        }
    }
}