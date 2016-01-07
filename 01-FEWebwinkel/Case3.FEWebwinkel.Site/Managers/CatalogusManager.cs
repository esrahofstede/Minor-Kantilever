using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Messages;
using Case3.PcSWinkelen.Schema;

namespace Case3.FEWebwinkel.Site.Managers
{
    public class CatalogusManager : ICatalogusManager
    {
        public IEnumerable<CatalogusViewModel> ConvertFindCatalogusResponseMessageToCatalogusViewModelList(CatalogusCollection catalogusCollection)
        {
            var CatalogusViewModels = catalogusCollection.Select(o => new CatalogusViewModel
            {
                ID = o.Product.Id,
                Afbeeldingslocatie = o.Product.AfbeeldingURL,
                Leverancier = o.Product.LeverancierNaam,
                Naam = o.Product.Naam,
                Prijs = o.Product.Prijs,
                Voorraad = o.Voorraad,
            });

            return CatalogusViewModels.ToList();
        }
    

        public IEnumerable<CatalogusViewModel> GetProducts(int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}