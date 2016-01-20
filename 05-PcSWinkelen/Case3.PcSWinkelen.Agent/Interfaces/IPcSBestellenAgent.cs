using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSBestellen.SchemaNS;

namespace Case3.PcSWinkelen.Agent.Interfaces
{
    /// <summary>
    /// Interface for the PcSBestellenAgent
    /// </summary>
    public interface IPcSBestellenAgent
    {
        /// <summary>
        /// Method to plaats a bestelling
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        bool BestellingPlaatsen(BestellingPcS bestelling);
    }
}
