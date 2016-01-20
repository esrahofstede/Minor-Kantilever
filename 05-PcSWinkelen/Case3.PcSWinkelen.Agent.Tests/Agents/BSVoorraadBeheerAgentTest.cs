using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Tests.Mocks;
using Case3.PcSWinkelen.Schema.FoutenNS;
using Case3.PcSWinkelen.Agent.Exceptions;

namespace Case3.PcSWinkelen.Agent.Tests.Agents
{
    /// <summary>
    /// Test class which tests the functionality of the BSVoorraadBeheerAgent class
    /// </summary>
    [TestClass]
    public class BSVoorraadBeheerAgentTest
    {
        /// <summary>
        /// Checks Voorraad for a specific product
        /// </summary>
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

        /// <summary>
        /// Test which must throw an exception, the exception must be the right one. This test is dependent.
        /// </summary>
        [TestMethod]
        public void Acceptation_ProductNotExistsInVoorraadThrowsExceptionAndCheckExceptionDetails()
        {
            //Assert
            BSVoorraadBeheerAgent agent = new BSVoorraadBeheerAgent();

            //Act
            try
            {
                int voorraad = agent.GetProductVoorraad(87695687, "NOTEXISTS");
            }
            catch (ProductVoorraadNotFoundException exception)
            {
                //Arrange
                Assert.AreEqual("Product niet gevonden.", exception.Message);
                Assert.AreEqual(1, exception.Number);
                Assert.AreEqual(FoutErnst.Waarschuwing, exception.Serverity);
                Assert.AreEqual("BSVoorraadBeheer", exception.Source);
            }
        }

        /// <summary>
        /// Test which must throw an exception because productId is null. This test is dependent.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ProductVoorraadNotFoundException))]
        public void Acceptation_GetProductVoorraadWithNullableProductId()
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
