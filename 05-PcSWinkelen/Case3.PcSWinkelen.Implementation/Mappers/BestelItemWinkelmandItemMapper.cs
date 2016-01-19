using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.BSBestellingenBeheer.SchemaNS;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.SchemaNS;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    public class BestelItemWinkelmandItemMapper : IBestelItemWinkelmandItemMapper
    {
        public Entities.WinkelmandItem MapBestelItemToWinkelmandItem(BestelItem item)
        {
            return new Entities.WinkelmandItem
            {
                Aantal = item.Aantal,
                LeverancierNaam = item.Product.LeverancierNaam,
                LeveranciersProductId = item.Product.LeveranciersProductId,
                Naam = item.Product.Naam,
                ProductID = item.Product.Id
            };

        }

        public IEnumerable<Entities.WinkelmandItem> MapBestelItemsToWinkelmandItems(IEnumerable<BestelItem> items)
        {
            return items.Select(MapBestelItemToWinkelmandItem).ToList();
        }

        public BestelItem MapWinkelmandItemToBestelItem(Entities.WinkelmandItem item)
        {
            return new BestelItem
            {
                Aantal = item.Aantal,
                Product = new Product
                {
                    LeveranciersProductId = item.LeveranciersProductId,
                    Naam = item.Naam,
                    Prijs = item.Prijs,
                    LeverancierNaam = item.LeverancierNaam,
                    Id = item.ProductID,
                }
            };
        }

        public IEnumerable<BestelItem> MapWinkelmandItemsToBestelItems(IEnumerable<Entities.WinkelmandItem> items)
        {
            return items.Select(MapWinkelmandItemToBestelItem).ToList();
        }
    }
}
