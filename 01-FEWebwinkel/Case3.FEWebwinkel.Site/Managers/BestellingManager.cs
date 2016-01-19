using Case3.FEWebwinkel.Agent;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
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
            _pcsWinkelenAgent.SendBestelling(sessionId, klant);
        }
    }
}