using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.PcSBestellen.Agent.Agents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case3.PcSBestellen.Agent.Tests.Agents
{
    [TestClass]
    public class BsBestellingenbeheerAgentTest
    {
        #region -------[Support functions for tests]-------
        private FindFirstBestellingResultMessage CreateFindFirstBestellingResultMessage()
        {
            return new FindFirstBestellingResultMessage
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
        #endregion
        #region -------[Tests for FindNextBestelling]-------
        [TestMethod]
        public void PcSBestellenAgentFindsFirstBestelling()
        {
            //Arrange
            var resultMessage = CreateFindFirstBestellingResultMessage();

            var mock = new Mock<IBSBestellingenbeheerService>(MockBehavior.Strict);
            mock.Setup(m => m.FindFirstBestelling(It.IsAny<FindFirstBestellingRequestMessage>()))
                .Returns(resultMessage);

            var agent = new BsBestellingenbeheerAgent(mock.Object);

            //Act
            var result = agent.FindFirstBestelling(new FindFirstBestellingRequestMessage());
            var artikelen = result.BestellingOpdracht.Artikelen;
            //Assert
            Assert.IsInstanceOfType(result, typeof(FindFirstBestellingResultMessage));
        }

        [TestMethod]
        public void PcSBestellenAgentFindsCorrectFirstBestelling()
        {
            //Arrange
            var resultMessage = CreateFindFirstBestellingResultMessage();

            var mock = new Mock<IBSBestellingenbeheerService>(MockBehavior.Strict);
            mock.Setup(m => m.FindFirstBestelling(It.IsAny<FindFirstBestellingRequestMessage>()))
                .Returns(resultMessage);

            var agent = new BsBestellingenbeheerAgent(mock.Object);

            //Act
            var result = agent.FindFirstBestelling(new FindFirstBestellingRequestMessage());
            var artikelen = result.BestellingOpdracht.Artikelen;
            //Assert
            Assert.IsInstanceOfType(result, typeof(FindFirstBestellingResultMessage));
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
        #region -------[Tests for UpdateBestellingStatus]-------
        [TestMethod]
        public void PcSBestellenAgentUpdatesBestelling()
        {
            //Arrange
            var mock = new Mock<IBSBestellingenbeheerService>(MockBehavior.Strict);
            mock.Setup(m => m.UpdateBestellingStatus(It.IsAny<UpdateBestellingStatusRequestMessage>()))
                .Returns(new UpdateBestellingStatusResultMessage());

            var agent = new BsBestellingenbeheerAgent(mock.Object);

            //Act
            var result = agent.UpdateBestellingStatus(new UpdateBestellingStatusRequestMessage());
            //Assert
            Assert.IsInstanceOfType(result, typeof(UpdateBestellingStatusResultMessage));
        }
        #endregion
    }
}
