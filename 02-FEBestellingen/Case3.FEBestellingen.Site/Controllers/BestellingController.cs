using Case3.BTWConfigurationReader;
using Case3.FEBestellingen.Site.Managers;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;

namespace Case3.FEBestellingen.Site.Controllers
{
    /// <summary>
    /// This class is responsible for all interactions with Bestellingen
    /// </summary>
    public class BestellingController : Controller
    {
        private IBestellingManager _bestellingManager;
        private BTWCalculator _btwCalculator = new BTWCalculator();


        /// <summary>
        /// This is the default constructor
        /// </summary>
        public BestellingController()
        {
            _bestellingManager = new BestellingManager();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSWinkelenAgent</param>
        public BestellingController(IBestellingManager manager)
        {
            _bestellingManager = manager;
        }
        /// <summary>
        /// This function returns an overview page of a Bestelling
        /// </summary>
        /// <returns>View with products of the Bestelling</returns>
        [Authorize(Roles = "Magazijnmedewerkers")]
        public ActionResult Index()
        {
            var model = _bestellingManager.FindNextBestelling(new FindNextBestellingRequestMessage());

            decimal totaalInclBTW = (decimal) model.Artikelen.Select(artikel => (artikel.Prijs * artikel.Aantal)).Sum();
            decimal totaalExclBTW = _btwCalculator.CalculatePriceExclBTW(totaalInclBTW);

            model.BTWPercentage = _btwCalculator.BTWPercentage;
            model.TotaalInclBTW = totaalInclBTW;
            model.TotaalExclBTW = totaalExclBTW;
            model.TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalExclBTW);
           
            return View(model);
        }

        //dummy data, delete this when real data is available
        /*var model = new BestellingViewModel
        {
            Artikelen = new List<ArtikelViewModel>
            {
                new ArtikelViewModel
                {
                    Naam = "Fietsbel",
                    Leveranciersnaam = "Gazelle",
                    Leverancierscode = "GA12345FB",
                    Aantal = 1,                        
                },
                new ArtikelViewModel
                {
                    Naam = "Zadelpen",
                    Leveranciersnaam = "Giant",
                    Leverancierscode = "GI12345ZP",
                    Aantal = 2,
                }
            }
        };*/

    }
}