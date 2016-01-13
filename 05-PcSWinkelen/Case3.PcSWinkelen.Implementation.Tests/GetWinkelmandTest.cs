using System;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Entities;
using Case3.PcSWinkelen.Implementation.Mappers;
using Case3.PcSWinkelen.MessagesNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    [TestClass]
    public class GetWinkelmandTest
    {
        [Ignore]
        [TestMethod]
        public void FunctionExists()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            
                //Datamapper
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<WinkelmandItem>()));

                //Agent
            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

                //DTO
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object);

            //Act
            var test = handler.GetWinkelmand(DummyData.GetDummyGetWinkelmandRequestMessage);

            //Assert
            Assert.IsInstanceOfType(test, typeof(GetWinkelmandResponseMessage));
        }
    }
}
