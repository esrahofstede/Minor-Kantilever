using Case3.FEBestellingen.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case3.FEBestellingen.Site.Controllers
{
    public class BestellingController : Controller
    {
        // GET: Bestelling
        public ActionResult Index()
        {
            //dummy data, delete this when real data is available
            var artikel1 = new ArtikelViewModel { Naam = "fietsbel", Leveranciersnaam = "Gazelle", Leverancierscode = "012489", Aantal = 2 };
            var artikel2 = new ArtikelViewModel { Naam = "zadelpen", Leveranciersnaam = "Gazelle", Leverancierscode = "424521", Aantal = 1 };
            List<ArtikelViewModel> artikelen = new List<ArtikelViewModel>() { artikel1, artikel2 };
            var model = new BestellingViewModel { Artikelen = artikelen };

            return View(model);
        }


    }
}