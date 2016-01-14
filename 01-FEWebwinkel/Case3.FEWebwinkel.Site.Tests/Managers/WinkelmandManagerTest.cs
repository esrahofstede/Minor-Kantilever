using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Case3.FEWebwinkel.Site.Managers;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.PcSWinkelen.Schema;
using Case3.BSCatalogusBeheer.Schema.Product;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Site.Tests.Managers
{
    [TestClass]
    public class WinkelmandManagerTest
    {

        private static WinkelMandCollection CreateWinkelmandCollection()
        {
            var collection = new WinkelMandCollection
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
            return collection;
        }
        

        [TestMethod]
        public void ManagerConvertsWinkelmandResponseToArtikelViewModelList()
        {
            // Arrange
            var collection = CreateWinkelmandCollection();
            //needed to prevent that CatalogusManager connects to PcSWinkelen
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            var target = new WinkelmandManager(agentMock.Object);

            // Act
            List<ArtikelViewModel> result = target.ConvertWinkelmandCollectionToArtikelViewModelList(collection);

            // Assert
            Assert.AreEqual(typeof(List<ArtikelViewModel>), result.GetType());
        }

        [TestMethod]
        public void ManagerConvertsWinkelmandResponseToArtikelViewModelListWithCorrectData()
        {
            // Arrange
            var collection = CreateWinkelmandCollection();
            //needed to prevent that CatalogusManager connects to PcSWinkelen
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            var target = new WinkelmandManager(agentMock.Object);

            // Act
            List<ArtikelViewModel> result = target.ConvertWinkelmandCollectionToArtikelViewModelList(collection);

            // Assert
            Assert.AreEqual(2, result.Count);
            //First Viewmodel
            Assert.AreEqual(1, result[0].ID);
            Assert.AreEqual("Fietsbel", result[0].ArtikelNaam);
            Assert.AreEqual(5.99M, result[0].Prijs);
            Assert.AreEqual(2, result[0].Aantal);
            //Second Viewmodel
            Assert.AreEqual(2, result[1].ID);
            Assert.AreEqual("Zadelpen", result[1].ArtikelNaam);
            Assert.AreEqual(15.12M, result[1].Prijs);
            Assert.AreEqual(1, result[1].Aantal);
        }

        [TestMethod]
        public void ManagerGetsWinkelmandWithCorrectType()
        {
            // Arrange
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            agentMock.Setup(a => a.GetWinkelmand("afsf"))
                     .Returns(CreateWinkelmandCollection());
            var target = new WinkelmandManager(agentMock.Object);

            // Act
            var result = target.GetWinkelmand("afsf");

            // Assert
            Assert.AreEqual(typeof(List<ArtikelViewModel>), result.GetType());
        }

        [TestMethod]
        public void ManagerGetsWinkelmandWithCorrectData()
        {
            // Arrange
            var agentMock = new Mock<IPcSWinkelenAgent>(MockBehavior.Strict);
            agentMock.Setup(a => a.GetWinkelmand("afsf"))
                     .Returns(CreateWinkelmandCollection());
            var target = new WinkelmandManager(agentMock.Object);

            // Act
            var result = target.GetWinkelmand("afsf");

            // Assert
            Assert.AreEqual(2, result.Count);
            //First Viewmodel
            Assert.AreEqual(1, result[0].ID);
            Assert.AreEqual("Fietsbel", result[0].ArtikelNaam);
            Assert.AreEqual(5.99M, result[0].Prijs);
            Assert.AreEqual(2, result[0].Aantal);
            //Second Viewmodel
            Assert.AreEqual(2, result[1].ID);
            Assert.AreEqual("Zadelpen", result[1].ArtikelNaam);
            Assert.AreEqual(15.12M, result[1].Prijs);
            Assert.AreEqual(1, result[1].Aantal);
        }
    }
}
