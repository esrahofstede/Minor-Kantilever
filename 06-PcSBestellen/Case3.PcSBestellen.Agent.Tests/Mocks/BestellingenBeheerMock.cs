using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Case3.PcSBestellen.Agent.Tests.Mocks
{
    public class BestellingenBeheerMock : IBSBestellingenbeheerService
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


        public FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage)
        {
            return new FindFirstBestellingResultMessage()
            {
                BestellingOpdracht = _bestellingOpdracht,
            };
        }

        public Task<FindFirstBestellingResultMessage> FindFirstBestellingAsync(FindFirstBestellingRequestMessage requestMessage)
        {
            throw new NotImplementedException();
        }

        public InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage bestelling)
        {
            throw new NotImplementedException();
        }

        public Task<InsertBestellingResultMessage> InsertBestellingAsync(InsertBestellingRequestMessage bestelling)
        {
            throw new NotImplementedException();
        }

        public UpdateBestellingResultMessage UpdateBestelling(UpdateBestellingRequestMessage bestelling)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateBestellingResultMessage> UpdateBestellingAsync(UpdateBestellingRequestMessage bestelling)
        {
            throw new NotImplementedException();
        }
    }
}
