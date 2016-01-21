using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSBestellen.SchemaNS;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.SchemaNS;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    /// <summary>
    /// This class maps BestelItems and WinkelmandItems
    /// </summary>
    public class BestelItemWinkelmandItemMapper : IBestelItemWinkelmandItemMapper
    {
        /// <summary>
        /// Maps a BestelItem to a WinkelmandItem
        /// </summary>
        /// <param name="item">The BestelItem to map to a WinkelmandItem</param>
        /// <returns>A WinkelmandItem</returns>
        public Entities.WinkelmandItem MapBestelItemToWinkelmandItem(BestelItemPcS item)
        {
            if (item == null)
            {
                return null;
            }
            return new Entities.WinkelmandItem
            {
                Aantal = item.Aantal,
                LeverancierNaam = item.Product.LeverancierNaam,
                LeveranciersProductId = item.Product.LeveranciersProductId,
                Naam = item.Product.Naam,
                ProductID = item.Product.Id
            };

        }

        /// <summary>
        /// Maps a collection of BestelItems to a collection of WinkelmandItems
        /// </summary>
        /// <param name="items">A collection of BestelItems to map to WinkelmandItems</param>
        /// <returns>A collection of WinkelmandItems</returns>
        public IEnumerable<Entities.WinkelmandItem> MapBestelItemsToWinkelmandItems(IEnumerable<BestelItemPcS> items)
        {
            return items.Select(MapBestelItemToWinkelmandItem).ToList();
        }

        /// <summary>
        /// Maps a WinkelmandItem to a BestelItem
        /// </summary>
        /// <param name="item">The WinkelmandItem to map to a BestelItem</param>
        /// <returns>A BestelItem</returns>
        public BestelItemPcS MapWinkelmandItemToBestelItem(Entities.WinkelmandItem item)
        {
            if (item == null)
            {
                return null;
            }
            return new BestelItemPcS
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

        /// <summary>
        /// Maps a collection of WinkelmandItems to a collection of BestelItems
        /// </summary>
        /// <param name="items">A collection of WinkelmandItems to map to BestelItems</param>
        /// <returns>A collection of BestelItems</returns>
        public IEnumerable<BestelItemPcS> MapWinkelmandItemsToBestelItems(IEnumerable<Entities.WinkelmandItem> items)
        {
            return items.Select(MapWinkelmandItemToBestelItem).ToList();
        }
    }
}
