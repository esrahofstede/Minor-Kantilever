using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Agent;
using Case3.FEWebwinkel.Site.Models;
using Case3.FEWebwinkel.Site.ViewModels;
using Newtonsoft.Json;
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