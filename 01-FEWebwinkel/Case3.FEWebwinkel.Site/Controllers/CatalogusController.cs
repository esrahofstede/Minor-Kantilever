using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.Models;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
        public ActionResult Index(CatalogusViewModel Catalogusartikel)
        {
            List<ArtikelViewModel> artikelLijst = null;

            try //to get the list from an existing cookie and add the new artikel to the list
            {
                CookieNator<ArtikelViewModel> cookieNator = new CookieNator<ArtikelViewModel>(Request.Cookies);
                artikelLijst = cookieNator.GetCookieValue("artikelen");
                //string jsonStringArtikellijst = Request.Cookies.Get("artikelen").Value;
                //artikelLijst = new JavaScriptSerializer().Deserialize<List<ArtikelViewModel>>(jsonStringArtikellijst);
            }
            catch (NullReferenceException ex) //Create a new list if cookie can't be found
            {
                artikelLijst = new List<ArtikelViewModel>();
            }
            //Add the new Artikel to the list
            ArtikelViewModel artikel = CreateArtikelViewModelFromCatalogusViewModel(Catalogusartikel);
            artikelLijst.Add(artikel);

            //Set cookie for later usage
            CreateCookieWithArtikellijst(artikelLijst);

            return RedirectToAction("Index");
        }

        ////////////////////////////////////////////////////////////////////
        //Verplaats onderstaande methodes naar eventuele helper class

        private void CreateCookieWithArtikellijst(List<ArtikelViewModel> artikelLijst)
        {
            //serialize artikelLijst and create cookie
            string MyJsonObject = new JavaScriptSerializer().Serialize(artikelLijst);
            var cookie = new HttpCookie("artikelen", MyJsonObject)
            {
                Expires = DateTime.Now.AddYears(1)
            };

            HttpContext.Response.Cookies.Add(cookie);
        }

        private ArtikelViewModel CreateArtikelViewModelFromCatalogusViewModel(CatalogusViewModel catalogusArtikel)
        {
            return new ArtikelViewModel
            {
                ID = catalogusArtikel.ID,
                ArtikelNaam = catalogusArtikel.Naam,
                Aantal = 1,
                Prijs = catalogusArtikel.Prijs.GetValueOrDefault(),
            };
        }
    }
}