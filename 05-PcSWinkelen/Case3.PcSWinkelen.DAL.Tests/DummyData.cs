using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.DAL.Tests
{
    internal static class DummyData
    {
        internal static WinkelmandItem GetDummyWinkelmandItem = new WinkelmandItem
        {
            Aantal = 5,
            SessieID = Guid.NewGuid().ToString(),
            ProductID = 34576,
            LeveranciersProductId = "8841561",
            LeverancierNaam = "Batavus",
            Naam = "Stuur",
            Prijs = 27.00M
        };
    }
}
