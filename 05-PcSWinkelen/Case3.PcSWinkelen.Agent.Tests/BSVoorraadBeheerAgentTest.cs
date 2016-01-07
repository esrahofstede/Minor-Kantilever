
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Tests.Mocks;
using Case3.PcSWinkelen.Agent.Exceptions;

namespace Case3.PcSWinkelen.Agent.Tests
{
    [TestClass]
    public class BSVoorraadBeheerAgentTest
    {
        [TestMethod]
        public void VerifyVoorraadIs28ForProduct1()
        {
            //Assert
            VoorraadBeheerMock mock = new VoorraadBeheerMock();
            BSVoorraadBeheerAgent agent = new BSVoorraadBeheerAgent(mock);

            //Act
            int voorraad = agent.GetProductVoorraad(48, "GA1");

            //Arrange
            Assert.AreEqual(28, voorraad);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductVoorraadNotFoundException))]
        public void ProductNotExistsInVoorraadThrowsException()
        {
            //Assert
            BSVoorraadBeheerAgent agent = new BSVoorraadBeheerAgent();

            //Act
            int voorraad = agent.GetProductVoorraad(87695687, "NOTEXISTS");

            //Arrange
            //Expect exception, the product does not exists in BSVoorraadBeheer
        }


        [TestMethod]
        [ExpectedException(typeof(ProductVoorraadNotFoundException))]
        public void GetProductVoorraadWithNullableProductId()
        {
            //Assert
            BSVoorraadBeheerAgent agent = new BSVoorraadBeheerAgent();

            //Act
            int voorraad = agent.GetProductVoorraad(null, "GAZ");

            //Arrange
            //Expect exception, the product with no Id does not exists in BSVoorraadBeheer
        }
    }
}
