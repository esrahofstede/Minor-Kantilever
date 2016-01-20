using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Data.Common;
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

    /// <summary>
    /// Testclass for retrieving the winkelmand
    /// </summary>
    [TestClass]
    public class GetWinkelmandTest
    {
        
        [TestMethod]
        public void FunctionExistsAndCallsCorrectMethods()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            
                //Datamapper
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem,bool>>>()))
                .Returns(new List<WinkelmandItem> {DummyData.GetDummyWinkelmandItem});
            
            //Agent
            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

                //DTO
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapEntityToDTO(It.IsAny<WinkelmandItem>())).Returns(DummyData.GetDummyDTOWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object, bestellenAgentMock.Object ,managerMock.Object, null);

            //Act
            var test = handler.GetWinkelmand(DummyData.GetDummyGetWinkelmandRequestMessage);

            //Assert
            Assert.IsInstanceOfType(test, typeof(GetWinkelmandResponseMessage));
            dataMapperMock.Verify(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()), Times.Once());
            dtoMapperMock.Verify(dtopmapper => dtopmapper.MapEntityToDTO(It.IsAny<WinkelmandItem>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void GetWinkelmandReturnsCorrectData()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);

            //Datamapper
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Returns(new List<WinkelmandItem> { DummyData.GetDummyWinkelmandItem });

            //Agent
            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

            //DTO
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapEntityToDTO(It.IsAny<WinkelmandItem>())).Returns(DummyData.GetDummyDTOWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object, bestellenAgentMock.Object, managerMock.Object, null);

            //Act
            var test = handler.GetWinkelmand(DummyData.GetDummyGetWinkelmandRequestMessage);

            //Assert
            Assert.IsInstanceOfType(test, typeof(GetWinkelmandResponseMessage));
            Assert.AreEqual(DummyData.GetDummyGuid, test.SessieId);
            Assert.AreEqual(DummyData.GetDummyProduct.Id, test.WinkelmandCollection.First().Product.Id);
        }


        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetWinkelmandThrowsCommunicationExc()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);

            //Datamapper
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Throws<NullReferenceException>();

            //Agent
            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Throws<CommunicationException>();
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

            //DTO
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapEntityToDTO(It.IsAny<WinkelmandItem>())).Returns(DummyData.GetDummyDTOWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object, bestellenAgentMock.Object, managerMock.Object, null);

            //Act
            var test = handler.GetWinkelmand(DummyData.GetDummyGetWinkelmandRequestMessage);

            //Assert
            //Expected exception
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetWinkelmandThrowsMappingExc()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();

            //Datamapper
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Returns(new List<WinkelmandItem> { DummyData.GetDummyWinkelmandItem });

            //Agent
            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);

            //DTO
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>()))
                .Throws<NullReferenceException>();
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapEntityToDTO(It.IsAny<WinkelmandItem>()))
                .Throws<NullReferenceException>();

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object, bestellenAgentMock.Object, managerMock.Object, null);

            //Act
            var test = handler.GetWinkelmand(DummyData.GetDummyGetWinkelmandRequestMessage);

            //Assert
            //Expected exception
        }

    }
}
