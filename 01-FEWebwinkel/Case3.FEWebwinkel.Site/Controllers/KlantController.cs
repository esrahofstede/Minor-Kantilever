using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using System;
using System.Web.Mvc;

namespace Case3.FEWebwinkel.Site.Controllers
{
    /// <summary>
    /// This class is responsible for all interactions with the Klant
    /// </summary>
    public class KlantController : Controller
    {
        private IBestellingManager _bestellingManager;
        private ICookieNator<Guid> _cookieNator;

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public KlantController()
        {
            _bestellingManager = new BestellingManager();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of ICatalogusManager</param>
        public KlantController(IBestellingManager manager)
        {
            _bestellingManager = manager;
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of ICatalogusManager</param>
        public KlantController(IBestellingManager manager, ICookieNator<Guid> cookieNator)
        {
            _bestellingManager = manager;
            _cookieNator = cookieNator;
        }

        /// <summary>
        /// This function is responsible for returning the registreer klant form
        /// </summary>
        /// <returns>View with form for Klanten</returns>
        public ActionResult Index()
        {
            var model = new KlantRegistreerViewModel();

            return View(model);
        }
        /// <summary>
        /// This function is responsible for handling the posted KlantRegistreerViewModel
        /// </summary>
        /// <param name="klant">KlantRegistreerViewModel which has to be evaluated<param>
        /// <returns>Confirmationview that</returns>
        [HttpPost]
        public ActionResult Create(KlantRegistreerViewModel klant)
        {
            if (!ModelState.IsValid)
            {
                return View(klant);
            }
            else
            {
                if (_cookieNator == null)
                {
                    _cookieNator = new CookieNator<Guid>(Request.Cookies);
                }

                var userGuid = _cookieNator.GetCookieValue("UserGuid");
                    
                _bestellingManager.PlaatsBestelling(userGuid,klant);

                return RedirectToAction("Bestellen", "Winkelmand");
            }
        }
    }
}