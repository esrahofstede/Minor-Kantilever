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

            //var a = new CatalogusViewModel() { Naam = "test", Afbeelding="" } 

            //List<CatalogusViewModel> lijst = new List<CatalogusViewModel>();


            return View();
        }
    }
}