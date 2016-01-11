using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Site.Managers;
using Case3.PcSWinkelen.Schema;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
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
            var model2 = _catalogusManager.ConvertFindCatalogusResponseMessageToCatalogusViewModelList(model);
            return View(model2);
        }

        /// <summary>
        /// Adds an Artikel to the Winkelmand
        /// </summary>
        /// <param name="artikel">The chosen product that you want to add to your winkelmand</param>
        [HttpPost]
        public void AddToWinkelmand(CatalogusViewModel artikel)
        {
            
            HttpCookie cookie = new HttpCookie("WinkelmandCookie");
            //cookie.Value= JsonConvert.SerializeObject(artikel);
            cookie.Values.Add("Naam", artikel.Naam);
            cookie.Values.Add("Leverancier", artikel.Leverancier);
            cookie.Values.Add("Prijs", artikel.Prijs.ToString());
            Response.Cookies.Add(cookie);
        }
    }
}