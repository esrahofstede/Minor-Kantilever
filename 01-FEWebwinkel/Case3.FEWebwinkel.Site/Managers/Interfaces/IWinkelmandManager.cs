using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.FEWebwinkel.Site.Managers.Interfaces
{
    /// <summary>
    /// The WinkelmandManager interface
    /// </summary>
    public interface IWinkelmandManager
    {
        /// <summary>
        /// This function gets a filled WinkelmandViewModel
        /// </summary>
        /// <param name="SessieId">The Id to find the correct Winkelmand</param>
        /// <returns>Returns a WinkelmandViewModel</returns>
        WinkelmandViewModel GetWinkelmand(string sessionId);

        /// <summary>
        /// This function Converts a List with ArtikelViewModels based on the given WinkelMandCollection
        /// </summary>
        /// <param name="WinkelmandCollection">The collection which has to be converted</param>
        /// <returns>Returns a list with ArtikelViewModels</returns>
        List<ArtikelViewModel> ConvertWinkelmandCollectionToArtikelViewModelList(WinkelMandCollection winkelmandCollection);
    }
}
