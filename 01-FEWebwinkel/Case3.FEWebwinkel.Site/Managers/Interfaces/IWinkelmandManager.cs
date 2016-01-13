using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.FEWebwinkel.Site.Managers.Interfaces
{
    interface IWinkelmandManager
    {
        List<ArtikelViewModel> GetWinkelmand(string SessieId);

        List<ArtikelViewModel> ConvertWinkelmandCollectionToArtikelViewModelList(WinkelMandCollection WinkelmandCollection);
    }
}
