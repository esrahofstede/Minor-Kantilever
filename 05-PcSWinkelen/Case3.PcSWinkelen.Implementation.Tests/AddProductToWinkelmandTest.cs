using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Implementation.Mappers;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.SchemaNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntitiesNS = Case3.PcSWinkelen.Entities;
using Moq;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    [TestClass]
    public class AddProductToWinkelmandTest
    {
        [TestMethod]
        public void FunctionExists()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()));

            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object);

            //Act
            var test = handler.AddProductToWinkelmand(DummyData.GetDummyAddItemToWinkelmandRequestMessage);

            //Assert`
            Assert.IsInstanceOfType(test, typeof(AddItemToWinkelmandResponseMessage));
        }

        [TestMethod]
        public void DataMapperIsCalled()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()));

            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object);

            //Act
            var test = handler.AddProductToWinkelmand(DummyData.GetDummyAddItemToWinkelmandRequestMessage);

            //Assert
            dataMapperMock.Verify(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()), Times.Once());
        }

        [TestMethod]
        public void DataMapperGetsCorrectProductId()
        {
            //Arrange
            WinkelMandDataMapperMock mapper = new WinkelMandDataMapperMock();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()));

            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(mapper, agentMock.Object, dtoMapperMock.Object);
            AddItemToWinkelmandRequestMessage req = DummyData.GetDummyAddItemToWinkelmandRequestMessage;


            //Act
            var test = handler.AddProductToWinkelmand(DummyData.GetDummyAddItemToWinkelmandRequestMessage);

            //Assert
            Assert.AreEqual(mapper.Item.ProductID, DummyData.GetDummyWinkelmandItemRef.ProductId);
            Assert.AreEqual(mapper.Item.SessieID, DummyData.GetDummyWinkelmandItemRef.SessieId);
        }

        [TestMethod]
        public void DataMapperGetsCorrectProduct()
        {
            //Arrange
            WinkelMandDataMapperMock mapper = new WinkelMandDataMapperMock();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()));

            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(mapper, agentMock.Object, dtoMapperMock.Object);
            AddItemToWinkelmandRequestMessage req = DummyData.GetDummyAddItemToWinkelmandRequestMessage;

            //Act
            var test = handler.AddProductToWinkelmand(DummyData.GetDummyAddItemToWinkelmandRequestMessage);

            //Assert
            Assert.AreEqual(mapper.Item.ProductID, DummyData.GetDummyWinkelmandItemRef.ProductId);
            Assert.AreEqual(mapper.Item.SessieID, DummyData.GetDummyWinkelmandItemRef.SessieId);
            Assert.AreEqual(mapper.Item.LeverancierNaam, DummyData.GetDummyProduct.LeverancierNaam);
            Assert.AreEqual(mapper.Item.LeveranciersProductId, DummyData.GetDummyProduct.LeveranciersProductId);
            Assert.AreEqual(mapper.Item.Prijs, DummyData.GetDummyProduct.Prijs);
        }

        [TestMethod]
        public void AgentIsCalled()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()));

            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object);

            //Act
            var test = handler.AddProductToWinkelmand(DummyData.GetDummyAddItemToWinkelmandRequestMessage);

            //Assert
            agentMock.Verify(agent => agent.GetProductById(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        public void AgentReturnsCorrectProduct()
        {
            //Arrange
            var mapper = new WinkelMandDataMapperMock();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()));

            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(mapper, agentMock.Object, dtoMapperMock.Object);

            //Act
            var test = handler.AddProductToWinkelmand(DummyData.GetDummyAddItemToWinkelmandRequestMessage);

            //Assert
            Assert.AreEqual(mapper.Item.ProductID, DummyData.GetDummyWinkelmandItemRef.ProductId);
            Assert.AreEqual(mapper.Item.SessieID, DummyData.GetDummyWinkelmandItemRef.SessieId);
            Assert.AreEqual(mapper.Item.LeverancierNaam, DummyData.GetDummyProduct.LeverancierNaam);
            Assert.AreEqual(mapper.Item.LeveranciersProductId, DummyData.GetDummyProduct.LeveranciersProductId);
            Assert.AreEqual(mapper.Item.Prijs, DummyData.GetDummyProduct.Prijs);
        }

        [TestMethod]
        public void DTOMapperIsCalled()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            WinkelmandItem item = new WinkelmandItem();
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.Insert(It.IsAny<EntitiesNS.WinkelmandItem>()));

            var agentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.GetProductById(It.IsAny<int>())).Returns(DummyData.GetDummyProduct);

            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, agentMock.Object, dtoMapperMock.Object);

            //Act
            var test = handler.AddProductToWinkelmand(DummyData.GetDummyAddItemToWinkelmandRequestMessage);

            //Assert
            dtoMapperMock.Verify(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>()), Times.Once());
        }


        //Arrange

        //Act
        //dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<Winkelmand,bool>>>()));
        //dataMapperMock.Verify(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<Winkelmand, bool>>>()), Times.Once());
        //Assert
    }
}
