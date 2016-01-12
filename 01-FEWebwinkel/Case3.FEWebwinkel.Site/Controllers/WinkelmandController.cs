using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {
	    //private BTWCalculator _btwCalculator = new BTWCalculator();
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
            //decimal totaalExclBTW = 0M;
            string userGuid;
            CookieNator<Guid> cookieNator = new CookieNator<Guid>(Request.Cookies);

            try //to get the list from an existing cookie
            {
                userGuid = cookieNator.GetCookieValue("UserGuid");
            }
            catch (NullReferenceException) //Create a new list if cookie can't be found
            {
                userGuid = Guid.NewGuid().ToString();
            }

            // ------------- TODO ------------------
            // artikellijst = Managers.getWinkelmand(userGuid);
            //----------- END TODO -----------------


            //if (userGuid.Count > 0)
            //{
            //    totaalExclBTW = artikelLijst.Select(artikel => (artikel.Prijs * artikel.Aantal))
            //                                .Sum();
            //}

            //var totaalInclBTW = _btwCalculator.CalculatePriceInclusiveBTW(totaalExclBTW);

            //var model = new WinkelmandViewModel
            //{
            //    Artikelen = artikelLijst,
            //    BTWPercentage = _btwCalculator.BTWPercentage,
            //    TotaalInclBTW = totaalInclBTW,
            //    TotaalExclBTW = totaalExclBTW,
            //    TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalInclBTW),
            //};

            return View();
        }
    }
}
