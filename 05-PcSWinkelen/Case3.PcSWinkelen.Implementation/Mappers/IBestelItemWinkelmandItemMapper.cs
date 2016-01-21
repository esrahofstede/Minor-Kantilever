using System.Collections.Generic;
using Case3.PcSBestellen.SchemaNS;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    /// <summary>
    /// Interface for the BestelItemWinkelmandItemMapper
    /// </summary>
    public interface IBestelItemWinkelmandItemMapper
    {
        /// <summary>
        /// Maps a BestelItem to a WinkelmandItem
        /// </summary>
        /// <param name="item">The BestelItem to map to a WinkelmandItem</param>
        /// <returns>A WinkelmandItem</returns>
        Entities.WinkelmandItem MapBestelItemToWinkelmandItem(BestelItemPcS item);
        /// <summary>
        /// Maps a collection of BestelItems to a collection of WinkelmandItems
        /// </summary>
        /// <param name="items">A collection of BestelItems to map to WinkelmandItems</param>
        /// <returns>A collection of WinkelmandItems</returns>
        IEnumerable<Entities.WinkelmandItem> MapBestelItemsToWinkelmandItems(IEnumerable<BestelItemPcS> items);
        /// <summary>
        /// Maps a WinkelmandItem to a BestelItem
        /// </summary>
        /// <param name="item">The WinkelmandItem to map to a BestelItem</param>
        /// <returns>A BestelItem</returns>
        BestelItemPcS MapWinkelmandItemToBestelItem(Entities.WinkelmandItem item);
        /// <summary>
        /// Maps a collection of WinkelmandItems to a collection of BestelItems
        /// </summary>
        /// <param name="items">A collection of WinkelmandItems to map to BestelItems</param>
        /// <returns>A collection of BestelItems</returns>
        IEnumerable<BestelItemPcS> MapWinkelmandItemsToBestelItems(IEnumerable<Entities.WinkelmandItem> items);
    }
}