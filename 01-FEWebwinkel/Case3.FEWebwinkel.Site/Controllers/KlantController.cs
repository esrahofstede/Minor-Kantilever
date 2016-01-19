﻿using Case3.FEWebwinkel.Site.Managers;
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
        private BestellingManager _bestellingManager;
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
                CookieNator<Guid> cookieNator = new CookieNator<Guid>(Request.Cookies);
                var userGuid = cookieNator.GetCookieValue("UserGuid");

                //TODO hier de koppeling maken met de manager naar pcsWinkelen voor het plaatsen van een bestelling
                //TODO doorlinken naar Bevestigingsview -> Uw bestelling wordt zo snel mogelijk verwerkt
                _bestellingManager.PlaatsBestelling(userGuid,klant);

                return RedirectToAction("Index", "Home");
            }
        }
    }
}