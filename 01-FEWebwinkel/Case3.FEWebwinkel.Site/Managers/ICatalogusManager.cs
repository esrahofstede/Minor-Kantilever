using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Site.Managers
{
    /// <summary>
    /// The CatalogusManager interface
    /// </summary>
    public interface ICatalogusManager
    {
        List<CatalogusViewModel> GetProducts(int page, int pageSize);
        List<CatalogusViewModel> ConvertFindCatalogusResponseMessageToCatalogusViewModelList(CatalogusCollection catalogusCollection);
    }
}
