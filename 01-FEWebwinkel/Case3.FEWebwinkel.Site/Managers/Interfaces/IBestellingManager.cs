using Case3.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.FEWebwinkel.Site.Managers.Interfaces
{
    /// <summary>
    /// The interface of the BestellingManager
    /// </summary>
    public interface IBestellingManager
    {
        /// <summary>
        /// Places a Bestelling
        /// </summary>
        /// <param name="sessionId">The session ID for the Winkelmand</param>
        /// <param name="klant">The data of the Klant</param
        void PlaatsBestelling(string sessionId, KlantRegistreerViewModel klant);
    }
}
