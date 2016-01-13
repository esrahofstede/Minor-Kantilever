using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using System;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class WinkelmandController : Controller
    {
	    //private BTWCalculator _btwCalculator = new BTWCalculator();
        private ICookieNator<Guid> _cookieNator;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public WinkelmandController()
        {
            _cookieNator = new CookieNator<Guid>(Request.Cookies);
        }
        /// <summary>
        /// This is the constructor for testing purposes
        /// </summary>
        /// <param name="cookieNator">This should be a mock of ICookieNator</param>
        public WinkelmandController(ICookieNator<Guid> cookieNator)
        {
            _cookieNator = cookieNator;
        }

        // GET: Winkelmand
        public ActionResult Index()
        {
            //decimal totaalExclBTW = 0M;
            string userGuid;

            try //to get the list from an existing cookie
            {
                userGuid = _cookieNator.GetCookieValue("UserGuid");
            }
            catch (NullReferenceException) //Create a new list if cookie can't be found
            {
               
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
