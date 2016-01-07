using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSWinkelen.Schema;
using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Site.Managers;
using System.Linq;

namespace Case3.FEWebwinkel.Site.Tests.Managers
{
    [TestClass]
    public class CatalogusManagerTest
    {

        [TestMethod]
        public void ManagerConvertsCatalogusResponseToCatalogusViewModel()
        {
            // Arrange
            var collection = CreateCatalogusCollection();
            var target = new CatalogusManager();

            // Act
            var result = target.ConvertFindCatalogusResponseMessageToCatalogusViewModelList(collection);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        private static CatalogusCollection CreateCatalogusCollection()
        {
            var collection = new CatalogusCollection
            {
                new ProductVoorraad {
                    Product = new Product
                    {
                        Id = 1,
                        Naam = "Fietsbel",
                        Prijs = 4.95M,
                        AfbeeldingURL = "fietsbel.gif",
                        LeverancierNaam = "Gazelle",
                    }
                },
                new ProductVoorraad {
                    Product = new Product
                    {
                        Id = 2,
                        Naam = "Zadelpen",
                        Prijs = 12.50M,
                        AfbeeldingURL = "zadelpen.gif",
                        LeverancierNaam = "Giant",
                    }
                },
            };
            return collection;
        }
    }
}
