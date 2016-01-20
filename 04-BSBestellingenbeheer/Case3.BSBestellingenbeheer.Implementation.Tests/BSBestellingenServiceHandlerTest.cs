using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSBestellingenbeheer.V1.Messages;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    /// <summary>
    /// Testclass for testing the BSBestellingenServiceHandler class
    /// </summary>
    [TestClass]
    public class BSBestellingenServiceHandlerTest
    {
        #region dummydata
        private Bestelling _bestelling = new Bestelling()
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
                                Naam = "Fietsbel"
                            },
                            Aantal = 5
                        }
                    }
        };
        #endregion

        /// <summary>
        /// Test to check if instantiating a BSBestellingenServiceHandler works correctly
        /// </summary>
        [TestMethod]
        public void BSBestellingenServiceHandlerCreateInstance()
        {
            // Arrange

            // Act
            var bSBestellingenServiceHandler = new BSBestellingenServiceHandler();

            // Assert
            Assert.IsNotNull(bSBestellingenServiceHandler);
            Assert.IsInstanceOfType(bSBestellingenServiceHandler, typeof(BSBestellingenServiceHandler));
        }

        [TestMethod]
        public void InsertBestellingReturnsReturnMessage()
        {
            //Arrange
            var handler = new BSBestellingenServiceHandler();

            //Act
            var result = handler.InsertBestelling(new InsertBestellingRequestMessage()
            {
                Bestelling = _bestelling
            });

            //Assert
            Assert.IsInstanceOfType(result, typeof(InsertBestellingResultMessage));
        }
    }
}
