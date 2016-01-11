using System.Web.Mvc;

using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Models;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
=======

>>>>>>> 9e007329ddc85efc09dcd6326160dfa79e013387

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

            //List<Product> model = new List<Product>();
            //BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
            
            var model = new CatalogusCollection {
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,}, 
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,}, 
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,}, 
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,}, 
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,}, 
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,}, 
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
            };
            var model2 = _catalogusManager.ConvertCatalogusCollectionToCatalogusViewModelList(model);
            return View(model2);
        }

<<<<<<< HEAD
        /// <summary>
        /// Adds an Artikel to the Winkelmand
        /// </summary>
        /// <param name="artikel">The chosen product that you want to add to your winkelmand</param>
        [HttpPost]
        public ActionResult Index(CatalogusViewModel Catalogusartikel)
        {
            //check if cookie exists
            if (Request.Cookies["artikelen"] == null)
            {
                //create new empty list and add the the artikel
                var artikelLijst = new List<ArtikelViewModel>();
                ArtikelViewModel artikel = CreateArtikelViewModelFromCatalogusViewModel(Catalogusartikel);

                artikelLijst.Add(artikel);

                CreateCookieWithArtikellijst(artikelLijst);
                
            }

            else
            {
                //get the list from the old cookie and add the new artikel to the list
                string jsonStringArtikellijst = Request.Cookies.Get("artikelen").Value;
                var artikelLijst = new JavaScriptSerializer().Deserialize<List<ArtikelViewModel>>(jsonStringArtikellijst);

                ArtikelViewModel artikel = CreateArtikelViewModelFromCatalogusViewModel(Catalogusartikel);

                artikelLijst.Add(artikel);

                CreateCookieWithArtikellijst(artikelLijst);
            }


            var model = new CatalogusCollection {
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
                new ProductVoorraad { Product = new Product{Id = 1, Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "tirepatch_kit_small.gif", LeverancierNaam = "Gazelle", }, Voorraad = 10,},
            };
            var model2 = _catalogusManager.ConvertFindCatalogusResponseMessageToCatalogusViewModelList(model);
            return View(model2);
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
                ArtikelNaam = catalogusArtikel.Naam,
                Aantal = 1,
                Prijs = catalogusArtikel.Prijs.GetValueOrDefault(),
            };
        }

=======
>>>>>>> 9e007329ddc85efc09dcd6326160dfa79e013387
    }
}