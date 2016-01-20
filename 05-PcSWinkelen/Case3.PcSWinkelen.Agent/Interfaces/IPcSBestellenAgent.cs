using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSBestellen.SchemaNS;

namespace Case3.PcSWinkelen.Agent.Interfaces
{
    public interface IPcSBestellenAgent
    {
        void BestellingPlaatsen(BestellingPcS bestelling);
    }
}
