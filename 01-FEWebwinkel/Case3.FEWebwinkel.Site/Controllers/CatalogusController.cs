using Case3.FEWebwinkel.Agent.Exceptions;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
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
            try
            {
                _catalogusManager = new CatalogusManager();
            }
            catch (TechnicalException)
            {
                TechnicalError();
            }
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of ICatalogusManager</param>
        public CatalogusController(ICatalogusManager manager)
        {
            _catalogusManager = manager;
        }
        /// <summary>
        /// This function returns the overview page of the catalog
        /// </summary>
        /// <returns>View with products of the catalog</returns>
        public ActionResult Index()
        {
            try
            {
                var model = _catalogusManager.FindAllProducts();
                return View(model);
            }
            catch (TechnicalException ex)
            {
                TechnicalErrorViewModel model = new TechnicalErrorViewModel(ex.Message);
                return View("CatalogusIndexError", model);
            }
            catch(NullReferenceException)
            {
                return RedirectToAction("TechnicalError");
            }
        }

        /// <summary>
        /// Adds an Artikel to the Winkelmand
        /// </summary>
        /// <param name="articleID">The ID of the chosen article</param>
        [HttpPost]
        public ActionResult Index(int articleID)
        {
            string userGuid;
            CookieNator<Guid> cookieNator;
            try //to get the userGuid from an existing cookie
            {
                cookieNator = new CookieNator<Guid>(Request.Cookies);
                userGuid = cookieNator.GetCookieValue("UserGuid");
            }
            catch (NullReferenceException) //Create a new userGuid if cookie can't be found
            {
                userGuid = Guid.NewGuid().ToString();
                //Set cookie for later usage
                cookieNator = new CookieNator<Guid>(Request.Cookies);
                cookieNator.CreateCookieWithUserGuid(userGuid);
            }
            
            bool succeeded =_catalogusManager.InsertArtikelToWinkelmand(articleID, userGuid);

            return RedirectToAction("Index", new { AddedToWinkelmand = succeeded });
        }
        public ActionResult TechnicalError()
        {
            return View();
        }
    }
}