using Case3.BTWConfigurationReader;
using Case3.FEBestellingen.Site.Managers;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;
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
        private BTWCalculator _btwCalculator = new BTWCalculator();

        public FactuurController()
        {
            _bestellingManager = new BestellingManager();
        }

        // GET: Factuur
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

        [Authorize(Roles = "Magazijnmedewerkers")]
        public ActionResult AfleverAdres()
        {
            var model = _bestellingManager.FindNextBestelling(new FindNextBestellingRequestMessage());

            decimal totaalInclBTW = (decimal)model.Artikelen.Select(artikel => (artikel.Prijs * artikel.Aantal)).Sum();
            decimal totaalExclBTW = _btwCalculator.CalculatePriceExclBTW(totaalInclBTW);

            model.BTWPercentage = _btwCalculator.BTWPercentage;
            model.TotaalInclBTW = totaalInclBTW;
            model.TotaalExclBTW = totaalExclBTW;
            model.TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalExclBTW);

            return View(model);
        }
    }
}