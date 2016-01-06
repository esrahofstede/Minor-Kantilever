using Case3.FEWebwinkel.Agent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.FEWebwinkel.Schema.Product;
using System.Globalization;
using Case3.FEWebwinkel.Schema.Messages;

namespace Case3.FEWebwinkel.Agent.Tests.Mocks
{
    public class CatalogusBeheerMock : ICatalogusBeheer
    {
        public bool ResponseSuccess = true;

        private List<Product> _products = new List<Product>()
        {
            new Product() {
                Id = 1,
                AfbeeldingURL = "http://s.s-bol.com/imgbase0/imagebase/large/FC/4/7/8/6/9200000015506874.jpg",
                Beschrijving = "Mooie fietsbel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00"),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00"),
                Prijs = 150.00M,
                Naam = "Fietsbel",
                LeverancierNaam = "Gazelle",
                LeveranciersProductId = "G001"
            },
            new Product() {
                Id = 2,
                AfbeeldingURL = "http://www.hippo-assen.nl/images/zadels.jpg",
                Beschrijving = "Mooie zadel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00"),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00"),
                Prijs = 150.00M,
                Naam = "Zadel",
                LeverancierNaam = "Batavus",
                LeveranciersProductId = "B001"
            },
            new Product() {
                Id = 3,
                AfbeeldingURL = "https://www.damfeestartikelen.nl/image/cache/data/product/main/toeter-600x600.jpg",
                Beschrijving = "Mooie Toeter",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00"),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00"),
                Prijs = 150.00M,
                Naam = "Toeter",
                LeverancierNaam = "Sparta",
                LeveranciersProductId = "S001"
            },
        };

        public MsgFindCategorieenResult FindCategorieen(MsgFindCategorieenRequest message)
        {
            throw new NotImplementedException();
        }

        public Task<MsgFindCategorieenResult> FindCategorieenAsync(MsgFindCategorieenRequest message)
        {
            throw new NotImplementedException();
        }

        public MsgFindLeveranciersResult FindLeveranciers(MsgFindLeveranciersRequest message)
        {
            throw new NotImplementedException();
        }

        public Task<MsgFindLeveranciersResult> FindLeveranciersAsync(MsgFindLeveranciersRequest message)
        {
            throw new NotImplementedException();
        }

        public MsgFindProductByIdResult FindProductById(MsgFindProductByIdRequest message)
        {
            throw new NotImplementedException();
        }

        public Task<MsgFindProductByIdResult> FindProductByIdAsync(MsgFindProductByIdRequest message)
        {
            throw new NotImplementedException();
        }

        public MsgFindProductsResult FindProducts(MsgFindProductsRequest message)
        {

            ProductCollection productCollection = new ProductCollection();
            productCollection.InsertRange(0, _products);

            return new MsgFindProductsResult()
            {
                Succes = ResponseSuccess,
                Products = productCollection
            };
        }

        public Task<MsgFindProductsResult> FindProductsAsync(MsgFindProductsRequest message)
        {
            throw new NotImplementedException();
        }
     
        public MsgUpdateCatalogusResult UpdateCatalogus(MsgUpdateCatalogusRequest message)
        {
            throw new NotImplementedException();
        }

        public Task<MsgUpdateCatalogusResult> UpdateCatalogusAsync(MsgUpdateCatalogusRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
