using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Schema;
using Moq;
using Case3.BSBestellingenbeheer.Implementation.Tests.Mocks;
using System.Data.Entity.Validation;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    /// <summary>
    /// Testclass for testint the BestellingenManager
    /// </summary>
    [TestClass]
    public class BestellingenManagerTest
    {
        #region dummydata
        private Bestelling _bestellingValid = new Bestelling()
        {
            BestellingID = 1,
            FactuurDatum = new DateTime(2015, 12, 12).ToString(),
            FactuurID = 1,
            Status = 1,
            Klantgegevens = new Klantgegevens()
            {
                Naam = "Remco",
                Adresregel1 = "Hofmeesterij 89",
                Woonplaats = "Huissen",
                Postcode = "6852NC",
                Telefoonnummer = "0612697691"
            },
            Artikelen = new Artikelen()
                    {
                        new BestelItem()
                        {
                            Product = new BSCatalogusBeheer.Schema.ProductNS.Product()
                            {
                                Id = 1,
                                Naam = "Fietsbel",
                                LeverancierNaam = "Gazelle",
                                LeveranciersProductId = "GA01"
                            },
                            Aantal = 5
                        }
                    }
        };

        private Bestelling _bestellingInvalid = new Bestelling()
        {
           
            Klantgegevens = new Klantgegevens()
            {
            },
            Artikelen = new Artikelen()
                    {
                        new BestelItem()
                        {
                            Product = new BSCatalogusBeheer.Schema.ProductNS.Product()
                            {
                               
                            },
                            Aantal = 5
                        }
                    }
        };
        #endregion
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

        [TestMethod]
        public void InsertBestellingAddsProduct()
        {
            //Arrange
            var mock = new BestellingDataMapperMock();
            BestellingManager manager = new BestellingManager(mock);

            //Act
            int initialValue = mock.Count;
            manager.InsertBestelling(_bestellingValid);
            

            //Assert
            Assert.AreEqual(initialValue + 1, mock.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void InsertInvalidThrowsInvalidOperationException()
        {
            //Arrange
            var mock = new BestellingDataMapperMock();
            BestellingManager manager = new BestellingManager(mock);

            //Act
            int initialValue = mock.Count;
            manager.InsertBestelling(_bestellingInvalid);

            //Assert
            //Expect InvalidOperationException
        }
    }
}
