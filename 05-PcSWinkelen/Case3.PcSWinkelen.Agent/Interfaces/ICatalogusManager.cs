using Case3.PcSWinkelen.SchemaNS;
using System.Collections.Generic;

namespace Case3.PcSWinkelen.Agent.Interfaces
{
    /// <summary>
    /// Interface for the CatalogusManager
    /// </summary>
    public interface ICatalogusManager
    {
        /// <summary>
        /// Returns a list of Products with the Voorraad of the Products included
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<CatalogusProductItem> GetVoorraadWithProductsList(int page, int pageSize);
    }
}
