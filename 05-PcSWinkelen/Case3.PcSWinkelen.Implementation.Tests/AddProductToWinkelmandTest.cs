using System;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    [TestClass]
    public class AddProductToWinkelmandTest
    {
        [TestMethod]
        public void FunctionExists()
        {
            //Arrange
            IPcSWinkelenService handler = new PcSWinkelenServiceHandler();

            //Act
            var test = handler.AddProductToWinkelmand(new AddItemToWinkelmandRequestMessage());

            //Assert
            Assert.IsInstanceOfType(test, typeof(AddItemToWinkelmandResponseMessage));
        }

        //Arrange

        //Act

        //Assert
    }
}
