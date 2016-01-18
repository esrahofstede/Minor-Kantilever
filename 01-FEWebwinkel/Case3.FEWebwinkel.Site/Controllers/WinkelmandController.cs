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
        private IWinkelmandManager _winkelmandManager;

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public WinkelmandController()
        {
            _winkelmandManager = new WinkelmandManager();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of ICatalogusManager</param>
        public WinkelmandController(IWinkelmandManager manager)
        {
            _winkelmandManager = manager;
        }


        // GET: Winkelmand
        /// <summary>
        /// This function returns a view of the user's Winkelmand
        /// </summary>
        /// <returns>Returns a view with the data of a WinkelmandViewModel</returns>
        public ActionResult Index()
        {
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
            
            var artikellijst = _winkelmandManager.GetWinkelmand(userGuid);
            if (userGuid.Length > 0)
            {
                totaalInclBTW = artikellijst.Select(artikel => (artikel.Prijs * artikel.Aantal)).Sum();
                //need up to date version of btwCalculator for this, uncomment this when ready:
                //totaalExclBTW = _btwCalculator.CalculatePriceExclBTW(totaalInclBTW);

            }

            var model = new WinkelmandViewModel
            {
                Artikelen = artikellijst,
                BTWPercentage = _btwCalculator.BTWPercentage,
                TotaalInclBTW = totaalInclBTW,
                TotaalExclBTW = totaalExclBTW,
                TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalExclBTW),
            };

            return View(model);
        }
    }
}
