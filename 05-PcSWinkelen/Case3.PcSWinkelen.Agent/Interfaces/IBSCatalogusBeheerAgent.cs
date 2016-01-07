using Case3.PcSWinkelen.Schema.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Agent.Interfaces
{
    public interface IBSCatalogusBeheerAgent
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>IEnumerable of Product entities</returns>
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Get products by page and page length
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>IEnumerable of Product entities</returns>
        IEnumerable<Product> GetProducts(int page, int pageSize);
    }
}
