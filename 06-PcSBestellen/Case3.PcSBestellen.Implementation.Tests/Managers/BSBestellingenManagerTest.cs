using System;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Implementation.Managers;
using Case3.PcSBestellen.V1.Messages;
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
        private FindFirstBestellingResultMessage CreateFindFirstBestellingResultMessage()
        {
            return new FindFirstBestellingResultMessage
            {
                BestellingOpdracht = new Bestelling
                {
                    Artikelen = new Artikelen(),// TODO nog aanvullen met gegevens en deze Asserten
                }
            };
        }
        private FindNextBestellingRequestMessage CreateFindNextBestellingRequestMessage()
        {
            return new FindNextBestellingRequestMessage
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
            var mock = new Mock<IBsBestellingenbeheerAgent>(MockBehavior.Strict);

            var manager = new BSBestellingenManager(mock.Object);
            var findFirstResultMessage = CreateFindFirstBestellingResultMessage();

            // Act
            var result = manager.ConvertFindFirstResultMessageToFindNextResultMessage(findFirstResultMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(FindNextBestellingResultMessage));
        }
        #endregion
        #region -------[Tests for ConvertFindNextRequestMessageToFindFirstRequestMessage]-------
        [TestMethod]
        public void BSBestellingenManagerConvertsFindNextRequestMessageToFindFirstRequestMessage()
        {
            // Arrange
            var mock = new Mock<IBsBestellingenbeheerAgent>(MockBehavior.Strict);

            var manager = new BSBestellingenManager(mock.Object);
            var findNextRequestMessage = CreateFindNextBestellingRequestMessage();

            // Act
            var result = manager.ConvertFindNextRequestMessageToFindFirstRequestMessage(findNextRequestMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(FindFirstBestellingRequestMessage));
        }
        #endregion
        #region -------[Tests for FindNextBestelling]-------
        [TestMethod]
        public void BSBestellingenManagerFindsNextBestelling()
        {
            // Arrange
            var findNextRequestMessage = CreateFindNextBestellingRequestMessage();
            var findFirstResultMessage = CreateFindFirstBestellingResultMessage();
            var mock = new Mock<IBsBestellingenbeheerAgent>(MockBehavior.Strict);
            mock.Setup(m => m.FindFirstBestelling(It.IsAny<FindFirstBestellingRequestMessage>()))
                .Returns(findFirstResultMessage);

            var manager = new BSBestellingenManager(mock.Object);

            // Act
            var result = manager.FindNextBestelling(findNextRequestMessage);

            // Assert
            Assert.IsInstanceOfType(result, typeof(FindNextBestellingResultMessage));
        }
        #endregion
    }
}
