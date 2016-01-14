using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Moq;
using Case3.PcSBestellen.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;

namespace Case3.PcSBestellen.Implementation.Tests.Handlers
{
    /// <summary>
    /// Responsible for testing the PcSBestellenServiceHandler Class
    /// </summary>
    [TestClass]
    public class PcSBestellenServiceHandlerTest
    {
        #region -------[Support functions for tests]-------
        private FindNextBestellingResultMessage CreateFindNextBestellingResultMessage()
        {
            return new FindNextBestellingResultMessage
            {
                BestellingOpdracht = new Bestelling
                {
                    Artikelen = null, // TODO nog aanvullen met gegevens en deze Asserten
                }
            };
        }
        #endregion
        #region -------[Tests for FindNextBestelling]-------
        [TestMethod]
        public void PcSBestellenServiceHandlerFindsNextBestellingReturnsNextResultMessage()
        {
            // Arrange
            var findNextResultMessage = CreateFindNextBestellingResultMessage();
            var mock = new Mock<IBSBestellingenManager>(MockBehavior.Strict);

            mock.Setup(m => m.FindNextBestelling(It.IsAny<FindNextBestellingRequestMessage>()))
                .Returns(findNextResultMessage);

            var handler = new PcSBestellenServiceHandler(mock.Object);

            // Act
            var result = handler.FindNextBestelling(new FindNextBestellingRequestMessage());

            // Assert
            Assert.IsInstanceOfType(result, typeof(FindNextBestellingResultMessage));
        }
        [TestMethod]
        public void PcSBestellenServiceHandlerFindsNextBestellingReturnsCorrectResultMessage()
        {
            // Arrange
            var findNextResultMessage = CreateFindNextBestellingResultMessage();
            var mock = new Mock<IBSBestellingenManager>(MockBehavior.Strict);

            mock.Setup(m => m.FindNextBestelling(It.IsAny<FindNextBestellingRequestMessage>()))
                .Returns(findNextResultMessage);

            var handler = new PcSBestellenServiceHandler(mock.Object);

            // Act
            var result = handler.FindNextBestelling(new FindNextBestellingRequestMessage());

            // Assert
            Assert.Fail();
        }
        #endregion
    }
}
