using System;

using Case3.PcSWinkelen.Schema;
using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.PcSWinkelen.Messages;
using System.Threading.Tasks;

namespace Case3.FEWebwinkel.Agent.Tests.Mocks
{
    public class PcSWinkelenAgentMock : IPcSWinkelenService
    {
        private CatalogusCollection largeCollectionPart1;
        private CatalogusCollection largeCollectionPart2;
        private int count;
        private WinkelMandCollection _winkelmandCollection = new WinkelMandCollection
        {
                new WinkelmandItem {

                    Product = new Product
                    {
                        Id = 1,
                        Naam = "Fietsbel",
                        Prijs = 4.95M,
                        AfbeeldingURL = "fietsbel.gif",
                        LeverancierNaam = "Gazelle",
                    },
                    Aantal = 2,
                },
                new WinkelmandItem
                {
                    Product = new Product
                    {
                        Id = 2,
                        Naam = "Zadelpen",
                        Prijs = 12.50M,
                        AfbeeldingURL = "zadelpen.gif",
                        LeverancierNaam = "Giant",
                    },
                    Aantal = 1,
                },
        };

        private CatalogusCollection _smallCollection = new CatalogusCollection
            {
                new CatalogusProductItem {
                    Product = new Product
                    {
                        Id = 1,
                        Naam = "Fietsbel",
                        Prijs = 4.95M,
                        AfbeeldingURL = "fietsbel.gif",
                        LeverancierNaam = "Gazelle",
                    },
                    Voorraad = 10,
                },
                new CatalogusProductItem {
                    Product = new Product
                    {
                        Id = 2,
                        Naam = "Zadelpen",
                        Prijs = 12.50M,
                        AfbeeldingURL = "zadelpen.gif",
                        LeverancierNaam = "Giant",
                    },
                    Voorraad = 10,
                },
            };

        public PcSWinkelenAgentMock()
        {
            count = 0;
            largeCollectionPart1 = new CatalogusCollection();
            for (int i = 0; i < 50; i++)
            {
                largeCollectionPart1.Add(new CatalogusProductItem
                {
                    Product = new Product
                    {
                        Id = i,
                        Naam = "Zadelpen",
                        Prijs = 12.50M,
                        AfbeeldingURL = "zadelpen.gif",
                        LeverancierNaam = "Giant",
                    },
                    Voorraad = 10,
                });
            }

            largeCollectionPart2 = new CatalogusCollection();
            for (int i = 0; i < 30; i++)
            {
                largeCollectionPart2.Add(new CatalogusProductItem
                {
                    Product = new Product
                    {
                        Id = i+50,
                        Naam = "Zadelpen",
                        Prijs = 12.50M,
                        AfbeeldingURL = "zadelpen.gif",
                        LeverancierNaam = "Giant",
                    },
                    Voorraad = 10,
                });
            }
        }

        public AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request)
        {
            bool result;
            if (request.WinkelmandItemRef.SessieId == null)
            {
                result = false;
            }
            else { result = true; }

            return new AddItemToWinkelmandResponseMessage { Succeeded = result };
        }

        public Task<AddItemToWinkelmandResponseMessage> AddProductToWinkelmandAsync(AddItemToWinkelmandRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request)
        {
            CatalogusCollection collection = new CatalogusCollection();

            if (request.PageSize != _smallCollection.Count)
            {
                count++;
                if (count == 1)
                {
                    return new FindCatalogusResponseMessage() { Products = largeCollectionPart1 };
                }
                else
                {
                    return new FindCatalogusResponseMessage() { Products = largeCollectionPart2 };
                }
            }
            else
            {
                return new FindCatalogusResponseMessage() { Products = _smallCollection };
            }
        }

        public Task<FindCatalogusResponseMessage> GetCatalogusItemsAsync(FindCatalogusRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request)
        {
            return new GetWinkelmandResponseMessage { SessieId = "test", WinkelmandCollection = _winkelmandCollection };
        }

        public Task<GetWinkelmandResponseMessage> GetWinkelmandAsync(GetWinkelmandRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public string SayHelloTest(string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> SayHelloTestAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
