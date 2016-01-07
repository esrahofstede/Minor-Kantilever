using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.PcSWinkelen.Schema;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Agent.Interfaces
{
    public interface IPcSWinkelenAgent
    {
        CatalogusCollection GetProducts();
        CatalogusCollection GetProducts(int page, int pageSize);
    }
}
