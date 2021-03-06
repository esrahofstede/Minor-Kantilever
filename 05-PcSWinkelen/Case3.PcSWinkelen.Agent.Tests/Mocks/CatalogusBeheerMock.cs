﻿
using Case3.PcSWinkelen.Schema.Messages;
using Case3.PcSWinkelen.Schema.ProductNS;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.Agent.Tests.Mocks
{
    /// <summary>
    /// Class for testing purposes which creates a fake CatalogusBeheer class
    /// </summary>
    public class CatalogusBeheerMock : ICatalogusBeheer
    {
        private bool ResponseSuccess = true;

        private List<Product> _products = new List<Product>()
        {
            new Product() {
                Id = 1,
                AfbeeldingURL = "9200000015506874.jpg",
                Beschrijving = "Mooie fietsbel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                Prijs = 150.00M,
                Naam = "Fietsbel",
                LeverancierNaam = "Gazelle",
                LeveranciersProductId = "G001"
            },
            new Product() {
                Id = 2,
                AfbeeldingURL = "zadels.jpg",
                Beschrijving = "Mooie zadel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                Prijs = 200.00M,
                Naam = "Zadel",
                LeverancierNaam = "Batavus",
                LeveranciersProductId = "B001"
            },
            new Product() {
                Id = 3,
                AfbeeldingURL = "toeter-600x600.jpg",
                Beschrijving = "Mooie Toeter",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                Prijs = 150.00M,
                Naam = "Toeter",
                LeverancierNaam = "Sparta",
                LeveranciersProductId = "S001"
            },
        };

        [ExcludeFromCodeCoverage]
        public MsgFindCategorieenResult FindCategorieen(MsgFindCategorieenRequest message)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public Task<MsgFindCategorieenResult> FindCategorieenAsync(MsgFindCategorieenRequest message)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public MsgFindLeveranciersResult FindLeveranciers(MsgFindLeveranciersRequest message)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public Task<MsgFindLeveranciersResult> FindLeveranciersAsync(MsgFindLeveranciersRequest message)
        {
            throw new NotImplementedException();
        }

        public MsgFindProductByIdResult FindProductById(MsgFindProductByIdRequest message)
        {
            return new MsgFindProductByIdResult
            {
                Product = _products[1]
            };
        }

        [ExcludeFromCodeCoverage]
        public Task<MsgFindProductByIdResult> FindProductByIdAsync(MsgFindProductByIdRequest message)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a MsgFindProductsResult which includes a fake list of products
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
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

        [ExcludeFromCodeCoverage]
        public Task<MsgFindProductsResult> FindProductsAsync(MsgFindProductsRequest message)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public MsgUpdateCatalogusResult UpdateCatalogus(MsgUpdateCatalogusRequest message)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public Task<MsgUpdateCatalogusResult> UpdateCatalogusAsync(MsgUpdateCatalogusRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
