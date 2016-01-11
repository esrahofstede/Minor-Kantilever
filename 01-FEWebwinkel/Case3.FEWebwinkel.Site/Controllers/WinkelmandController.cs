using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {

        private ICookieNator<ArtikelViewModel> _cookieNator;
        public WinkelmandController()
        {

        }
        public WinkelmandController(ICookieNator<ArtikelViewModel> cookieNator)
        {
            _cookieNator = cookieNator;
        }

        // GET: Winkelmand
        public ActionResult Index()
        {
            /*var artikel1 = new ArtikelViewModel
            {
                ArtikelNaam = "Fietsbel",
                Aantal = 2,
                Prijs = 4.95M,
            };
            var artikel2 = new ArtikelViewModel
            {
                ArtikelNaam = "Zadelpen",
                Aantal = 1,
                Prijs = 14.95M,
            };
            var artikelLijst = new List<ArtikelViewModel> { artikel1, artikel2 };*/

            //Get data from cookie which has been set in catalogus view
            //string jsonStringArtikelList = Request.Cookies.Get("artikelen").Value;

            //List<ArtikelViewModel> artikelLijst = new JavaScriptSerializer().Deserialize<List<ArtikelViewModel>>(jsonStringArtikelList);

            _cookieNator = new CookieNator<ArtikelViewModel>(Request.Cookies);

            List<ArtikelViewModel> artikelLijst = _cookieNator.GetCookieValue("artikelen");

            decimal TotaalExclBTW = 0M;

            if (artikelLijst.Count > 0)
            {
                foreach(ArtikelViewModel artikelViewModel in artikelLijst)
                {
                    TotaalExclBTW += artikelViewModel.Prijs * artikelViewModel.Aantal;
                }
            }

            BTWCalculator bTWCalculator = new BTWCalculator();

            var model = new WinkelmandViewModel
            {
                Artikelen = artikelLijst,
                BTWPercentage = bTWCalculator.BTWPercentage,
                TotaalInclBTW = bTWCalculator.CalculatePriceInclusiveBTW(TotaalExclBTW),
                TotaalExclBTW = TotaalExclBTW,
                TotaalBTW = bTWCalculator.CalculateBTWOfPrice(TotaalExclBTW),
            };

            return View(model);
        }
    }
}