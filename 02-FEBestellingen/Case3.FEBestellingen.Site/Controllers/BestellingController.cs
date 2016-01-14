using Case3.FEBestellingen.Site.Managers;
using Case3.FEBestellingen.Site.Managers.Interfaces;
using Case3.FEBestellingen.Site.ViewModels;
using Case3.PcSBestellen.V1.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        /// <param name="agent">This should be a mock of IPcSWinkelenAgent</param>
        public BestellingController(IBestellingManager manager)
        {
            _bestellingManager = manager;
        }
        /// <summary>
        /// This function returns an overview page of a Bestelling
        /// </summary>
        /// <returns>View with products of the Bestelling</returns>
        public ActionResult Index()
        {
            //dummy data, delete this when real data is available
            var requestMessage = new FindNextBestellingRequestMessage();
            var model = _bestellingManager.FindNextBestelling(requestMessage);
            return View(model);
        }


    }
}