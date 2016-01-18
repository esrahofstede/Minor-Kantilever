using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.FEWebwinkel.Agent.Tests.Mocks;

namespace Case3.FEWebwinkel.Agent.Tests.Agents
{
    [TestClass]
    public class PcSWinkelenAgentTest
    {
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
    }
}
