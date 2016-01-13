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
            //Assert
            PcSWinkelenAgentMock mock = new PcSWinkelenAgentMock();
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock);

            //Act
            var result = agent.GetProducts(1, 2); //Get 2 products

            //Arrange
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void VerifyGetProcutsReturnsAll80MockedProducts()
        {
            //Assert
            PcSWinkelenAgentMock mock = new PcSWinkelenAgentMock();
            PcSWinkelenAgent agent = new PcSWinkelenAgent(mock);

            //Act
            var result = agent.GetProducts(); //Get all products

            //Arrange
            Assert.AreEqual(80, result.Count);
        }
    }
}
