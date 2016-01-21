using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.PcSBestellen.V1.Messages;
using Case3.PcSBestellen.V1.Schema;

namespace Case3.PcSBestellen.Implementation.Tests
{
    internal static class DummyData
    {
        private static int _dummyAantal = 2;

        internal static Product GetDummyProduct = new Product()
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
        };

        internal static BestellingPlaatsenRequestMessage GetDummyBestellingPlaatsenRequestMessage = new BestellingPlaatsenRequestMessage
        {
            BestellingPcS = new BestellingPcS
            {
                ArtikelenPcS = new ArtikelenPcS
                {
                    new BestelItemPcS
                    {
                        Product = GetDummyProduct,
                        Aantal = _dummyAantal
                    },
                    new BestelItemPcS
                    {
                        Product = GetDummyProduct,
                        Aantal = _dummyAantal
                    },
                },

                Klantgegevens = new KlantgegevensPcS
                {
                    Naam = "Marco Pil",
                    Adresregel1 = "Afdeling Infosupport",
                    Adresregel2 = "Sint Jacobsstraat 12",
                    Postcode = "3511 BS",
                    Woonplaats = "Utrecht"
                }
            }
        };

    }
}
