using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.BSBestellingenbeheer.V1.Schema;
using System.Globalization;
using Case3.BSCatalogusBeheer.Schema.ProductNS;

namespace Case3.BSBestellingenbeheer.Implementation.Tests.Manager
{
    public class BestellingManagerMock : IBestellingManager
    {
        private Bestelling _bestellingOpdracht = new Bestelling()
        {
            Artikelen = new Artikelen()
            {
                new BestelItem()
                {
                    Aantal = 1,
                    Product = new Product()
                    {
                        Id = 1,
                        AfbeeldingURL = "9200000015506874.jpg",
                        Beschrijving = "Mooie fietsbel",
                        LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                        LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                        Prijs = 150.00M,
                        Naam = "Fietsbel",
                        LeverancierNaam = "Gazelle",
                        LeveranciersProductId = "G001"
                    }
                },
                new BestelItem()
                {
                    Aantal = 1,
                    Product = new Product()
                    {
                        Id = 2,
                        AfbeeldingURL = "zadels.jpg",
                        Beschrijving = "Mooie zadel",
                        LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                        LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                        Prijs = 200.00M,
                        Naam = "Zadel",
                        LeverancierNaam = "Batavus",
                        LeveranciersProductId = "B001"
                    }
                },
                new BestelItem()
                {
                    Aantal = 1,
                    Product = new Product()
                    {
                        Id = 3,
                        AfbeeldingURL = "toeter-600x600.jpg",
                        Beschrijving = "Mooie Toeter",
                        LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                        LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                        Prijs = 150.00M,
                        Naam = "Toeter",
                        LeverancierNaam = "Sparta",
                        LeveranciersProductId = "S001"
                    }
                }
            }
        };

        public Bestelling FindFirstBestelling()
        {
            return _bestellingOpdracht;
        }
    }
}
