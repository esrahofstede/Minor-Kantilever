using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Site.Managers.Interfaces
{
    /// <summary>
    /// The CatalogusManager interface
    /// </summary>
    public interface ICatalogusManager
    {
        /// <summary>
        /// This function returns a List with CatalogusViewModels
        /// </summary>
        /// <param name="page">Current pagenumber</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns>Returns a list with CatalogusViewModels</returns>
        IEnumerable<CatalogusViewModel> GetProducts();

        /// <summary>
        /// This function Convert a List with CatalogusViewModels based on the given CatalogusCollection
        /// </summary>
        /// <param name="catalogusCollection">The collection which has to be converted</param>
        /// <returns>Returns a list with CatalogusViewModels<returns>
        List<CatalogusViewModel> ConvertCatalogusCollectionToCatalogusViewModelList(CatalogusCollection catalogusCollection);
    }
}
