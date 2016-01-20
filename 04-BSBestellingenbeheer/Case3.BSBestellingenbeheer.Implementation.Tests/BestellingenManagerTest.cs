using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Schema;
using Moq;
using Case3.BSBestellingenbeheer.Implementation.Tests.Mocks;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using Case3.BSBestellingenbeheer.DAL.Exceptions;

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
            BTWPercentage = 21,
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
            BTWPercentage = 7,
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
                Artikelen = generateArtikelList(),
            };

            // Act
            var result = bestellingManager.ConvertBestellingEntityToDTO(bestelling);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Bestelling));
            Assert.AreEqual(1, result.BestellingID);
            Assert.AreEqual(datum.ToString(), result.FactuurDatum);
        }

        /// <summary>
        /// This method tests the result is null, if the input is null.
        /// </summary>
        [TestMethod]
        public void BestellingenManageConvertBestellingIsNull()
        {
            // Arrange
            BestellingManager bestellingManager = new BestellingManager();
            
            // Act
            var result = bestellingManager.ConvertBestellingEntityToDTO(null);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// This method tests if the count increments if an valid products is inserted.
        /// </summary>
        [TestMethod]
        public void InsertBestellingIncrementsCount()
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

        /// <summary>
        /// This integration test tests if inserting an invalid Bestelling throws an FunctionalException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FunctionalException))]
        public void Integration_InsertInvalidBestellingsThrowsException()
        {
            //Assert
            BestellingManager manager = new BestellingManager();

            //Act
            manager.InsertBestelling(_bestellingInvalid);

            //Arrange
            //Expect FunctionalException
        }

        /// <summary>
        /// This method verifies a product is added succesfully, even if the datetime is in bad format.
        /// </summary>
        [TestMethod]
        public void InvalidDateTimeInsertsNewBestellingOnWrongDateTimeInput()
        {
            //Assert
            var mock = new BestellingDataMapperMock();
            BestellingManager manager = new BestellingManager(mock);

            //Act
            int initialValue = mock.Count;
            manager.InsertBestelling(_bestellingInvalidDatum);

            //Arrange
            Assert.AreEqual(initialValue + 1, mock.Count);
        }

        private List<Entities.Artikel> generateArtikelList()
        {
            List<Entities.Artikel> lijst = new List<Entities.Artikel>();

            Entities.Artikel artikel21 = new Entities.Artikel()
            {
                ID = 21,
                Naam = "fietsbel",
                Leverancier = "gazelle",
                Leverancierscode = "03g54hbronlsfads",
                Aantal = 3
            };

            Entities.Artikel artikel22 = new Entities.Artikel()
            {
                ID = 22,
                Naam = "remschijf",
                Leverancier = "gazelle",
                Leverancierscode = "oiaernglggafds234",
                Aantal = 3
            };

            Entities.Artikel artikel23 = new Entities.Artikel()
            {
                ID = 23,
                Naam = "kantilever",
                Leverancier = "gazelle",
                Leverancierscode = "kvbaf9345245sda",
                Aantal = 3
            };


            Entities.Artikel artikel24 = new Entities.Artikel()
            {
                ID = 24,
                Naam = "zadel",
                Leverancier = "gazelle",
                Leverancierscode = "vbsdaijgbreq6542",
                Aantal = 3
            };

            lijst.Add(artikel21);
            lijst.Add(artikel22);
            lijst.Add(artikel23);
            lijst.Add(artikel24);

            return lijst;
        }

    }
}
