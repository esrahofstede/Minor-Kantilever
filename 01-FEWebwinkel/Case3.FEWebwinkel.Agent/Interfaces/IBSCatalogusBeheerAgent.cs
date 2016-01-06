using Case3.FEWebwinkel.Schema.Product;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Agent.Interfaces
{
    public interface IBSCatalogusBeheerAgent
    {
        List<Product> GetProducts();
        List<Product> GetProducts(int page, int pageSize);
    }
}
