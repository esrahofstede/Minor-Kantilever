using System;
using Case3.PcSWinkelen.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    [TestClass]
    public class PcSWinkelenServiceHandlerTest
    {
        [TestMethod]
        public void InstanceTest()
        {
            // Arrange

            // Act
            PcSWinkelenServiceHandler pcsWinkelenServiceHandler = new PcSWinkelenServiceHandler();

            // Assert
            Assert.IsNotNull(pcsWinkelenServiceHandler);
            Assert.IsInstanceOfType(pcsWinkelenServiceHandler, typeof(PcSWinkelenServiceHandler));
        }

        [TestMethod]
        public void GetCatalogusList()
        {
            // Arrange
            PcSWinkelenServiceHandler pcsWinkelenServiceHandler = new PcSWinkelenServiceHandler();

            // Act

            // Assert
            Assert.IsNotNull(pcsWinkelenServiceHandler);
            Assert.IsInstanceOfType(pcsWinkelenServiceHandler, typeof(PcSWinkelenServiceHandler));
        }


        //[TestMethod]
        //public void GetCatalogusListWithItems()
        //{
        //    // Arrange
        //    PcSWinkelenServiceHandler pcsWinkelenServiceHandler = new PcSWinkelenServiceHandler();

        //    // Act
        //    FindCatalogusRequestMessage message = new FindCatalogusRequestMessage
        //    {
        //        Page = 1,
        //        PageSize = 20
        //    };

        //    pcsWinkelenServiceHandler.GetCatalogusItems(message);

        //    // Assert
        //    Assert.IsNotNull(pcsWinkelenServiceHandler);
        //    Assert.IsInstanceOfType(pcsWinkelenServiceHandler, typeof(PcSWinkelenServiceHandler));
        //}



        // Arrange

        // Act

        // Assert

    }
}
