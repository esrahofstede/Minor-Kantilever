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
        /// 
        /// </summary>
        /// <param name="SessieId"></param>
        /// <returns></returns>
        List<ArtikelViewModel> GetWinkelmand(string SessieId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WinkelmandCollection"></param>
        /// <returns></returns>
        List<ArtikelViewModel> ConvertWinkelmandCollectionToArtikelViewModelList(WinkelMandCollection WinkelmandCollection);
    }
}
