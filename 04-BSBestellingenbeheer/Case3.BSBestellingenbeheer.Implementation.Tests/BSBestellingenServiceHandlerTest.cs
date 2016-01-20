using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSBestellingenbeheer.V1.Messages;
using System.ServiceModel;
using Case3.Common.Faults;
using System.Linq;

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
            BTWPercentage = 19,
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

        private Bestelling _invalidBestelling = new Bestelling()
        {
            BestellingID = 1,
            FactuurDatum = new DateTime(2015, 12, 12).ToString(),
            Klantgegevens = new Klantgegevens()
            {
                Naam = "Remco",
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

        /// <summary>
        /// This integrationtest tests if a InsertBestellingResultMessage is returned if the product is added succesfully.
        /// </summary>
        [TestMethod]
        public void Integration_InsertBestellingReturnsReturnMessage()
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

        /// <summary>
        /// This method tests if the handler throws an FaultException<ErrorLijst> if the bestelling is invalid.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void Integration_InsertBestellingenThrowsFaultExceptionWhenRequestMessageIsInvalid()
        {
            //Arrange
            var handler = new BSBestellingenServiceHandler();

            //Act
            var result = handler.InsertBestelling(new InsertBestellingRequestMessage()
            {
                Bestelling = _invalidBestelling
            });

            //Assert
            //Expect FaultException<ErrorLijst>
        }

        /// <summary>
        /// This method verifies if the errormessage is as expected for an invalid bestelling.
        /// </summary>
        [TestMethod]
        public void Integration_ValidateErrorMessageOnWrongBestelling()
        {
            //Arrange
            var handler = new BSBestellingenServiceHandler();

            //Act
            try
            {
                var result = handler.InsertBestelling(new InsertBestellingRequestMessage()
                {
                    Bestelling = _invalidBestelling
                });
            }
            catch (FaultException<ErrorLijst> ex)
            {
                //Assert
                Assert.AreEqual("De opgegeven bestelling is niet in het juiste formaat.", ex.Detail.First().Message);
            }
        }

        /// <summary>
        /// This method verfies if the result is null if the Bestelling is null.
        /// </summary>
        [TestMethod]
        public void VerifyIfInsertBestellingReturnsNullWhenEntryIsNull()
        {
            //Arrange
            var handler = new BSBestellingenServiceHandler();

            //Act
            var result = handler.InsertBestelling(new InsertBestellingRequestMessage()
            {
                Bestelling = null
            });

            //Assert
            Assert.IsNull(result);
        }
    }
}
