using Case3.BSCatalogusBeheer.Schema.ProductNSPcS;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.FEBestellingen.Site.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Moq;
using Case3.PcSBestellen.V1.Messages;
using Case3.FEBestellingen.Site.ViewModels;
using case3pcsbestellen.v1.schema;

namespace Case3.FEBestellingen.Site.Tests.Managers
{
    /// <summary>
    /// Responsible for testing the BestellingManager Class
    /// </summary>
    [TestClass]
    public class BestellingManagerTest
    {
        #region -------[Support functions for tests]-------
        private static BestellingPcS CreateBestelling()
        {
            var bestelling = new BestellingPcS
            {
                ArtikelenPcS = new ArtikelenPcS
                {
                   new BestelItemPcS
                   {
                       Product = new Product
                       {
                           Naam = "Fietsbel",
                           LeverancierNaam = "Gazelle",
                           LeveranciersProductId = "GZ12345FB",
                       },
                       Aantal = 1,
                   },
                   new BestelItemPcS
                   {
                       Product = new Product
                       {
                           Naam = "Zadelpen",
                           LeverancierNaam = "Giant",
                           LeveranciersProductId = "GI12345ZP",
                       },
                       Aantal = 2,
                   }
                },
            };
            return bestelling;
        }
        #endregion
        #region -------[Tests for ConvertBestellingtoBestellingViewModel]-------
        [TestMethod]
        public void BestellingManagerConvertsBestellingToBestellingViewModel()
        {
            // Arrange
            var bestelling = CreateBestelling();
            var mock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

            var bestellingManager = new BestellingManager(mock.Object);
            // Act
            var result = bestellingManager.ConvertBestellingToBestellingViewModel(bestelling);
            // Assert
            Assert.IsInstanceOfType(result, typeof(BestellingViewModel));
        }
        [TestMethod]
        public void BestellingManagerConvertsBestellingToCorrectBestellingViewModel()
        {
            // Arrange
            var bestelling = CreateBestelling();
            var mock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

            var bestellingManager = new BestellingManager(mock.Object);
            // Act
            var result = bestellingManager.ConvertBestellingToBestellingViewModel(bestelling);
            var artikelen = result.Artikelen;

            // Assert
            Assert.IsInstanceOfType(result, typeof(BestellingViewModel));
            //First item
            Assert.AreEqual("Fietsbel", artikelen[0].Naam);
            Assert.AreEqual("Gazelle", artikelen[0].Leveranciersnaam);
            Assert.AreEqual("GZ12345FB", artikelen[0].Leverancierscode);
            Assert.AreEqual(1, artikelen[0].Aantal);
            //Second item
            Assert.AreEqual("Zadelpen", artikelen[1].Naam);
            Assert.AreEqual("Giant", artikelen[1].Leveranciersnaam);
            Assert.AreEqual("GI12345ZP", artikelen[1].Leverancierscode);
            Assert.AreEqual(2, artikelen[1].Aantal);
        }
        #endregion
        #region -------[Tests for FindNextBestelling]-------
        [TestMethod]
        public void BestellingManagerGetsNextBestellingReturnsBestellingViewModel()
        {
            // Arrange
            var bestelling = CreateBestelling();
            var requestMessage = new FindNextBestellingRequestMessage();

            var mock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);
            mock.Setup(b => b.FindNextBestelling(requestMessage))
                .Returns(bestelling);

            var bestellingManager = new BestellingManager(mock.Object);

            // Act
            var result = bestellingManager.FindNextBestelling(requestMessage);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BestellingViewModel));
        }
        [TestMethod]
        public void BestellingManagerGetsNextCorrectBestelling()
        {
            // Arrange
            var bestelling = CreateBestelling();
            var requestMessage = new FindNextBestellingRequestMessage();

            var mock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);
            mock.Setup(b => b.FindNextBestelling(requestMessage))
                .Returns(bestelling);

            var bestellingManager = new BestellingManager(mock.Object);

            // Act
            var result = bestellingManager.FindNextBestelling(requestMessage);
            var artikelen = result.Artikelen;

            //Assert
            Assert.AreEqual(2, result.Artikelen.Count);
            //First item
            Assert.AreEqual("Fietsbel", artikelen[0].Naam);
            Assert.AreEqual("Gazelle", artikelen[0].Leveranciersnaam);
            Assert.AreEqual("GZ12345FB", artikelen[0].Leverancierscode);
            Assert.AreEqual(1, artikelen[0].Aantal);
            //Second item
            Assert.AreEqual("Zadelpen", artikelen[1].Naam);
            Assert.AreEqual("Giant", artikelen[1].Leveranciersnaam);
            Assert.AreEqual("GI12345ZP", artikelen[1].Leverancierscode);
            Assert.AreEqual(2, artikelen[1].Aantal);
        }       
        #endregion
    }
}
