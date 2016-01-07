using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Site.Managers
{
    public interface ICatalogusManager
    {
        IEnumerable<CatalogusViewModel> GetProducts(int page, int pageSize);
        IEnumerable<CatalogusViewModel> ConvertFindCatalogusResponseMessageToCatalogusViewModelList(CatalogusCollection catalogusCollection);
    }
}
