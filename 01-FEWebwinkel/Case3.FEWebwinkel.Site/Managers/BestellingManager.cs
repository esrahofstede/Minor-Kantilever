﻿using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Agent;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case3.FEWebwinkel.Site.Managers
{
    /// <summary>
    /// This manager manages the placing of a Bestelling
    /// </summary>
    public class BestellingManager : IBestellingManager
    {
        private IPcSWinkelenAgent _pcsWinkelenAgent;
        private BTWCalculator _btwCalculator = new BTWCalculator();

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public BestellingManager()
        {
            _pcsWinkelenAgent = new PcSWinkelenAgent();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSWinkelenAgent</param>
        public BestellingManager(IPcSWinkelenAgent agent)
        {
            _pcsWinkelenAgent = agent;
        }

        /// <summary>
        /// Places a Bestelling
        /// </summary>
        /// <param name="sessionId">The session ID for the Winkelmand</param>
        /// <param name="klant">The data of the Klant</param>
        public void PlaatsBestelling(string sessionId, KlantRegistreerViewModel klant)
        {
            KlantgegevensPcS klantGegevens = ConvertKlantViewModelToDTO(klant);

            _pcsWinkelenAgent.SendBestelling(sessionId, klantGegevens, (int)_btwCalculator.BTWPercentage);
        }

        /// <summary>
        /// Converts a KlantRegistreerViewModel to a Klantgegevens object
        /// </summary>
        /// <param name="klant">The Klant viewmodel</param>
        /// <returns>A Klantgegevens object with the data from viewmodel</returns>
        public KlantgegevensPcS ConvertKlantViewModelToDTO(KlantRegistreerViewModel klant)
        {

            var klantGegevens = new KlantgegevensPcS
            {
                Naam = klant.Voornaam,
                Adresregel1 = klant.AdresRegel1,
                Adresregel2 = klant.AdresRegel2,
                Postcode = klant.Postcode,
                Woonplaats = klant.Woonplaats,
                Telefoonnummer = klant.Telefoonnummer
            };

            if(klant.Tussenvoegsel != null)
            {
                klantGegevens.Naam += " " + klant.Tussenvoegsel;
            }

            klantGegevens.Naam += " " + klant.Achternaam;

            return klantGegevens;
        }
    }
}