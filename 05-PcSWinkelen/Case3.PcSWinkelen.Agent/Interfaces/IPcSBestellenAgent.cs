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
        /// Method to place a bestelling
        /// </summary>
        /// <param name="bestelling">The Bestelling to place</param>
        /// <returns>A boolean to see if the Bestelling was successfully placed</returns>
        bool BestellingPlaatsen(BestellingPcS bestelling);

        /// <summary>
        /// Method to place bestellingen async
        /// </summary>
        /// <param name="bestelling">The Bestelling to place</param>
        /// <returns>A boolean to see if the Bestelling was successfully placed</returns>
        Task<bool> BestellingPlaatsenAsync(BestellingPcS bestelling);
    }
}
