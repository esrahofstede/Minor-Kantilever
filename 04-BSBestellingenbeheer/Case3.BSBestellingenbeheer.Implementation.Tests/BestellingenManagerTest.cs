using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Schema;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    [TestClass]
    public class BestellingenManagerTest
    {
        [TestMethod]
        public void BestellingenManagerCreateInstance()
        {
            // Arrange
            // Act
            var bestellingManager = new BestellingManager();

            // Assert
            Assert.IsNotNull(bestellingManager);
            Assert.IsInstanceOfType(bestellingManager, typeof(BestellingManager));
        }

        [TestMethod]
        public void BestellingenManagerFindFirstBestelling()
        {
            // Arrange
            BestellingManager bestellingManager = new BestellingManager();

            // Act
            var result = bestellingManager.FindFirstBestelling();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Bestelling));

            Assert.AreEqual(4, result.Artikelen.Count);

            // Check first product
            Assert.AreEqual(3, result.Artikelen[0].Aantal);
            Assert.AreEqual("fietsbel", result.Artikelen[0].Product.Naam);
            Assert.AreEqual("gazelle", result.Artikelen[0].Product.LeverancierNaam);
            Assert.AreEqual("03g54hbronlsfads", result.Artikelen[0].Product.LeveranciersProductId);

            // Check second product 
            Assert.AreEqual(3, result.Artikelen[1].Aantal);
            Assert.AreEqual("remschijf", result.Artikelen[1].Product.Naam);
            Assert.AreEqual("gazelle", result.Artikelen[1].Product.LeverancierNaam);
            Assert.AreEqual("oiaernglggafds234", result.Artikelen[1].Product.LeveranciersProductId);
        }
    }
}
