using System.Web.Mvc;

using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Site.Managers;
using Case3.PcSWinkelen.Schema;


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

    }
}