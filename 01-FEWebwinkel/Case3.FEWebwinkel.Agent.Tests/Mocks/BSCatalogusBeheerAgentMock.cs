using Case3.FEWebwinkel.Agent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.FEWebwinkel.Schema.Product;

namespace Case3.FEWebwinkel.Agent.Tests.Mocks
{
    public class BSCatalogusBeheerAgentMock : IBSCatalogusBeheerAgent
    {
        public List<Product> GetProducts(int page, int pageSize)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Naam = "Fietsbel", LeverancierNaam = "Gazelle", LeveranciersProductId = "G001"  },
                new Product() { Id = 2, Naam = "Zadel", LeverancierNaam = "Batavus", LeveranciersProductId = "B001"  },
                new Product() { Id = 3, Naam = "Toeter", LeverancierNaam = "Sparta", LeveranciersProductId = "S001"  },
            };

            return products;
        }

    }
}
