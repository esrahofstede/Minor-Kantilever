using System;
using System.Collections.Generic;
using System.Globalization;

using Case3.PcSBestellen.SchemaNS;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.SchemaNS;
using EntitiesNS = Case3.PcSWinkelen.Entities;
using WinkelenNS = Case3.PcSWinkelen.SchemaNS;
using BestellenNS = Case3.PcSBestellen.SchemaNS;


namespace Case3.PcSWinkelen.Implementation.Tests
{
    /// <summary>
    /// Test data for testing purposes
    /// </summary>
    internal static class DummyData
    {
        private static int _dummyAantal = 2;

        internal static string GetDummyGuid = "7caf01ef-daac-4724-a736-220b00facb21";

        internal static WinkelmandItemRef GetDummyWinkelmandItemRef = new WinkelmandItemRef
        {
            SessieId = GetDummyGuid,
            Aantal = 2,
            ProductId = 1
        };

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

        internal static EntitiesNS.WinkelmandItem GetDummyWinkelmandItem = new EntitiesNS.WinkelmandItem
        {
            ProductID = 1,
            Prijs = 150.00M,
            Naam = "Fietsbel",
            LeverancierNaam = "Gazelle",
            LeveranciersProductId = "G001",
            Aantal = _dummyAantal,
            SessieID = GetDummyGuid
        };

        internal static SchemaNS.WinkelmandItem GetDummyDTOWinkelmandItem = new SchemaNS.WinkelmandItem
        {
            SessieId = GetDummyGuid,
            Product = GetDummyProduct,
            Aantal = _dummyAantal,
        };


        internal static AddItemToWinkelmandRequestMessage GetDummyAddItemToWinkelmandRequestMessage = new AddItemToWinkelmandRequestMessage
        {
            WinkelmandItemRef = GetDummyWinkelmandItemRef
        };

        internal static GetWinkelmandRequestMessage GetDummyGetWinkelmandRequestMessage = new GetWinkelmandRequestMessage
        {
            SessieId = GetDummyGuid
        };

        internal static GetWinkelmandResponseMessage GetDummyGetWinkelmandResponseMessage = new GetWinkelmandResponseMessage
        {
            SessieId = GetDummyGuid,
            WinkelmandCollection = new WinkelMandCollection
            {
                GetDummyDTOWinkelmandItem
            }
        };

        internal static WinkelenNS.KlantgegevensPcS GetDummyKlantgegevensPcSWinkelen = new WinkelenNS.KlantgegevensPcS
        {
            Naam = "Marco Pil",
            Adresregel1 = "Afdeling Infosupport",
            Adresregel2 = "Sint Jacobsstraat 12",
            Postcode = "3511 BS",
            Woonplaats = "Utrecht"
        };

        internal static WinkelenNS.KlantgegevensPcS GetDummyKlantgegevens = new WinkelenNS.KlantgegevensPcS
        {
            Naam = "Marco Pil",
            Adresregel1 = "Afdeling Infosupport",
            Adresregel2 = "Sint Jacobsstraat 12",
            Postcode = "3511 BS",
            Woonplaats = "Utrecht"
        };

        internal static BestelItemPcS GetDummyBestelItem = new BestelItemPcS
        {
            Product = GetDummyProduct,
            Aantal = _dummyAantal
        };

        internal static IEnumerable<BestelItemPcS> GetDummyBestelItems = new List<BestelItemPcS>
        {
            GetDummyBestelItem
        };

        internal static WinkelmandBestellenRequestMessage GetDummyWinkelmandBestellenRequestMessage = new WinkelmandBestellenRequestMessage
        {
            SessieId = GetDummyGuid,
            Klantgegevens = GetDummyKlantgegevens
        };

        internal static BestellingPcS GetDummyBestellingPcS = new BestellingPcS
        {
            Klantgegevens = new BestellenNS.KlantgegevensPcS
            {
                Naam = GetDummyKlantgegevens.Naam,
                Postcode = GetDummyKlantgegevens.Postcode,
                Woonplaats = GetDummyKlantgegevens.Woonplaats,
                Adresregel1 = GetDummyKlantgegevens.Adresregel1,
                Adresregel2 = GetDummyKlantgegevens.Adresregel2
            },
            ArtikelenPcS = new ArtikelenPcS
            {
                new BestelItemPcS
                {
                    Product = GetDummyProduct,
                    Aantal = _dummyAantal
                }
            }

        };

    }
}
