using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEWebwinkel.Agent.Tests.Mocks;
using Case3.FEWebwinkel.Agent.Exceptions;
using Moq;
using Case3.PcSWinkelen.Messages;
using case3common.v1.faults;
using System.ServiceModel;
using case3bsbestellingenbeheer.v1.schema;

namespace Case3.FEWebwinkel.Agent.Tests.Agents
{
    [TestClass]
    public class PcSWinkelenAgentTest
    {

        private ErrorLijst _errorList = new ErrorLijst()
            {
                new ErrorDetail()
                {
                    ErrorCode = 404,
                    Message = "Er is een fout opgetreden in PcSWinkelen.",
                }
            };

        [TestMethod]
        public void VerifyGetProductsReturnsCorrectAmountOfProducts()
        {
            //Arrange
            PcSWinkelenAgentMock mock = new PcSWinkelenAgentMock();
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock);

            //Act
            var result = agent.GetProducts(1, 2); //Get 2 products

            //Assert
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void VerifyGetProductsReturnsAll80MockedProducts()
        {
            //Arrange
            PcSWinkelenAgentMock mock = new PcSWinkelenAgentMock();
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock);

            //Act
            var result = agent.GetProducts(); //Get all products

            //Assert
            Assert.AreEqual(80, result.Count);
        }

        [TestMethod]
        public void VerifyGetWinkelmandReturnsMockedData()
        {
            //Arrange
            PcSWinkelenAgentMock mock = new PcSWinkelenAgentMock();
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock);

            //Act
            var result = agent.GetWinkelmand("test");//Gets the Winkelmand

            //Assert
            Assert.AreEqual(2, result.Count);
            //First Viewmodel
            Assert.AreEqual(1, result[0].Product.Id);
            Assert.AreEqual("Fietsbel", result[0].Product.Naam);
            Assert.AreEqual(4.95M, result[0].Product.Prijs);
            Assert.AreEqual(2, result[0].Aantal);
            //Second Viewmodel
            Assert.AreEqual(2, result[1].Product.Id);
            Assert.AreEqual("Zadelpen", result[1].Product.Naam);
            Assert.AreEqual(12.50M, result[1].Product.Prijs);
            Assert.AreEqual(1, result[1].Aantal);
        }

        [TestMethod]
        public void VerifyAddProductToWinkelmandReturnsTrue()
        {
            //Arrange
            PcSWinkelenAgentMock mock = new PcSWinkelenAgentMock();
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock);

            //Act
            var result = agent.AddProductToWinkelmand(1, "test");//adds a product to the Winkelmand

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyAddProductToWinkelmandReturnsFalseWhenSessionIsNull()
        {
            //Arrange
            PcSWinkelenAgentMock mock = new PcSWinkelenAgentMock();
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock);

            //Act
            var result = agent.AddProductToWinkelmand(1, null);//adds a product to the Winkelmand

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(TechnicalException))]
        public void VerifyGetProductsThrowsTechnicalExceptionWhenFaultException()
        {
            //Arrange
            var mock = new Mock<IPcSWinkelenService>(MockBehavior.Strict);
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock.Object);
            mock.Setup(p => p.GetCatalogusItems(It.IsAny<FindCatalogusRequestMessage>())).Throws(new FaultException<ErrorLijst>(_errorList));

            //Act
            var result = agent.GetProducts();

            //Assert
            //Expect TechnicalException
        }

        [TestMethod]
        [ExpectedException(typeof(TechnicalException))]
        public void VerifyGetProductsThrowsTechnicalExceptionWhenException()
        {
            //Arrange
            var mock = new Mock<IPcSWinkelenService>(MockBehavior.Strict);
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock.Object);
            mock.Setup(p => p.GetCatalogusItems(It.IsAny<FindCatalogusRequestMessage>())).Throws(new Exception());

            //Act
            var result = agent.GetProducts();

            //Assert
            //Expect TechnicalException
        }

        [TestMethod]
        [ExpectedException(typeof(TechnicalException))]
        public void VerifyGetProductsWithInputThrowsTechnicalExceptionWhenFaultException()
        {
            //Arrange
            var mock = new Mock<IPcSWinkelenService>(MockBehavior.Strict);
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock.Object);
            mock.Setup(p => p.GetCatalogusItems(It.IsAny<FindCatalogusRequestMessage>())).Throws(new FaultException<ErrorLijst>(_errorList));

            //Act
            var result = agent.GetProducts(3, 3);

            //Assert
            //Expect TechnicalException
        }

        [TestMethod]
        [ExpectedException(typeof(TechnicalException))]
        public void VerifyGetProductsWithInputThrowsTechnicalExceptionWhenException()
        {
            //Arrange
            var mock = new Mock<IPcSWinkelenService>(MockBehavior.Strict);
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock.Object);
            mock.Setup(p => p.GetCatalogusItems(It.IsAny<FindCatalogusRequestMessage>())).Throws(new Exception());

            //Act
            var result = agent.GetProducts(3, 3);

            //Assert
            //Expect TechnicalException
        }

        [TestMethod]
        public void AgentCallsServiceToSendBestelling()
        {
            //Arrange
            var mock = new Mock<IPcSWinkelenService>(MockBehavior.Strict);
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock.Object);
            mock.Setup(p => p.WinkelmandBestellen(It.IsAny<WinkelmandBestellenRequestMessage>()))
                .Returns(It.IsAny<WinkelmandBestellenResponseMessage>());

            //Act
            agent.SendBestelling("test", It.IsAny<Klantgegevens>(), It.IsAny<int>());

            //Assert
            //Expect TechnicalException
            mock.Verify(x => x.WinkelmandBestellen(It.IsAny<WinkelmandBestellenRequestMessage>()), Times.Once());
        }
    }
}
