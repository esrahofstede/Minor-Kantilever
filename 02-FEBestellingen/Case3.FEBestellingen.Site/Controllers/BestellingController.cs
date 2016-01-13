using Case3.FEBestellingen.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case3.FEBestellingen.Site.Controllers
{
    /// <summary>
    /// This class is responsible for all interactions with Bestellingen
    /// </summary>
    public class BestellingController : Controller
    {
        /// <summary>
        /// This function returns an overview page of a Bestelling
        /// </summary>
        /// <returns>View with products of the Bestelling</returns>
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