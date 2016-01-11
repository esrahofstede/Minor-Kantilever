using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Minor.ServiceBus.Agent.Implementation;
using System.Web.Mvc;
using Case3.FEWebwinkel.Agent;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {


           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}