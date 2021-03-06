﻿using BSBestellingenNS = Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Implementation.Managers;
using PcSBestellenNS = Case3.PcSBestellen.V1.Messages;
using Case3.PcSBestellen.V1.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case3.PcSBestellen.Implementation.Tests.Managers
{
    /// <summary>
    /// Responsible for testing the BSBestellingManager Class
    /// </summary>
    [TestClass]
    public class BSBestellingenManagerTest
    {
        #region -------[Support functions for tests]-------
        private static BSBestellingenNS.FindFirstBestellingResultMessage CreateFindFirstBestellingResultMessage()
        {
            return new BSBestellingenNS.FindFirstBestellingResultMessage
            {
                BestellingOpdracht = new Bestelling
                {
                    Artikelen = new Artikelen
                    {
                        new BestelItem
                        {
                            Product = new Product
                            {
                                Naam = "Fietsbel",
                                LeverancierNaam = "Gazelle",
                                LeveranciersProductId = "GA12345FB",
                            },
                            Aantal = 1,
                        },
                        new BestelItem
                        {
                            Product = new Product
                            {
                                Naam = "Zadelpen",
                                LeverancierNaam = "Giant",
                                LeveranciersProductId = "GI12345ZP",
                            },
                            Aantal = 2,
                        },
                    },
                }
            };
        }
        private static PcSBestellenNS.FindNextBestellingRequestMessage CreateFindNextBestellingRequestMessage()
        {
            return new PcSBestellenNS.FindNextBestellingRequestMessage
            {
                //There is nothing to create at this time, but this method has already been made for possible additions
            };
        }
        #endregion
        #region -------[Tests for ConvertFindFirstResultMessageToFindNextResultMessage]-------
        [TestMethod]
        public void BSBestellingenManagerConvertsFindFirstResultMessageToFindNextResultMessage()
        {
            // Arrange
            var mock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);

            var manager = new BSBestellingenManager(mock.Object);
            var findFirstResultMessage = CreateFindFirstBestellingResultMessage();

            // Act
            PcSBestellenNS.FindNextBestellingResultMessage result = manager.ConvertFindFirstResultMessageToFindNextResultMessage(findFirstResultMessage);
            ArtikelenPcS artikelen = result.BestellingOpdracht.ArtikelenPcS;

            // Assert
            Assert.IsInstanceOfType(result, typeof(PcSBestellenNS.FindNextBestellingResultMessage));
            //First Item
            Assert.AreEqual("Fietsbel", artikelen[0].Product.Naam);
            Assert.AreEqual("Gazelle", artikelen[0].Product.LeverancierNaam);
            Assert.AreEqual("GA12345FB", artikelen[0].Product.LeveranciersProductId);
            Assert.AreEqual(1, artikelen[0].Aantal);
            //First Item
            Assert.AreEqual("Zadelpen", artikelen[1].Product.Naam);
            Assert.AreEqual("Giant", artikelen[1].Product.LeverancierNaam);
            Assert.AreEqual("GI12345ZP", artikelen[1].Product.LeveranciersProductId);
            Assert.AreEqual(2, artikelen[1].Aantal);
        }
        #endregion
        #region -------[Tests for ConvertFindNextRequestMessageToFindFirstRequestMessage]-------
        [TestMethod]
        public void BSBestellingenManagerConvertsFindNextRequestMessageToFindFirstRequestMessage()
        {
            // Arrange
            var mock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);

            var manager = new BSBestellingenManager(mock.Object);
            var findNextRequestMessage = CreateFindNextBestellingRequestMessage();

            // Act
            var result = manager.ConvertFindNextRequestMessageToFindFirstRequestMessage(findNextRequestMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BSBestellingenNS.FindFirstBestellingRequestMessage));
        }
        #endregion
        #region -------[Tests for FindNextBestelling]-------
        [TestMethod]
        public void BSBestellingenManagerFindsNextBestelling()
        {
            // Arrange
            var findNextRequestMessage = CreateFindNextBestellingRequestMessage();
            var findFirstResultMessage = CreateFindFirstBestellingResultMessage();
            var mock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            mock.Setup(m => m.FindFirstBestelling(It.IsAny<BSBestellingenNS.FindFirstBestellingRequestMessage>()))
                .Returns(findFirstResultMessage);

            var manager = new BSBestellingenManager(mock.Object);

            // Act
            var result = manager.FindNextBestelling(findNextRequestMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PcSBestellenNS.FindNextBestellingResultMessage));
        }
        #endregion
        #region -------[Tests for ConvertPcSUpdateRequestMessageToBSUpdateRequestMessage]-------
        [TestMethod]
        public void BSBestellingenManagerConvertsPcSUpdateRequestMessageToBSUpdateRequestMessage()
        {
            // Arrange
            var mock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);

            var manager = new BSBestellingenManager(mock.Object);
            var pcsUpdateRequestMessage = new V1.Messages.UpdateBestellingStatusRequestMessage { BestellingID = 1};

            // Act
            var result = manager.ConvertPcSUpdateRequestMessageToBSUpdateRequestMessage(pcsUpdateRequestMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusRequestMessage));
        }
        #endregion
        #region -------[Tests for ConvertBsUpdateResultMessageToPcSUpdateResultMessage]-------
        [TestMethod]
        public void BSBestellingenManagerConvertsBsUpdateResultMessageToPcSUpdateResultMessage()
        {
            // Arrange
            var mock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);

            var manager = new BSBestellingenManager(mock.Object);
            var bsUpdateResultMessage = new BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusResultMessage();

            // Act
            var result = manager.ConvertBsUpdateResultMessageToPcSUpdateResultMessage(bsUpdateResultMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(V1.Messages.UpdateBestellingStatusResultMessage));
        }
        #endregion
        #region -------[Tests for UpdateBestelling]-------
        [TestMethod]
        public void BSBestellingenManagerUpdatesBestelling()
        {
            // Arrange
            var mock = new Mock<IBSBestellingenbeheerAgent>(MockBehavior.Strict);
            mock.Setup(m => m.UpdateBestellingStatus(It.IsAny<BSBestellingenNS.UpdateBestellingStatusRequestMessage>()))
                .Returns(new BSBestellingenNS.UpdateBestellingStatusResultMessage());

            var manager = new BSBestellingenManager(mock.Object);
            var pcsUpdateRequestMessage = new V1.Messages.UpdateBestellingStatusRequestMessage { BestellingID = 1 }; ;

            // Act
            var result = manager.UpdateBestelling(pcsUpdateRequestMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(V1.Messages.UpdateBestellingStatusResultMessage));
        }
        #endregion
    }
}
