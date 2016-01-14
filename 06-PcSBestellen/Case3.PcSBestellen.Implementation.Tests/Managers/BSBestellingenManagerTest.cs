using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Implementation.Managers;
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
                    Artikelen = new BSBestellingenbeheer.V1.Schema.Artikelen { }
                }
            };
        }
        #endregion
        #region -------[Tests for ConvertsFindFirstResultMessageToFindNextResultMessage]-------
        [TestMethod]
        public void BSBestellingenManagerConvertsFindFirstResultMessageToFindNextResultMessage()
        {
            // Arrange
            var mock = new Mock<IBsBestellingenbeheerAgent>(MockBehavior.Strict);

            var manager = new BSBestellingenManager(mock.Object);
            // Act
            manager.ConvertFindFirstResultMessageToFindNextResultMessage()
            // Assert
        }
        #endregion
    }
}
