using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSBestellingenbeheer.V1.Messages;
using System.ServiceModel;
using Case3.Common.Faults;
using System.Linq;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using System.Collections.Generic;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.DAL.Exceptions;

namespace Case3.BSBestellingenbeheer.Implementation.Tests
{
    /// <summary>
    /// Testclass for testing the BSBestellingenServiceHandler class
    /// </summary>
    [TestClass]
    public class BSBestellingenServiceHandlerTest
    {
        private readonly DummyData _dummyData = new DummyData();
        
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
                Bestelling = _dummyData.Bestelling
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
                Bestelling = _dummyData.InvalidBestelling
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
                    Bestelling = _dummyData.InvalidBestelling
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
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
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
            //Expect FaultException<ErrorLijst>
        }

        [TestMethod]
        public void TestFindFirstBestellingImplementation()
        {
            //Arrange
            _dummyData.BestellingEntity.Artikelen = generateArtikelList();

            var mapperMock = new Mock<BestellingDataMapper>(MockBehavior.Strict);
            mapperMock.Setup(m => m.GetBestellingToPack()).Returns(_dummyData.BestellingEntity);

            var managerMock = new Mock<BestellingManager>(MockBehavior.Strict);
            managerMock.Setup(m => m.ConvertBestellingEntityToDTO(It.IsAny<Entities.Bestelling>())).Returns(new Bestelling());


            var handler = new BSBestellingenServiceHandler(mapperMock.Object, managerMock.Object);

            //Act
            var result = handler.FindFirstBestelling(new FindFirstBestellingRequestMessage());

            //Assert
            Assert.IsInstanceOfType(result, typeof(FindFirstBestellingResultMessage));
        }

        [TestMethod]
        public void TestUpdateBestellingStatusImplementation()
        {
            //Arrange

            var mapperMock = new Mock<BestellingDataMapper>(MockBehavior.Strict);
            mapperMock.Setup(m => m.UpdateBestellingStatusToPacked(It.IsAny<long>()));

            var handler = new BSBestellingenServiceHandler(mapperMock.Object);

            //Act
            var result = handler.UpdateBestellingStatus(new UpdateBestellingStatusRequestMessage());

            //Assert
            Assert.IsInstanceOfType(result, typeof(UpdateBestellingStatusResultMessage));
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void TestUpdateBestellingStatusRequestIsNullImplementation()
        {
            //Arrange

            var mapperMock = new Mock<BestellingDataMapper>(MockBehavior.Strict);
            mapperMock.Setup(m => m.UpdateBestellingStatusToPacked(It.IsAny<long>()));

            var handler = new BSBestellingenServiceHandler(mapperMock.Object);

            //Act
            var result = handler.UpdateBestellingStatus(null);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void TestUpdateBestellingStatusImplementationThrowsTechnicalException()
        {
            //Arrange

            var mapperMock = new Mock<BestellingDataMapper>(MockBehavior.Strict);
            mapperMock.Setup(m => m.UpdateBestellingStatusToPacked(It.IsAny<long>())).Throws(new TechnicalException());

            var handler = new BSBestellingenServiceHandler(mapperMock.Object);

            //Act
            var result = handler.UpdateBestellingStatus(new UpdateBestellingStatusRequestMessage());
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void TestUpdateBestellingStatusImplementationThrowsFunctionalException()
        {
            //Arrange

            var mapperMock = new Mock<BestellingDataMapper>(MockBehavior.Strict);
            mapperMock.Setup(m => m.UpdateBestellingStatusToPacked(It.IsAny<long>())).Throws(new FunctionalException());

            var handler = new BSBestellingenServiceHandler(mapperMock.Object);

            //Act
            var result = handler.UpdateBestellingStatus(new UpdateBestellingStatusRequestMessage());
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void TestUpdateBestellingStatusImplementationThrowsException()
        {
            //Arrange

            var mapperMock = new Mock<BestellingDataMapper>(MockBehavior.Strict);
            mapperMock.Setup(m => m.UpdateBestellingStatusToPacked(It.IsAny<long>())).Throws(new Exception());

            var handler = new BSBestellingenServiceHandler(mapperMock.Object);

            //Act
            var result = handler.UpdateBestellingStatus(new UpdateBestellingStatusRequestMessage());
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

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void VerifyInsertBestellingThrowsFaultExceptionWhenTechnicalExceptionOccurs()
        {
            //Arrange
            var mock = new Mock<IBestellingManager>(MockBehavior.Strict);
            mock.Setup(p => p.InsertBestelling(It.IsAny<Bestelling>())).Throws(new TechnicalException());
            var handler = new BSBestellingenServiceHandler(null, mock.Object);

            var request = new InsertBestellingRequestMessage() { Bestelling = new Bestelling() };

            //Act
            handler.InsertBestelling(request);

            //Act
            //Expect FaultException<ErrorLijst>
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void VerifyInsertBestellingThrowsFaultExceptionWhenFunctionalExceptionOccurs()
        {
            //Arrange
            var mock = new Mock<IBestellingManager>(MockBehavior.Strict);
            mock.Setup(p => p.InsertBestelling(It.IsAny<Bestelling>())).Throws(new FunctionalException());
            var handler = new BSBestellingenServiceHandler(null, mock.Object);

            var request = new InsertBestellingRequestMessage() { Bestelling = new Bestelling() };

            //Act
            handler.InsertBestelling(request);

            //Act
            //Expect FaultException<ErrorLijst>
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void VerifyInsertBestellingThrowsFaultExceptionWhenExceptionOccurs()
        {
            //Arrange
            var mock = new Mock<IBestellingManager>(MockBehavior.Strict);
            mock.Setup(p => p.InsertBestelling(It.IsAny<Bestelling>())).Throws(new Exception());
            var handler = new BSBestellingenServiceHandler(null, mock.Object);

            var request = new InsertBestellingRequestMessage() { Bestelling = new Bestelling() };

            //Act
            handler.InsertBestelling(request);

            //Act
            //Expect FaultException<ErrorLijst>
        }
    }
}
