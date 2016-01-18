using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Entities;
using Case3.PcSWinkelen.Schema.ProductNS;
using DTOSchema = Case3.PcSWinkelen.SchemaNS;

namespace Case3.PcSWinkelen.Implementation.Mappers
{
    public class WinkelmandItemDTOMapper : IWinkelmandItemDTOMapper
    {
        public WinkelmandItem MapDTOToEntity(DTOSchema.WinkelmandItem item)
        {
            if (item?.Product.Prijs != null)
                return new WinkelmandItem
                {
                    ProductID = item.Product.Id,
                    Aantal = item.Aantal,
                    SessieID = item.SessieId,
                    LeverancierNaam = item.Product.LeverancierNaam,
                    Naam = item.Product.Naam,
                    Prijs = item.Product.Prijs.Value,
                    LeveranciersProductId = item.Product.LeveranciersProductId
                };
            return null;
        }

        public DTOSchema.WinkelmandItem MapEntityToDTO(Entities.WinkelmandItem item)
        {
            if (item == null)
            {
                return null;
            }
            return new DTOSchema.WinkelmandItem
            {
                Aantal = item.Aantal,
                Product = new Product
                {
                    Id = item.ProductID,
                    LeveranciersProductId = item.LeveranciersProductId,
                    LeverancierNaam = item.LeverancierNaam,
                    Prijs = item.Prijs,
                    Naam = item.Naam
                },
                SessieId = item.SessieID
            };
        }
    }
}
