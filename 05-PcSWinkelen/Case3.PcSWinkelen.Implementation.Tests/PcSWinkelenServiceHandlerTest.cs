using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Case3.PcSWinkelen.MessagesNS;

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

    }
}
