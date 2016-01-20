﻿using Case3.FEWebwinkel.Agent;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using case3bsbestellingenbeheer.v1.schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case3.FEWebwinkel.Site.Managers
{
    public class BestellingManager : IBestellingManager
    {
        private IPcSWinkelenAgent _pcsWinkelenAgent;

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


        public void PlaatsBestelling(string sessionId, KlantRegistreerViewModel klant)
        {
            Klantgegevens klantGegevens = ConvertKlantViewModelToDTO(klant);

            _pcsWinkelenAgent.SendBestelling(sessionId, klantGegevens);
        }

        public Klantgegevens ConvertKlantViewModelToDTO(KlantRegistreerViewModel klant)
        {
            return new Klantgegevens
            {
                Naam = $"{klant.Voornaam} {klant.Tussenvoegsel} {klant.Achternaam}",
                Adresregel1 = klant.AdresRegel1,
                Adresregel2 = klant.AdresRegel2,
                Postcode = klant.Postcode,
                Woonplaats = klant.Woonplaats,
                Telefoonnummer = klant.Telefoonnummer
            };
        }
    }
}