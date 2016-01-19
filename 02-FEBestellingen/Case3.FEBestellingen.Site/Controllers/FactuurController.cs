using Case3.BTWConfigurationReader;
using Case3.FEBestellingen.Site.Managers;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using case3pcsbestellen.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case3.FEBestellingen.Site.Controllers
{
    /// <summary>
    /// This class is responsible for all interactions with Facturen
    /// </summary>
    public class FactuurController : Controller
    {

        private IBestellingManager _bestellingManager;

        /// <summary>
        /// This is the default controller
        /// </summary>
        public FactuurController()
        {
            _bestellingManager = new BestellingManager();
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSWinkelenAgent</param>
        public FactuurController(IBestellingManager bestellingManager)
        {
            _bestellingManager = bestellingManager;
        }

        /// <summary>
        /// This function returns an overview page of a factuur
        /// </summary>
        /// <returns>View with factuur of the bestelling</returns>
        [Authorize(Roles = "Magazijnmedewerkers")]
        [HttpPost]
        public ActionResult Index(BestellingViewModel bestellingViewModel)
        {
            return View(bestellingViewModel);
        }

        /// <summary>
        /// This function returns an overview page of the afleveradres
        /// </summary>
        /// <returns>View with factuur of the afleveradres</returns>
        [Authorize(Roles = "Magazijnmedewerkers")]
        public ActionResult AfleverAdres()
        {
            //var model = _bestellingManager.FindNextBestelling(new FindNextBestellingRequestMessage());

            /*KlantgegevensViewModel klantgegevensViewModel = new KlantgegevensViewModel()
            {
                KlantNaam = model.
            }*/


            BestellingViewModel bestellingViewModel = new BestellingViewModel()
            {
                KlantNaam = "Dennis Meijer",
                Adresregel1 = "Kalmoes 4",
                Adresregel2 = "Zolderverdieping",
                Postcode = "7443KB",
                Woonplaats = "Nijverdal"
            };

            return View(bestellingViewModel);
        }



    }
}