using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.PcSWinkelen.Messages;
using Case3.PcSWinkelen.Schema;
using Minor.ServiceBus.Agent.Implementation;

namespace Case3.FEWebwinkel.Agent
{
    public class PcSWinkelenAgent : IPcSWinkelenAgent
    {
        private ServiceFactory<IPcSWinkelenService> _factory;
        private IPcSWinkelenService _agent;

        public PcSWinkelenAgent()
        {
            //_factory = new ServiceFactory<IPcSWinkelenService>("PcSWinkelen");
            //_agent = _factory.CreateAgent();
        }

        public PcSWinkelenAgent(IPcSWinkelenService agent)
        {
            _agent = agent;
        }

        public CatalogusCollection GetProducts(int page, int pageSize)
        {
            //FindCatalogusResponseMessage result = _agent.GetCatalogusItems(new FindCatalogusRequestMessage() { Page = page, PageSize = pageSize });
            var catalogusCollection = new CatalogusCollection
            {
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 1,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
                new ProductVoorraad {Product = new Product{Id = 1,Naam = "Fietsbel", Prijs = 4.95M, AfbeeldingURL = "awc_jersey_male_small.gif",LeverancierNaam = "Gazelle",}, Voorraad = 10,},
            };
            //return result.Products;
            return catalogusCollection;
        }

        public CatalogusCollection GetProducts()
        {
            FindCatalogusResponseMessage result = _agent.GetCatalogusItems(new FindCatalogusRequestMessage() { Page = 1, PageSize = 20 });
            return result.Products;
        }
    }
}