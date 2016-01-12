using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using System;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    /// <summary>
    /// This class is responsible for all interactions with the Catalog
    /// </summary>
    public class CatalogusController : Controller
    {
        private ICatalogusManager _catalogusManager;

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public CatalogusController()
        {
            _catalogusManager = new CatalogusManager();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of CatalogusManager</param>
        public CatalogusController(CatalogusManager manager)
        {
            _catalogusManager = manager;
        }
        /// <summary>
        /// This function returns the overview page of the catalog
        /// </summary>
        /// <returns>View with products of the catalog</returns>
        public ActionResult Index()
        {
            var model = _catalogusManager.GetProducts(1, 20);            

            return View(model);
        }

        /// <summary>
        /// Adds an Artikel to the Winkelmand
        /// </summary>
        /// <param name="artikel">The chosen product that you want to add to your winkelmand</param>
        [HttpPost]
        public ActionResult Index(int ProductID)
        {
            CookieNator<Guid> cookieNator = new CookieNator<Guid>(Request.Cookies);
            string userGuid;
           
            try //to get the userGuid from an existing cookie
            {
                userGuid = cookieNator.GetCookieValue("userGuid");
            }
            catch (NullReferenceException) //Create a new userGuid if cookie can't be found
            {
                userGuid = Guid.NewGuid().ToString();
                //Set cookie for later usage
                cookieNator.CreateCookieWithUserGuid(userGuid);
            }
            
            // -----------------  TODO Call to PcSWinkelen to store Winkelmand  ----------------------------------
            // something like : _catalogusmanager.insertArtikelToWinkelmand(productID, userGuid);
            // -----------------  END TODO  -------------------------

            return RedirectToAction("Index");
        }
    }
}