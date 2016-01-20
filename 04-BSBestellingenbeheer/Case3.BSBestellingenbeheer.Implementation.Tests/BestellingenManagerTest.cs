using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Schema;
using Moq;
using Case3.BSBestellingenbeheer.Implementation.Tests.Mocks;
using System.Data.Entity.Validation;
using System.Collections.Generic;

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
                            Aantal = 5
                        }
                    }
        };

        private Bestelling _bestellingInvalidDatum = new Bestelling()
        {
            BestellingID = 45435,
            FactuurDatum = "202",
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
        public void Integration_InsertInvalidBestellingsThrowsException()
        {
            //Assert
            BestellingManager manager = new BestellingManager();

            //Act
            manager.InsertBestelling(_bestellingInvalid);

            //Arrange
            //Expect InvalidOperationException
        }

        [TestMethod]
        public void InvalidDateTimeInsertDoesNotThrowException()
        {
            //Assert
            BestellingManager manager = new BestellingManager();

            //Act
            manager.InsertBestelling(_bestellingInvalidDatum);

            //Arrange
        }


    }
}
