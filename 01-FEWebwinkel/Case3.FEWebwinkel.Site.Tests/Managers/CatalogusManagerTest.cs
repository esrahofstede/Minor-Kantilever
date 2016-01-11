using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;

namespace Case3.FEWebwinkel.Site.Tests.Managers
{
    /// <summary>
    /// Responsible for testing the CatalogusManager Class
    /// </summary>
    [TestClass]
    public class CatalogusManagerTest
    {
        #region -------[Support functions for tests]-------
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
                    },
                    Voorraad = 10,
                },
                new ProductVoorraad {
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
            return collection;
        }
        #endregion
        #region -------[Tests for ConvertCatalogusCollectionToCatalogusViewModelList]-------
        [TestMethod]
        public void ManagerConvertsCatalogusResponseToCatalogusViewModel()
        {
            // Arrange
            var collection = CreateCatalogusCollection();
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            var target = new CatalogusManager(agentMock.Object);

            // Act
            List<CatalogusViewModel> result = target.ConvertCatalogusCollectionToCatalogusViewModelList(collection);

            // Assert
            Assert.AreEqual(2, result.Count());
            //First Viewmodel
            Assert.AreEqual(1, result[0].ID);
            Assert.AreEqual("Fietsbel", result[0].Naam);
            Assert.AreEqual("../Content/Product_img/fietsbel.gif", result[0].Afbeeldingslocatie);
            Assert.AreEqual("Gazelle", result[0].Leverancier);
            Assert.AreEqual(4.95M, result[0].Prijs);
            Assert.AreEqual(10, result[0].Voorraad);
            //Second Viewmodel
            Assert.AreEqual(2, result[1].ID);
            Assert.AreEqual("Zadelpen", result[1].Naam);
            Assert.AreEqual("../Content/Product_img/zadelpen.gif", result[1].Afbeeldingslocatie);
            Assert.AreEqual("Giant", result[1].Leverancier);
            Assert.AreEqual(12.50M, result[1].Prijs);
            Assert.AreEqual(10, result[1].Voorraad);
        }
        #endregion
        #region -------[Tests for GetProducts]-------
        [TestMethod]
        public void ManagerGetsProducts()
        {
            // Arrange
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            agentMock.Setup(a => a.GetProducts(1, 20))
                     .Returns(CreateCatalogusCollection());
            var target = new CatalogusManager(agentMock.Object);

            // Act
            var result = target.GetProducts(1, 20);

            // Assert
            Assert.AreEqual(2, result.Count());
            //First Viewmodel
            Assert.AreEqual(1, result[0].ID);
            Assert.AreEqual("Fietsbel", result[0].Naam);
            Assert.AreEqual("../Content/Product_img/fietsbel.gif", result[0].Afbeeldingslocatie);
            Assert.AreEqual("Gazelle", result[0].Leverancier);
            Assert.AreEqual(4.95M, result[0].Prijs);
            Assert.AreEqual(10, result[0].Voorraad);
            //Second Viewmodel
            Assert.AreEqual(2, result[1].ID);
            Assert.AreEqual("Zadelpen", result[1].Naam);
            Assert.AreEqual("../Content/Product_img/zadelpen.gif", result[1].Afbeeldingslocatie);
            Assert.AreEqual("Giant", result[1].Leverancier);
            Assert.AreEqual(12.50M, result[1].Prijs);
            Assert.AreEqual(10, result[1].Voorraad);
        }
        #endregion
    }
}
