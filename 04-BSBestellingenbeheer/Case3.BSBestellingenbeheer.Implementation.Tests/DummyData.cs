using System;
using Case3.BSBestellingenbeheer.V1.Schema;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    internal class DummyData
    {
        internal Bestelling BestellingValid = new Bestelling()
        {
            BestellingID = 1,
            FactuurDatum = new DateTime(2015, 12, 12).ToString(),
            FactuurID = 1,
            Status = 1,
            BTWPercentage = 21,
            Klantgegevens = new Klantgegevens()
            {
                Naam = "Remco",
                Adresregel1 = "Hofmeesterij 89",
                Woonplaats = "Huissen",
                Postcode = "6852NC",
                Telefoonnummer = "0612697691"
            },
            Artikelen = new Artikelen()
            {
                new BestelItem()
                {
                    Product = new BSCatalogusBeheer.Schema.ProductNS.Product()
                    {
                        Id = 1,
                        Naam = "Fietsbel",
                        LeverancierNaam = "Gazelle",
                        LeveranciersProductId = "GA01"
                    },
                    Aantal = 5
                }
            }
        };

        internal Bestelling BestellingInvalid = new Bestelling()
        {
           
            Klantgegevens = new Klantgegevens()
            {
            },
            Artikelen = new Artikelen()
            {
                new BestelItem()
                {
                    Aantal = 5
                }
            }
        };

        internal Bestelling BestellingInvalidDatum = new Bestelling()
        {
            BestellingID = 45435,
            FactuurDatum = "202",
            FactuurID = 1,
            Status = 1,
            BTWPercentage = 7,
            Klantgegevens = new Klantgegevens()
            {
                Naam = "Remco",
                Adresregel1 = "Hofmeesterij 89",
                Woonplaats = "Huissen",
                Postcode = "6852NC",
                Telefoonnummer = "0612697691"
            },
            Artikelen = new Artikelen()
            {
                new BestelItem()
                {
                    Product = new BSCatalogusBeheer.Schema.ProductNS.Product()
                    {
                        Id = 1,
                        Naam = "Fietsbel",
                        LeverancierNaam = "Gazelle",
                        LeveranciersProductId = "GA01"
                    },
                    Aantal = 5
                }
            }
        };

        internal Bestelling Bestelling = new Bestelling()
        {
            BestellingID = 1,
            FactuurDatum = new DateTime(2015, 12, 12).ToString(),
            FactuurID = 1,
            Status = 1,
            BTWPercentage = 19,
            Klantgegevens = new Klantgegevens()
            {
                Naam = "Remco",
                Adresregel1 = "Hofmeesterij 89",
                Woonplaats = "Huissen",
                Postcode = "6852NC",
                Telefoonnummer = "0612697691"
            },
            Artikelen = new Artikelen()
                    {
                        new BestelItem()
                        {
                            Product = new BSCatalogusBeheer.Schema.ProductNS.Product()
                            {
                                Id = 1,
                                Naam = "Fietsbel",
                                LeverancierNaam = "Gazelle",
                                LeveranciersProductId = "GA01"
                            },
                            Aantal = 5
                        }
                    }
        };

        internal Entities.Bestelling BestellingEntity = new Entities.Bestelling()
        {
            ID = 1,
            BestelDatum = DateTime.Now,
            Status = 0,
            Artikelen = null,
            AdresRegel1 = "Hofmeesterij 89",
            KlantNaam = "Henk Jansen",
            Postcode = "6738PK",
            Woonplaats = "Veenendaal",
            BTWPercentage = 21,
            Telefoonnummer = "0654789542",
        };



        internal Bestelling InvalidBestelling = new Bestelling()
        {
            BestellingID = 1,
            FactuurDatum = new DateTime(2015, 12, 12).ToString(),
            Klantgegevens = new Klantgegevens()
            {
                Naam = "Remco",
                Telefoonnummer = "0612697691"
            },
            Artikelen = new Artikelen()
                    {
                        new BestelItem()
                        {
                            Product = new BSCatalogusBeheer.Schema.ProductNS.Product()
                            {
                                Id = 1,
                                Naam = "Fietsbel",
                                LeverancierNaam = "Gazelle",
                                LeveranciersProductId = "GA01"
                            },
                            Aantal = 5
                        }
                    }
        };
    }
}