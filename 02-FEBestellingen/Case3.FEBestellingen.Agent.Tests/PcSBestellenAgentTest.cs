using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Case3.PcSBestellen.V1.Messages;
using Case3.BSCatalogusBeheer.Schema.ProductNSPcS;
using Case3.FEBestellingen.Agent.Agents;
using case3pcsbestellen.v1.schema;

namespace Case3.FEBestellingen.Agent.Tests
{
    [TestClass]
    public class PcSBestellenAgentTest
    {
        #region -------[Support functions for tests]-------
        private static FindNextBestellingResultMessage CreateFindNextBestellingResultMessage()
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
                                LeverancierNaam = "Gazelle",
                                Naam = "Fietsbel",
                                LeveranciersProductId = "GA12345FB"
                            },
                            Aantal = 1
                        },
                        new BestelItemPcS
                        {
                            Product = new Product
                            {
                                LeverancierNaam = "Giant",
                                Naam = "Zadelpen",
                                LeveranciersProductId = "GI12345ZP"
                            },
                            Aantal = 2
                        }
                    }
                }
            };
        }
        #endregion
        #region -------[Tests for FindNextBestelling]-------
        [TestMethod]
        public void PcSBestellenAgentReturnsBestelling()
        {
            FindNextBestellingResultMessage resultMessage = CreateFindNextBestellingResultMessage();
            var mock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            mock.Setup(m => m.FindNextBestelling(It.IsAny<FindNextBestellingRequestMessage>()))
                .Returns(resultMessage);
            var agent = new PcSBestellenAgent(mock.Object);

            // Act
            var result = agent.FindNextBestelling(new FindNextBestellingRequestMessage());

            // Assert
            Assert.IsInstanceOfType(result, typeof(BestellingPcS));
        }
        #endregion
    }
}
