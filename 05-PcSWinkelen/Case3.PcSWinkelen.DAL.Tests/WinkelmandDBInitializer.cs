using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.DAL.Contexts;
using Case3.PcSWinkelen.Entities;

namespace Case3.PcSWinkelen.DAL.Tests
{
    internal class WinkelmandDBInitializer : DropCreateDatabaseAlways<WinkelmandContext>
    {
        protected override void Seed(WinkelmandContext context)
        {
            WinkelmandItem item1 = new WinkelmandItem
            {
                Aantal = 2,
                SessieID = Guid.NewGuid().ToString(),
                ProductID = 1234,
                LeveranciersProductId = "58585",
                LeverancierNaam = "Gazelle",
                Naam = "Fietsbel",
                Prijs = 2.00M
            };

            WinkelmandItem item2 = new WinkelmandItem
            {
                Aantal = 2,
                SessieID = Guid.NewGuid().ToString(),
                ProductID = 1234,
                LeveranciersProductId = "876554",
                LeverancierNaam = "Gazelle",
                Naam = "Fietsbel 1",
                Prijs = 2.00M
            };

            context.WinkelmandItems.AddRange(new WinkelmandItem[] { item1, item2 });

            base.Seed(context);
        }

    }
}
