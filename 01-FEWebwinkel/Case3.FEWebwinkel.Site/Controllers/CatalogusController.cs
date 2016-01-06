using Case3.FEWebwinkel.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class CatalogusController : Controller
    {
        // GET: Catalogus
        public ActionResult Index()
        {

            var a = new Product.Product() {
                Naam = "Test",
                AfbeeldingURL = "http://t1.gstatic.com/images?q=tbn:ANd9GcRZUowFEn9dqtFvBQbopf7V922QlsDuYe0B4nMuLCrn8wsNQqVjeKJsLWQ",
                LeverancierNaam = "Gazelle",
                Prijs = 421.422M,
                Id = 1
            };
            
            var b = new Product.Product()
            {
                Naam = "Test",
                AfbeeldingURL = "http://t1.gstatic.com/images?q=tbn:ANd9GcRZUowFEn9dqtFvBQbopf7V922QlsDuYe0B4nMuLCrn8wsNQqVjeKJsLWQ",
                LeverancierNaam = "Gazelle",
                Prijs = 421.422M,
                Id = 1
            };
            var c = new Product.Product()
            {
                Naam = "Test",
                AfbeeldingURL = "http://t1.gstatic.com/images?q=tbn:ANd9GcRZUowFEn9dqtFvBQbopf7V922QlsDuYe0B4nMuLCrn8wsNQqVjeKJsLWQ",
                LeverancierNaam = "Gazelle",
                Prijs = 421.422M,
                Id = 1
            };
            var d = new Product.Product()
            {
                Naam = "Test",
                AfbeeldingURL = "http://t1.gstatic.com/images?q=tbn:ANd9GcRZUowFEn9dqtFvBQbopf7V922QlsDuYe0B4nMuLCrn8wsNQqVjeKJsLWQ",
                LeverancierNaam = "Gazelle",
                Prijs = 421.422M,
                Id = 1
            };

            List<Product.Product> lijst = new List<Product.Product>();

            lijst.Add(a);
            lijst.Add(b);
            lijst.Add(c);
            lijst.Add(d);


            return View(lijst);
        }
    }
}