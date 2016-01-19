using Case3.FEWebwinkel.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.FEWebwinkel.Site.Managers.Interfaces
{
    public interface IBestellingManager
    {
        void PlaatsBestelling(string sessionId, KlantRegistreerViewModel klant);
    }
}
