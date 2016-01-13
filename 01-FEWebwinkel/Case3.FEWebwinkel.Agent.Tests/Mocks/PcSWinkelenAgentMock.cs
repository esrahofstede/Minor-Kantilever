using Case3.FEWebwinkel.Agent.Interfaces;
using System;

using Case3.PcSWinkelen.Schema;
using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.PcSWinkelen.Messages;
using System.Threading.Tasks;

namespace Case3.FEWebwinkel.Agent.Tests.Mocks
{
    public class PcSWinkelenAgentMock : IPcSWinkelenService
    {
        private CatalogusCollection _collection1;

        private CatalogusCollection _collection2 = new CatalogusCollection
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
            _collection1 = new CatalogusCollection();
            for (int i = 0; i < 80; i++)
            {
                _collection1.Add(new CatalogusProductItem
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
        }

        public AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public Task<AddItemToWinkelmandResponseMessage> AddProductToWinkelmandAsync(AddItemToWinkelmandRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request)
        {
            CatalogusCollection collection = new CatalogusCollection();
            if (request.PageSize != _collection2.Count)
            {
                return new FindCatalogusResponseMessage() { Products = _collection1 };
            } else
            {
                return new FindCatalogusResponseMessage() { Products = _collection2 };
            }
            
        }

        public Task<FindCatalogusResponseMessage> GetCatalogusItemsAsync(FindCatalogusRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request)
        {
            throw new NotImplementedException();
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
