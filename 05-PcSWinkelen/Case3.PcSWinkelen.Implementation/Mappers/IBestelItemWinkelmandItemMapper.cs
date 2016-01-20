using System.Collections.Generic;
using Case3.PcSBestellen.SchemaNS;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    public interface IBestelItemWinkelmandItemMapper
    {
        Entities.WinkelmandItem MapBestelItemToWinkelmandItem(BestelItemPcS item);
        IEnumerable<Entities.WinkelmandItem> MapBestelItemsToWinkelmandItems(IEnumerable<BestelItemPcS> items);
        BestelItemPcS MapWinkelmandItemToBestelItem(Entities.WinkelmandItem item);
        IEnumerable<BestelItemPcS> MapWinkelmandItemsToBestelItems(IEnumerable<Entities.WinkelmandItem> items);
    }
}