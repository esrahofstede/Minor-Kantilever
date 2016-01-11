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
            var artikel1 = new ArtikelViewModel
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
            var artikelLijst = new List<ArtikelViewModel> { artikel1, artikel2 };
            
            var model = new WinkelmandViewModel
            {
                Artikelen = artikelLijst,
                BTWPercentage = 21M,
                TotaalInclBTW = 24.85M,
                TotaalExclBTW = 20.54M,
                TotaalBTW = 4.31M,
            };

            //Get data from cookie which has been set in catalogus view
            string jsonStringKlant = Request.Cookies.Get("artikel").Value;
            var artikelLijst2 = new JavaScriptSerializer().Deserialize<List<ArtikelViewModel>>(jsonStringKlant);

            return View(model);
        }
    }
}