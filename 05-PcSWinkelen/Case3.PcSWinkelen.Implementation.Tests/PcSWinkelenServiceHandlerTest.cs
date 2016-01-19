using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSWinkelen.MessagesNS;
using Moq;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Implementation.Mappers;
using Case3.PcSWinkelen.Agent.Agents;
using System.ServiceModel;
using case3common.v1.faults;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    [TestClass]
    public class PcSWinkelenServiceHandlerTest
    {
   
        [TestMethod]
        public void CreatePcSWinkelenServiceHandlerTest()
        {
            // Arrange

            // Act
            PcSWinkelenServiceHandler pcSWinkelenServiceHandler = new PcSWinkelenServiceHandler();

            // Assert
            Assert.IsNotNull(pcSWinkelenServiceHandler);
            Assert.IsInstanceOfType(pcSWinkelenServiceHandler, typeof(PcSWinkelenServiceHandler));
        }


        [TestMethod]
        public void CheckGetCatalogusItemsReturnsFindCatalogusResponseMessage()
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
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void VerifyCatalogusManagerThrowsFaultExceptionWhenTechnicalExceptionOccurs()
        {
            //Arrange
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            var winkelmandDatamapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);

            managerMock.Setup(p => p.GetVoorraadWithProductsList(1, 10)).Throws(new TechnicalException("Error tijdens het ophalen van producten"));

            PcSWinkelenServiceHandler handler = new PcSWinkelenServiceHandler(winkelmandDatamapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, managerMock.Object);

            //Act
            var result = handler.GetCatalogusItems(new FindCatalogusRequestMessage()
            {
                Page = 1,
                PageSize = 10
            });

            //Assert
            //Expect FaultException<ErrorLijst>
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ErrorLijst>))]
        public void VerifyCatalogusManagerThrowsFaultExceptionWhenExceptionOccurs()
        {
            //Arrange
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            var winkelmandDatamapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);

            managerMock.Setup(p => p.GetVoorraadWithProductsList(1, 10)).Throws(new Exception("Null reference"));

            PcSWinkelenServiceHandler handler = new PcSWinkelenServiceHandler(winkelmandDatamapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, managerMock.Object);

            //Act
            var result = handler.GetCatalogusItems(new FindCatalogusRequestMessage()
            {
                Page = 1,
                PageSize = 10
            });

            //Assert
            //Expect FaultException<ErrorLijst>
        }

        [TestMethod]
        public void VerifyCatalogusManagerAddsExceptionToList()
        {
            //Arrange
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            var winkelmandDatamapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);

            managerMock.Setup(p => p.GetVoorraadWithProductsList(1, 20)).Throws(new TechnicalException("Error tijdens het ophalen van producten"));

            PcSWinkelenServiceHandler handler = new PcSWinkelenServiceHandler(winkelmandDatamapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, managerMock.Object);

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
