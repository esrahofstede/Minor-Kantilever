using System.Collections.Generic;
using Case3.BSBestellingenBeheer.SchemaNS;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    public interface IBestelItemWinkelmandItemMapper
    {
        Entities.WinkelmandItem MapBestelItemToWinkelmandItem(BestelItem item);
        IEnumerable<Entities.WinkelmandItem> MapBestelItemsToWinkelmandItems(IEnumerable<BestelItem> items);
        BestelItem MapWinkelmandItemToBestelItem(Entities.WinkelmandItem item);
        IEnumerable<BestelItem> MapWinkelmandItemsToBestelItems(IEnumerable<Entities.WinkelmandItem> items);
    }
}