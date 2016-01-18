using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    public interface IWinkelmandItemDTOMapper
    {
        WinkelmandItem MapDTOToEntity(SchemaNS.WinkelmandItem item);
        SchemaNS.WinkelmandItem MapEntityToDTO(WinkelmandItem item);
    }
}