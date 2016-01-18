using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Case3.PcSBestellen.V1.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
                BestellingOpdracht = new BestellingPcS
                {
                    ArtikelenPcS = new ArtikelenPcS
                    {
                        new BestelItemPcS
                        {
                            Product = new Product
                            {
                                Naam = "Fietsbel",
                                LeverancierNaam = "Gazelle",
                                LeveranciersProductId = "GA12345FB",
                            },
                            Aantal = 1,
                        },
                        new BestelItemPcS
                        {
                            Product = new Product
                            {
                                Naam = "Zadelpen",
                                LeverancierNaam = "Giant",
                                LeveranciersProductId = "GI12345ZP",
                            },
                            Aantal = 2,
                        },
                    }
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
            var artikelen = result.BestellingOpdracht.ArtikelenPcS;

            // Assert
            Assert.IsInstanceOfType(result, typeof(FindNextBestellingResultMessage));
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
    }
}
