using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Case3.PcSBestellen.MessagesNS;
using Case3.PcSBestellen.SchemaNS;
using Case3.PcSWinkelen.Agent.Agents;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case3.PcSWinkelen.Agent.Tests.Agents
{
    [TestClass]
    public class PcSBestellenAgentTest
    {
        [TestMethod]
        public void BestellingPlaatsenCallsCorrectMethods()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Returns(new BestellingPlaatsenResultMessage());
            var agent = new PcSBestellenAgent(agentMock.Object, null);

            //Act
            agent.BestellingPlaatsen(new BestellingPcS());

            //Assert
            agentMock.Verify(pcsMock => pcsMock.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>()), Times.Once);
        }

        [TestMethod]
        public void BestellingPlaatsenReturnsCorrectData()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Returns(new BestellingPlaatsenResultMessage());
            var agent = new PcSBestellenAgent(agentMock.Object, null);

            //Act
            var result = agent.BestellingPlaatsen(new BestellingPcS());

            //Assert
            Assert.AreEqual(true, result);
        }


        [ExpectedException(typeof(TechnicalException))]
        [TestMethod]
        public void BestellingPlaatsenBestellingNullThrowsExc()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Throws(new FaultException("Something went wrong"));

            var logMock = new Mock<ILog>(MockBehavior.Strict);
            logMock.Setup(log => log.Error(It.IsAny<string>()));

            var agent = new PcSBestellenAgent(agentMock.Object, logMock.Object);

            //Act
            try
            {
                agent.BestellingPlaatsen(null);
            }
            catch (TechnicalException ex)
            {
                //Assert
                Assert.AreEqual("Bestelling mag niet null zijn", ex.Message);
                throw;
            }
            
            //Assert
            //Error thrown
        }


        [ExpectedException(typeof(TechnicalException))]
        [TestMethod]
        public void BestellingPlaatsenThrowsError()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Throws(new FaultException("Something went wrong"));

            var logMock = new Mock<ILog>(MockBehavior.Strict);
            logMock.Setup(log => log.Fatal(It.IsAny<string>(), It.IsAny<Exception>()));

            var agent = new PcSBestellenAgent(agentMock.Object, logMock.Object);

            //Act
            try
            {
                agent.BestellingPlaatsen(new BestellingPcS());
            }
            catch (TechnicalException ex)
            {
                Assert.AreEqual("Er is iets misgegaan met het versturen van de bestelling", ex.Message);
                Assert.AreEqual("Something went wrong", ex.InnerException.Message);
                throw;
            }
            

            //Assert
            //Exception thrown
        }

        [TestMethod]
        public void BestellingPlaatsenBestellingNullThrowsExcCallsLog()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Throws(new FaultException("Something went wrong"));

            var logMock = new Mock<ILog>(MockBehavior.Strict);
            logMock.Setup(log => log.Error(It.IsAny<string>()));

            var agent = new PcSBestellenAgent(agentMock.Object, logMock.Object);

            //Act
            try
            {
                agent.BestellingPlaatsen(null);
            }
            catch (TechnicalException)
            {
                //Assert
                logMock.Verify(log => log.Error(It.IsAny<string>()), Times.Once);
            }
        }

        [TestMethod]
        public void BestellingPlaatsenThrowsFaultExcCallsLog()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Throws(new FaultException("Something went wrong"));

            var logMock = new Mock<ILog>(MockBehavior.Strict);
            logMock.Setup(log => log.Fatal(It.IsAny<string>(), It.IsAny<Exception>()));

            var agent = new PcSBestellenAgent(agentMock.Object, logMock.Object);

            //Act
            try
            {
                agent.BestellingPlaatsen(new BestellingPcS());
            }
            catch (TechnicalException)
            {
                //Assert
                logMock.Verify(log => log.Fatal(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
            }
        }

        [TestMethod]
        public async void BestellingPlaatsenAsyncCallsCorrectMethods()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsenAsync(It.IsAny<BestellingPlaatsenRequestMessage>()))
                .Returns(Task.FromResult(new BestellingPlaatsenResultMessage()));
            var agent = new PcSBestellenAgent(agentMock.Object, null);

            //Act
            await agent.BestellingPlaatsenAsync(new BestellingPcS());
            
            //Assert
            agentMock.Verify(pcsMock => pcsMock.BestellingPlaatsenAsync(It.IsAny<BestellingPlaatsenRequestMessage>()), Times.Once);

        }

        [TestMethod]
        public async void BestellingPlaatsenAsyncReturnsCorrectData()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Returns(new BestellingPlaatsenResultMessage());
            var agent = new PcSBestellenAgent(agentMock.Object, null);

            //Act
            var result = await agent.BestellingPlaatsenAsync(new BestellingPcS());

            //Assert
            Assert.AreEqual(true, result);
        }


        [ExpectedException(typeof(TechnicalException))]
        [TestMethod]
        public async void BestellingPlaatsenAsyncBestellingNullThrowsExc()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsenAsync(It.IsAny<BestellingPlaatsenRequestMessage>())).Throws(new FaultException("Something went wrong"));

            var logMock = new Mock<ILog>(MockBehavior.Strict);
            logMock.Setup(log => log.Error(It.IsAny<string>()));

            var agent = new PcSBestellenAgent(agentMock.Object, logMock.Object);

            //Act
            try
            {
                await agent.BestellingPlaatsenAsync(null);
            }
            catch (TechnicalException ex)
            {
                //Assert
                Assert.AreEqual("Bestelling mag niet null zijn", ex.Message);
                throw;
            }

            //Assert
            //Error thrown
        }


        [TestMethod]
        public void BestellingPlaatsenAsyncBestellingNullThrowsExcCallsLog()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Throws(new FaultException("Something went wrong"));

            var logMock = new Mock<ILog>(MockBehavior.Strict);
            logMock.Setup(log => log.Error(It.IsAny<string>()));

            var agent = new PcSBestellenAgent(agentMock.Object, logMock.Object);

            //Act
            try
            {
                var result = agent.BestellingPlaatsenAsync(null);
            }
            catch (TechnicalException)
            {
                //Assert
                logMock.Verify(log => log.Error(It.IsAny<string>()), Times.Once);
            }
        }

        [TestMethod]
        public void BestellingPlaatsenAsyncThrowsFaultExcCallsLog()
        {
            //Arrange
            var agentMock = new Mock<IPcSBestellenService>(MockBehavior.Strict);
            agentMock.Setup(pcs => pcs.BestellingPlaatsen(It.IsAny<BestellingPlaatsenRequestMessage>())).Throws(new FaultException("Something went wrong"));

            var logMock = new Mock<ILog>(MockBehavior.Strict);
            logMock.Setup(log => log.Fatal(It.IsAny<string>(), It.IsAny<Exception>()));

            var agent = new PcSBestellenAgent(agentMock.Object, logMock.Object);

            //Act
            try
            {
                var result = agent.BestellingPlaatsenAsync(new BestellingPcS());
            }
            catch (TechnicalException)
            {
                //Assert
                logMock.Verify(log => log.Fatal(It.IsAny<string>(), It.IsAny<Exception>()), Times.Once);
            }
        }
    }
}
