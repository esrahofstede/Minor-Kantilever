using Case3.FEWebwinkel.Site.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;

namespace Case3.FEWebwinkel.Site.Tests.Mocks
{
    public class CatalogusManagerMock : ICatalogusManager
    {
        public List<CatalogusViewModel> ConvertCatalogusCollectionToCatalogusViewModelList(CatalogusCollection catalogusCollection)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CatalogusViewModel> FindAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
