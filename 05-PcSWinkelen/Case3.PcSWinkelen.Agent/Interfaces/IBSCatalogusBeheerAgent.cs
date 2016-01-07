using Case3.FEWebwinkel.Schema.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Agent.Interfaces
{
    public interface IBSCatalogusBeheerAgent
    {
        List<Product> GetProducts();
        List<Product> GetProducts(int page, int pageSize);
    }
}
