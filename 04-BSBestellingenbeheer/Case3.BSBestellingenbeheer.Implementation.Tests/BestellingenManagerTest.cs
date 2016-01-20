using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Schema;
using System.Collections.Generic;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    /// <summary>
    /// Testclass for testint the BestellingenManager
    /// </summary>
    [TestClass]
    public class BestellingenManagerTest
    {
        /// <summary>
        /// Creates instance of BestellingManager and checks if the manager is instantiated correctly
        /// </summary>
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

        /// <summary>
        /// Gets the first bestelling and checks that bestelling
        /// </summary>
        [TestMethod]
        public void BestellingenManageConvertBestelling()
        {
            // Arrange
            BestellingManager bestellingManager = new BestellingManager();

            DateTime datum = DateTime.Now;

            Entities.Bestelling bestelling = new Entities.Bestelling()
            {
                ID = 1,
                BestelDatum = datum,
                Status = 0,
                Artikelen = new List<Entities.Artikel>(),
            };

            // Act
            var result = bestellingManager.ConvertBestellingEntityToDTO(bestelling);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Bestelling));
            Assert.AreEqual(1, result.BestellingID);
            Assert.AreEqual(datum.ToString(), result.FactuurDatum);
        }
    }
}
