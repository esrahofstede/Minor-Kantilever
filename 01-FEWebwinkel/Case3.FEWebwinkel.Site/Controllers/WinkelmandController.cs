using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {


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

            string jsonStringArtikelList = Request.Cookies.Get("artikelen").Value;

            List<ArtikelViewModel> artikelLijst = new JavaScriptSerializer().Deserialize<List<ArtikelViewModel>>(jsonStringArtikelList);

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