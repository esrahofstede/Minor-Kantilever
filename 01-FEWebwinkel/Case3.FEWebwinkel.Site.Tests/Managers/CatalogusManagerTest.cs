using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Case3.BSCatalogusBeheer.Schema.Product;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using Case3.FEWebwinkel.Agent.Exceptions;
using System;

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
            return collection;
        }
        #endregion
        #region -------[Tests for ConvertCatalogusCollectionToCatalogusViewModelList]-------
        [TestMethod]
        public void ManagerConvertsCatalogusResponseToCatalogusViewModel()
        {
            // Arrange
            var collection = CreateCatalogusCollection();
            //needed to prevent that CatalogusManager connects to PcSWinkelen
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            var target = new CatalogusManager(agentMock.Object);

            // Act
            List<CatalogusViewModel> result = target.ConvertCatalogusCollectionToCatalogusViewModelList(collection);

            // Assert
            Assert.AreEqual(2, result.Count());
            //First Viewmodel
            Assert.AreEqual(1, result[0].ID);
            Assert.AreEqual("Fietsbel", result[0].Naam);
            Assert.AreEqual("Gazelle", result[0].Leverancier);
            Assert.AreEqual(5.99M, result[0].Prijs);
            Assert.AreEqual(10, result[0].Voorraad);
            //Second Viewmodel
            Assert.AreEqual(2, result[1].ID);
            Assert.AreEqual("Zadelpen", result[1].Naam);
            Assert.AreEqual("Giant", result[1].Leverancier);
            Assert.AreEqual(15.12M, result[1].Prijs);
            Assert.AreEqual(10, result[1].Voorraad);
        }
        #endregion
        #region -------[Tests for GetProducts]-------
        [TestMethod]
        public void ManagerGetsProducts()
        {
            // Arrange
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            agentMock.Setup(a => a.GetProducts())
                     .Returns(CreateCatalogusCollection());
            var target = new CatalogusManager(agentMock.Object);

            // Act
            var result = target.FindAllProducts();

            // Assert
            Assert.AreEqual(2, result.Count());
            //First Viewmodel
            Assert.AreEqual(1, result.ElementAt(0).ID);
            Assert.AreEqual("Fietsbel", result.ElementAt(0).Naam);
            Assert.AreEqual("Gazelle", result.ElementAt(0).Leverancier);
            Assert.AreEqual(5.99M, result.ElementAt(0).Prijs);
            Assert.AreEqual(10, result.ElementAt(0).Voorraad);
            //Second Viewmodel
            Assert.AreEqual(2, result.ElementAt(1).ID);
            Assert.AreEqual("Zadelpen", result.ElementAt(1).Naam);
            Assert.AreEqual("Giant", result.ElementAt(1).Leverancier);
            Assert.AreEqual(15.12M, result.ElementAt(1).Prijs);
            Assert.AreEqual(10, result.ElementAt(1).Voorraad);
        }
        #endregion
        #region -------[Tests for InsertArtikelToWinkelmand]-------
        [TestMethod]
        public void ManagerInsertsWinkelmand()
        {
            // Arrange
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            agentMock.Setup(a => a.AddProductToWinkelmand(1, "test"))
                     .Returns(true);
            var target = new CatalogusManager(agentMock.Object);

            // Act
            var result = target.InsertArtikelToWinkelmand(1, "test");

            // Assert
            Assert.IsTrue(result);
        }
        #endregion

        [TestMethod]
        [ExpectedException(typeof(TechnicalException))]
        public void FindAllProductsRethrowsTechnicalException()
        {
            //Arrange
            var mock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            mock.Setup(p => p.GetProducts()).Throws(new TechnicalException());
            CatalogusManager manager = new CatalogusManager(mock.Object);

            //Act
            var result = manager.FindAllProducts();

            //Assert
            //Expect TechnicalException

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FindAllProductsRethrowsException()
        {
            //Arrange
            var mock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            mock.Setup(p => p.GetProducts()).Throws(new NullReferenceException());
            CatalogusManager manager = new CatalogusManager(mock.Object);

            //Act
            var result = manager.FindAllProducts();

            //Assert
            //Expect NullReferenceException
        }
    }
}
