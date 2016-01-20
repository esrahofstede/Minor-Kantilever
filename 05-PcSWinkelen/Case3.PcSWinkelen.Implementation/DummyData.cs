using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.SchemaNS;

namespace Case3.PcSWinkelen.Implementation
{
    /// <summary>
    /// DummyData for testing purposes
    /// </summary>
    [ExcludeFromCodeCoverage]
    static class DummyData
    {
        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public static WinkelMandCollection Winkelmand = new WinkelMandCollection
            {
                new WinkelmandItem
                {
                    Aantal = 2,
                    Product = new Product
                    {
                        Id = 175,
                        Naam = "All-Purpose Bike Stand",
                        LeverancierNaam = "Bikkel",
                        LeveranciersProductId = "ST-1401",
                        Prijs = 159,
                        AfbeeldingURL = "no_image_available_small.gif"
                    }
                },
                new WinkelmandItem
                {
                    Aantal = 2,
                    Product = new Product
                    {
                        Id = 175,
                        Naam = "AWC Logo Cap",
                        LeverancierNaam = "Batavus",
                        LeveranciersProductId = "CA-1098",
                        Prijs = 8.99M,
                        AfbeeldingURL = "no_image_available_small.gif"
                    }
                },
            };
    }
}
