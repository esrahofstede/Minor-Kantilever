using Case3.FEWebwinkel.Site.Managers;
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
            
            };

            var b = new CatalogusViewModel()
            {
                Naam = "test",
                ID = 1,
                Afbeeldingslocatie = "test",
                Leverancier = "yisdbf",
                Prijs = 12.32M
                
                 //model = bSCatalogusBeheerAgent.GetProducts(1, 20);
            }
            catch
            {
                Naam = "test",
                ID = 1,
                Afbeeldingslocatie = "test",
                Leverancier = "yisdbf",
                Prijs = 12.32M

            }
            var model = _catalogusManager.GetProducts(1, 20);
            return View(model);
        }
    }
}