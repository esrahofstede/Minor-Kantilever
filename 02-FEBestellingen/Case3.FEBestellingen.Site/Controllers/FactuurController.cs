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
    public class FactuurController : Controller
    {

        private IBestellingManager _bestellingManager;

        public FactuurController()
        {
            _bestellingManager = new BestellingManager();
        }

        // GET: Factuur
        [Authorize(Roles = "Magazijnmedewerkers")]
        public ActionResult Index()
        {
            var model = _bestellingManager.FindNextBestelling(new FindNextBestellingRequestMessage());
            return View(model);
        }

        [Authorize(Roles = "Magazijnmedewerkers")]
        public ActionResult AfleverAdres()
        {
            //var model = _bestellingManager.FindNextBestelling(new FindNextBestellingRequestMessage());

            /*KlantgegevensViewModel klantgegevensViewModel = new KlantgegevensViewModel()
            {
                KlantNaam = model.
            }*/


            KlantgegevensViewModel klantgegevensViewModel = new KlantgegevensViewModel()
            {
                KlantNaam = "Dennis Meijer",
                Adresregel1 = "Kalmoes 4",
                Adresregel2 = "Zolderverdieping",
                Postcode = "7443KB",
                Woonplaats = "Nijverdal"
            };

            return View(klantgegevensViewModel);
        }



    }
}