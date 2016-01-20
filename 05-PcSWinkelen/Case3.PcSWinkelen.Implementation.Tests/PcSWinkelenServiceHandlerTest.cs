using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSWinkelen.MessagesNS;
using Moq;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Implementation.Mappers;
using Case3.PcSWinkelen.Agent.Agents;
using System.ServiceModel;
using Case3.Common.Faults;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    /// <summary>
    /// Test class for testing the PcSWinkelenServiceHandler class
    /// </summary>
    [TestClass]
    public class PcSWinkelenServiceHandlerTest
    {
        /// <summary>
        /// This method tests the constructor of PcsWinkelenServiceHandler. This test is dependent.
        /// </summary>
        [TestMethod]
        public void Integration_CreatePcSWinkelenServiceHandler()
        {
            // Arrange

            // Act
            PcSWinkelenServiceHandler pcSWinkelenServiceHandler = new PcSWinkelenServiceHandler();

            // Assert
            Assert.IsNotNull(pcSWinkelenServiceHandler);
            Assert.IsInstanceOfType(pcSWinkelenServiceHandler, typeof(PcSWinkelenServiceHandler));
        }

        /// <summary>
        /// This method tests if GetCatalogusItems returns FindCatalogusResponseMessage with 2 products.
        /// </summary>
        [TestMethod]
        public void Integration_CheckGetCatalogusItemsReturnsFindCatalogusResponseMessage()
        {
            // Arrange
            PcSWinkelenServiceHandler pcSWinkelenServiceHandler = new PcSWinkelenServiceHandler();

            // Act
            FindCatalogusRequestMessage findCatalogusRequestMessage = new FindCatalogusRequestMessage()
            {
                Page = 1,
                PageSize = 2
            };
            FindCatalogusResponseMessage findCatalogusResponseMessage = pcSWinkelenServiceHandler.GetCatalogusItems(findCatalogusRequestMessage);

            // Assert
            Assert.IsNotNull(findCatalogusResponseMessage);
            Assert.IsInstanceOfType(findCatalogusResponseMessage, typeof(FindCatalogusResponseMessage));
            Assert.AreEqual(2, findCatalogusResponseMessage.Products.Count);
        }

        /// <summary>
        /// This methods tests if the catalogusmanager throws a fault exception when a TechnicalException occurs.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void VerifyCatalogusManagerThrowsFaultExceptionWhenTechnicalExceptionOccurs()
        {
            //Arrange
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            var winkelmandDatamapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);

            managerMock.Setup(p => p.GetVoorraadWithProductsList(1, 10)).Throws(new TechnicalException("Error tijdens het ophalen van producten"));

            PcSWinkelenServiceHandler handler = new PcSWinkelenServiceHandler(winkelmandDatamapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object,bestellenAgentMock.Object, managerMock.Object, null);

            //Act
            var result = handler.GetCatalogusItems(new FindCatalogusRequestMessage()
            {
                Page = 1,
                PageSize = 10
            });

            //Assert
            //Expect FaultException<ErrorLijst>
        }

        /// <summary>
        /// This methods tests if the catalogusmanager throws a fault exception when a Exception occurs.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void VerifyCatalogusManagerThrowsFaultExceptionWhenExceptionOccurs()
        {
            //Arrange
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            var winkelmandDatamapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

            managerMock.Setup(p => p.GetVoorraadWithProductsList(1, 10)).Throws(new Exception("Null reference"));

            PcSWinkelenServiceHandler handler = new PcSWinkelenServiceHandler(winkelmandDatamapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, bestellenAgentMock.Object, managerMock.Object, null);

            //Act
            var result = handler.GetCatalogusItems(new FindCatalogusRequestMessage()
            {
                Page = 1,
                PageSize = 10
            });

            //Assert
            //Expect FaultException<ErrorLijst>
        }

        /// <summary>
        /// This method tests if the PcsWinkelenServiceHandler returns a list with exceptions when an exception occurs.
        /// </summary>
        [TestMethod]
        public void VerifyCatalogusManagerAddsExceptionToList()
        {
            //Arrange
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            var winkelmandDatamapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

            managerMock.Setup(p => p.GetVoorraadWithProductsList(1, 20)).Throws(new TechnicalException("Error tijdens het ophalen van producten"));

            PcSWinkelenServiceHandler handler = new PcSWinkelenServiceHandler(winkelmandDatamapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, bestellenAgentMock.Object, managerMock.Object, null);

            try
            {
                //Act
                var result = handler.GetCatalogusItems(new FindCatalogusRequestMessage()
                {
                    Page = 1,
                    PageSize = 20
                });
            }
            catch (FaultException<ErrorLijst> ex)
            {
                //Assert
                Assert.AreEqual(1, ex.Detail.Count);
            }
        }
    }
}
