using Case3.FEWebwinkel.Agent;
using Case3.FEWebwinkel.Schema.Product;
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

            List<Product> model = new List<Product>();
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent();
            
            try
            {
                
                 model = bSCatalogusBeheerAgent.GetProducts(1, 20);
            }
            catch
            {

            }

            return View(model);
        }
    }
}