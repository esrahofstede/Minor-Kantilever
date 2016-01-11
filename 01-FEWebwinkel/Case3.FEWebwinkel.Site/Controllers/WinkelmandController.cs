using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Site.Managers;
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
        private BTWCalculator _btwCalculator = new BTWCalculator();
        // GET: Winkelmand
        public ActionResult Index()
        {
            decimal totaalInclBTW = 0M;
            List<ArtikelViewModel> artikelLijst = null;

            try //to get the list from an existing cookie
            {
                CookieNator<ArtikelViewModel> cookieNator = new CookieNator<ArtikelViewModel>(Request.Cookies);
                artikelLijst = cookieNator.GetCookieValue("artikelen");
            }
            catch (NullReferenceException ex) //Create a new list if cookie can't be found
            {
                artikelLijst = new List<ArtikelViewModel>();
            }

            if (artikelLijst.Count > 0)
            {
                //totaalInclBTW = artikelLijst.Select(artikel => (artikel.Prijs * artikel.Aantal))
                //                            .Sum();
                foreach(ArtikelViewModel artikelViewModel in artikelLijst)
                {
                    totaalInclBTW += artikelViewModel.Prijs * artikelViewModel.Aantal;
                }
            }


            var model = new WinkelmandViewModel
            {
                Artikelen = artikelLijst,
                BTWPercentage = _btwCalculator.BTWPercentage,
                TotaalInclBTW = totaalInclBTW,
                TotaalExclBTW = Math.Round(((totaalInclBTW * 100) / 121), 2),
                TotaalBTW = _btwCalculator.CalculateBTWOfPrice(((totaalInclBTW * 100) / 121)),
            };

            return View(model);
        }
    }
}