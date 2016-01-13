using System;
using System.Linq.Expressions;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.DAL.Entities;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.MessagesNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    [TestClass]
    public class AddProductToWinkelmandTest
    {
        [TestMethod]
        public void FunctionExists()
        {
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            //Arrange
            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(mapper);

            //Act
            var test = handler.AddProductToWinkelmand(new AddItemToWinkelmandRequestMessage());

            //Assert
            Assert.IsInstanceOfType(test, typeof(AddItemToWinkelmandResponseMessage));
        }

        [TestMethod]
        public void DataMapperIsCalled()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            
            dataMapperMock.Setup(dataMapper => dataMapper.AddWinkelmandItem(It.IsAny<WinkelmandItem>()));
            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(mapper);

            //Act
            handler.AddProductToWinkelmand(new AddItemToWinkelmandRequestMessage());

            //Assert
            //dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<Winkelmand,bool>>>()));
            //dataMapperMock.Verify(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<Winkelmand, bool>>>()), Times.Once());
            dataMapperMock.Verify(dataMapper => dataMapper.AddWinkelmandItem(It.IsAny<WinkelmandItem>()), Times.Once());
        }

        //Arrange

        //Act

        //Assert
    }
}
