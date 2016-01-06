using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Minor.ServiceBus.Agent.Implementation;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    public class HomeController : Controller
    {
        //private ServiceFactory<ICatalogusBeheer> _factory;

        public ActionResult Index()
        {
            
            /*ICatalogusBeheer agent = _factory.CreateAgent();
            MsgFindProductsResult result = agent.FindProducts(new MsgFindProductsRequest());

            ViewBag.Products = result.Products;*/



            /*ICatalogusBeheer catalogusBeheerClientProxy = new CatalogusBeheerClient("", "http://minorbldsrv:4000/Design_Time_Addresses/Kantilever/BSCatalogusBeheer/");
            MsgFindProductsRequest findProductRequestMessage = new MsgFindProductsRequest();
            MsgFindProductsResult findProductResultMessage = catalogusBeheerClientProxy.FindProducts(findProductRequestMessage);
            */


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