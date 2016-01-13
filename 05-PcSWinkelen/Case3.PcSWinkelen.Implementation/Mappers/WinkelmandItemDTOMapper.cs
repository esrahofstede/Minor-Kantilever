using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOSchema = Case3.PcSWinkelen.SchemaNS;
using Entities = Case3.PcSWinkelen.DAL.Entities;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    public static class WinkelmandItemDTOMapper
    {
        public static Entities.WinkelmandItem MapDTOToEntity(DTOSchema.WinkelmandItem item)
        {
            return new Entities.WinkelmandItem();
        }

        public static DTOSchema.WinkelmandItem MapEntityToDTO(Entities.WinkelmandItem item)
        {
            return new DTOSchema.WinkelmandItem();
        }
    }
}
