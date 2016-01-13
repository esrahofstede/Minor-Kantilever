using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {
	    private BTWCalculator _btwCalculator = new BTWCalculator();

        /// <summary>
        /// This is the default constructor
        /// </summary>
       

        // GET: Winkelmand
        public ActionResult Index()
        {
            //decimal totaalExclBTW = 0M;
            string userGuid;
            decimal totaalExclBTW = 0M;
            decimal totaalInclBTW = 0M;

            try //to get the list from an existing cookie
            {
                CookieNator<Guid> cookieNator = new CookieNator<Guid>(Request.Cookies);
                userGuid = cookieNator.GetCookieValue("UserGuid");

                
            }
            catch (NullReferenceException) //Create a new list if cookie can't be found
            {
                userGuid = Guid.NewGuid().ToString();
            }

            // ------------- TODO ------------------
            // artikellijst = Managers.getWinkelmand(userGuid);
            //----------- END TODO -----------------
            var manager = new WinkelmandManager();
            var artikellijst = manager.GetWinkelmand(userGuid);

            //if (userGuid.Count > 0)
            //{
            //    totaalExclBTW = artikelLijst.Select(artikel => (artikel.Prijs * artikel.Aantal))
            //                                .Sum();
            //}
            if (userGuid.Length > 0)
            {
                totaalInclBTW = artikellijst.Select(artikel => (artikel.Prijs * artikel.Aantal)).Sum();
                //totaalExclBTW = 
                
            }

            var model = new WinkelmandViewModel
            {
                Artikelen = artikellijst,
                BTWPercentage = _btwCalculator.BTWPercentage,
                TotaalInclBTW = totaalInclBTW,
                TotaalExclBTW = totaalExclBTW,
                TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalInclBTW),
            };

            //var totaalInclBTW = _btwCalculator.CalculatePriceInclusiveBTW(totaalExclBTW);

            //var model = new WinkelmandViewModel
            //{
            //    Artikelen = artikelLijst,
            //    BTWPercentage = _btwCalculator.BTWPercentage,
            //    TotaalInclBTW = totaalInclBTW,
            //    TotaalExclBTW = totaalExclBTW,
            //    TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalInclBTW),
            //};

            return View(model);// new WinkelmandViewModel());
        }
    }
}
