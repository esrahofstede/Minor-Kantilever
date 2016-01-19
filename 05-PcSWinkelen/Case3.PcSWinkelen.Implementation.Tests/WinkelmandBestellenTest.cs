using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Case3.PcSBestellen.SchemaNS;
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
    public class WinkelmandBestellenTest
    {
        
        [TestMethod]
        public void FunctionExistsAndCallsCorrectMethods()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();

            //Datamapper
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Returns(new List<WinkelmandItem> { DummyData.GetDummyWinkelmandItem });

            //Agent
            var agentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.BestellingPlaatsen(It.IsAny<BestellingPcS>()));
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);

            //DTO
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, agentMock.Object, managerMock.Object);

            //Act
            var test = handler.WinkelmandBestellen(DummyData.GetDummyWinkelmandBestellenRequestMessage);

            //Assert
            Assert.IsInstanceOfType(test, typeof(WinkelmandBestellenResponseMessage));
            dataMapperMock.Verify(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()), Times.Once());
            agentMock.Verify(agent => agent.BestellingPlaatsen(It.IsAny<BestellingPcS>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void FunctionExistsAndCallsCorrectMethodsWithCorrectData()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            

            //Datamapper
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Returns(new List<WinkelmandItem> { DummyData.GetDummyWinkelmandItem });

            //Agent
            var agentMock = new PcSBestellenAgentMock();
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);

            //DTO
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);
            //dtoMapperMock.Setup(dtopmapper => dtopmapper.MapEntityToDTO(It.IsAny<WinkelmandItem>())).Returns(DummyData.GetDummyDTOWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, agentMock, managerMock.Object);

            //Act
            var test = handler.WinkelmandBestellen(DummyData.GetDummyWinkelmandBestellenRequestMessage);

            //Assert
            Assert.IsInstanceOfType(test, typeof(WinkelmandBestellenResponseMessage));
            dataMapperMock.Verify(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()), Times.Once());
            Assert.AreEqual(agentMock.Bestelling, DummyData.GetDummyBestellingPcS);

        }
    }
}
