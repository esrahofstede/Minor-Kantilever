﻿using Case3.FEBestellingen.Site.Managers;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using System.Web.Mvc;

namespace Case3.FEBestellingen.Site.Controllers
{
    /// <summary>
    /// This class is responsible for all interactions with Bestellingen
    /// </summary>
    public class BestellingController : Controller
    {
        private IBestellingManager _bestellingManager;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public BestellingController()
        {
            _bestellingManager = new BestellingManager();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="manager">This should be a mock of IBestellingManager</param>
        public BestellingController(IBestellingManager manager)
        {
            _bestellingManager = manager;
        }
        /// <summary>
        /// This function returns an overview page of a Bestelling
        /// </summary>
        /// <returns>View with products of the Bestelling</returns>
        [Authorize(Roles = "Magazijnmedewerkers")]
        public ActionResult Index()
        {
            var requestMessage = new FindNextBestellingRequestMessage();
            try
            {
                var model = _bestellingManager.FindNextBestelling(requestMessage);
                return View(model);
            }
            catch (System.Exception)
            {
                return View("GeenBestellingen");
            }
            
        }

        /// <summary>
        /// Changes the status of a bestelling
        /// </summary>
        /// <param name="bestellingID">The ID of the Bestelling to update</param>
        [Authorize(Roles = "Magazijnmedewerkers")]
        [HttpPost]
        public void ChangeStatus(long bestellingID)
        {
            _bestellingManager.ChangeStatusOfBestelling(bestellingID);
        }

    }
}