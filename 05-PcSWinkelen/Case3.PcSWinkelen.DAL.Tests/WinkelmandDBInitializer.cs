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
    /// <summary>
    /// DBInitializer class which initializes the database when the database is being created
    /// </summary>
    internal class WinkelmandDBInitializer : DropCreateDatabaseAlways<WinkelmandContext>
    {
        /// <summary>
        /// Method to add entities to the database
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(WinkelmandContext context)
        {
            if (context != null)
            {
            WinkelmandItem item1 = new WinkelmandItem
            {
                Aantal = 2,
                SessieID = "210c796d-09a6-4ba0-a7d7-09226575f864",
                ProductID = 1234,
                LeveranciersProductId = "58585",
                LeverancierNaam = "Gazelle",
                Naam = "Fietsbel",
                Prijs = 2.00M
            };

            WinkelmandItem item2 = new WinkelmandItem
            {
                Aantal = 2,
                SessieID = "2167f034-d240-4856-8ae7-070fb0ec9155",
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
}
