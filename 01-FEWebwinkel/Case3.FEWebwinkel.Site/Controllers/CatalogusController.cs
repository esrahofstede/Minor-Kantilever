using Case3.FEWebwinkel.Site.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class CatalogusController : Controller
    {
        // GET: Catalogus
        public ActionResult Index()
        {

            List<CatalogusViewModel> model = new List<CatalogusViewModel>();

            var a = new CatalogusViewModel()
            {
                Naam = "test",
                ID = 1,
                Afbeeldingslocatie = "test",
                Leverancier = "yisdbf",
                Prijs = 12.32M

            };

            var b = new CatalogusViewModel()
            {
                Naam = "test",
                ID = 1,
                Afbeeldingslocatie = "test",
                Leverancier = "yisdbf",
                Prijs = 12.32M

            };

            var c = new CatalogusViewModel()
            {
                Naam = "test",
                ID = 1,
                Afbeeldingslocatie = "test",
                Leverancier = "yisdbf",
                Prijs = 12.32M

            };

            var d = new CatalogusViewModel()
            {
                Naam = "test",
                ID = 1,
                Afbeeldingslocatie = "test",
                Leverancier = "yisdbf",
                Prijs = 12.32M

            };
            model.Add(a);
            model.Add(b);
            model.Add(c);
            model.Add(d);
            return View(model);
        }
    }
}