using Case3.BTWConfigurationReader;
using Case3.FEBestellingen.Agent.Agents;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using case3pcsbestellen.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Case3.FEBestellingen.Site.Managers
{
    /// <summary>
    /// Responsible for connecting to the PcSBestellen with the Agent and Converting it's values
    /// </summary>
    public class BestellingManager : IBestellingManager
    {
        private IPcSBestellenAgent _pcsBestellenAgent;
        private BTWCalculator _btwCalculator = new BTWCalculator();

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
            BestellingPcS bestelling = _pcsBestellenAgent.FindNextBestelling(requestMessage);
            //Convert the Bestelling to a BestellingViewModel
            BestellingViewModel bestellingViewModel = ConvertBestellingToBestellingViewModel(bestelling);

            return bestellingViewModel;
        }

        /// <summary>
        /// This function converts a Bestelling to a BestellingViewModel
        /// </summary>
        /// <param name="bestelling">The Bestelling which has to be converted</param>
        /// <returns>Returns a BestellingViewModel<returns>
        public BestellingViewModel ConvertBestellingToBestellingViewModel(BestellingPcS bestelling)
        {
            BestellingViewModel bestellingModel = null;

            //Create Artikelen based on the Bestelling
            if (bestelling != null)
            {
                List<ArtikelViewModel> artikelen = GetArtikelListFromBestelling(bestelling);

                bestellingModel = new BestellingViewModel
                {
                    Artikelen = artikelen,
                    Adresregel1 = bestelling.Klantgegevens.Adresregel1,
                    Adresregel2 = bestelling.Klantgegevens.Adresregel2,
                    //FactuurDatum = bestelling.FactuurDatum,
                    FactuurDatum = DateTime.Now,
                    FactuurNummer = 10000 + bestelling.BestellingID,
                    KlantNaam = bestelling.Klantgegevens.Naam,
                    Postcode = bestelling.Klantgegevens.Postcode,
                    Woonplaats = bestelling.Klantgegevens.Woonplaats,
                };

                //Calculate total prices and BTW
                CalculateTotalPricesBestellingViewModel(ref bestellingModel);
            }
            return bestellingModel;
        }
        /// <summary>
        /// This function creates a list with ArtikelViewModels of the given BestellingPcS
        /// </summary>
        /// <param name="bestelling">The BestellingPcS of which the Artikelen has to be made</param>
        /// <returns>Returns a List of ArtikelViewModels of the given BestellingPcS</returns>
        private List<ArtikelViewModel> GetArtikelListFromBestelling(BestellingPcS bestelling)
        {
            return bestelling.ArtikelenPcS.Select(art => new ArtikelViewModel
            {
                ArtikelNaam = art.Product.Naam,
                Prijs = art.Product.Prijs,
                Leveranciersnaam = art.Product.LeverancierNaam,
                Leverancierscode = art.Product.LeveranciersProductId,
                Aantal = art.Aantal,
            }).ToList();
        }

        /// <summary>
        /// Computes the btw and total price for the bestellingviewmodel
        /// </summary>
        /// <param name="bestellingViewModel">The bestellingviewmodel which needs to be processed</param>
        private void CalculateTotalPricesBestellingViewModel(ref BestellingViewModel bestellingViewModel)
        {
            if(bestellingViewModel != null)
            {
                // Calculates price incl btw
                decimal totaalInclBTW = (decimal)bestellingViewModel.Artikelen.Select(artikel => (artikel.Prijs * artikel.Aantal)).Sum();

                // Calculates price excl btw
                decimal totaalExclBTW = _btwCalculator.CalculatePriceExclBTW(totaalInclBTW);

                // Sets the values in the bestellingViewModel
                bestellingViewModel.BTWPercentage = _btwCalculator.BTWPercentage;
                bestellingViewModel.TotaalInclBTW = totaalInclBTW;
                bestellingViewModel.TotaalExclBTW = totaalExclBTW;

                // Calculate the BTW for the price
                bestellingViewModel.TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalExclBTW);
            }
        }
    }
}