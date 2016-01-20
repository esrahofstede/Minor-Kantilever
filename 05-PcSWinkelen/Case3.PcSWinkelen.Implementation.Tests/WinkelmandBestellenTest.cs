using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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
    /// <summary>
    /// Test class for testing the WinkelmandBestellen functionality
    /// </summary>
    [TestClass]
    public class WinkelmandBestellenTest
    {
        
        [TestMethod]
        public void FunctionExistsAndCallsCorrectMethod()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            var bestelItemMock = new Mock<IBestelItemWinkelmandItemMapper>();
            bestelItemMock.Setup(mock => mock.MapWinkelmandItemsToBestelItems(It.IsAny<IEnumerable<WinkelmandItem>>()))
                .Returns(DummyData.GetDummyBestelItems);

            var winkelmandItemMapperMock = new Mock<IBestelItemWinkelmandItemMapper>(MockBehavior.Strict);
            winkelmandItemMapperMock.Setup(itemMapper => itemMapper.MapWinkelmandItemsToBestelItems(It.IsAny<IEnumerable<Entities.WinkelmandItem>>())).Returns(DummyData.GetDummyBestelItems);

            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Returns(new List<WinkelmandItem> { DummyData.GetDummyWinkelmandItem });

            var agentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);
            agentMock.Setup(agent => agent.BestellingPlaatsen(It.IsAny<BestellingPcS>())).Returns(true);
            agentMock.Setup(agent => agent.BestellingPlaatsenAsync(It.IsAny<BestellingPcS>())).Returns(Task.FromResult(true));
            var bestellenAgentMock = new Mock<IPcSBestellenAgent>(MockBehavior.Strict);
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);

            dataMapperMock.Setup(dataMapper => dataMapper.FindBySessieID(It.IsAny<string>()))
                .Returns(DummyData.GetDummyWinkelmandItem);
            dataMapperMock.Setup(dataMapper => dataMapper.Delete(It.IsAny<WinkelmandItem>()));
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, catalogusBeheerMock.Object, dtoMapperMock.Object, agentMock.Object, managerMock.Object, bestelItemMock.Object);

            //Act
            var test = handler.WinkelmandBestellen(DummyData.GetDummyWinkelmandBestellenRequestMessage);

            //Assert
            Assert.IsInstanceOfType(test, typeof(WinkelmandBestellenResponseMessage));
            dataMapperMock.Verify(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()), Times.Once());
            agentMock.Verify(agent => agent.BestellingPlaatsenAsync(It.IsAny<BestellingPcS>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void FunctionExistsAndCallsCorrectMethodsWithCorrectData()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            
            var bestelItemMapperMock = new Mock<IBestelItemWinkelmandItemMapper>(MockBehavior.Strict);
            bestelItemMapperMock.Setup(mock => mock.MapWinkelmandItemsToBestelItems(It.IsAny<IEnumerable<WinkelmandItem>>()))
                .Returns(DummyData.GetDummyBestelItems);
            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Returns(new List<WinkelmandItem> { DummyData.GetDummyWinkelmandItem });

            //Agent
            var agentMock = new PcSBestellenAgentMock();
            var managerMock = new Mock<ICatalogusManager>(MockBehavior.Strict);
            var catalogusBeheerMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);


            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, catalogusBeheerMock.Object, null, agentMock, managerMock.Object, bestelItemMapperMock.Object);

            //Act
            var test = handler.WinkelmandBestellen(DummyData.GetDummyWinkelmandBestellenRequestMessage);

            //Assert
            Assert.IsInstanceOfType(test, typeof(WinkelmandBestellenResponseMessage));
            dataMapperMock.Verify(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()), Times.Once());
            Assert.AreEqual(agentMock.Bestelling.Klantgegevens.Naam, DummyData.GetDummyBestellingPcS.Klantgegevens.Naam);
            Assert.AreEqual(agentMock.Bestelling.Klantgegevens.Adresregel1, DummyData.GetDummyBestellingPcS.Klantgegevens.Adresregel1);
            Assert.AreEqual(agentMock.Bestelling.Klantgegevens.Adresregel2, DummyData.GetDummyBestellingPcS.Klantgegevens.Adresregel2);
            Assert.AreEqual(agentMock.Bestelling.Klantgegevens.Postcode, DummyData.GetDummyBestellingPcS.Klantgegevens.Postcode);
            Assert.AreEqual(agentMock.Bestelling.Klantgegevens.Woonplaats, DummyData.GetDummyBestellingPcS.Klantgegevens.Woonplaats);
            Assert.AreEqual(agentMock.Bestelling.ArtikelenPcS.First().Aantal, DummyData.GetDummyBestellingPcS.ArtikelenPcS.First().Aantal);
            Assert.AreEqual(
                agentMock.Bestelling.ArtikelenPcS.First().Product.LeveranciersProductId, 
                DummyData.GetDummyBestellingPcS.ArtikelenPcS.First().Product.LeveranciersProductId);
            Assert.AreEqual(
                agentMock.Bestelling.ArtikelenPcS.First().Product.LeverancierNaam, 
                DummyData.GetDummyBestellingPcS.ArtikelenPcS.First().Product.LeverancierNaam);
            Assert.AreEqual(
                agentMock.Bestelling.ArtikelenPcS.First().Product.Naam, 
                DummyData.GetDummyBestellingPcS.ArtikelenPcS.First().Product.Naam);
           Assert.AreEqual(
                agentMock.Bestelling.ArtikelenPcS.First().Product.Prijs, 
                DummyData.GetDummyBestellingPcS.ArtikelenPcS.First().Product.Prijs);
        }
    }
}
