
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Agent.Interfaces
{
    public interface ICatalogusManager
    {
        IEnumerable<CatalogusProductItem> GetVoorraadWithProductsList(int page, int pageSize);
    }
}
