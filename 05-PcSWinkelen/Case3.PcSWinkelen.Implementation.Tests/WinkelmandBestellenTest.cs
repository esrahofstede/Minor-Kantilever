using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Test class for testing the WinkelmandBestellen functionality
    /// </summary>
    [TestClass]
    public class WinkelmandBestellenTest
    {

        [TestMethod]
        public void FunctionExistsAndCallsCorrectMethodsWithCorrectData()
        {
            //Arrange
            IWinkelmandDataMapper mapper = new WinkelmandDataMapper();
            var winkelmandItemMapperMock = new Mock<IBestelItemWinkelmandItemMapper>(MockBehavior.Strict);
            winkelmandItemMapperMock.Setup(itemMapper => itemMapper.MapWinkelmandItemsToBestelItems(It.IsAny<IEnumerable<Entities.WinkelmandItem>>())).Returns(DummyData.GetDummyBestelItems);

            var dataMapperMock = new Mock<IWinkelmandDataMapper>(MockBehavior.Strict);
            dataMapperMock.Setup(dataMapper => dataMapper.FindAllBy(It.IsAny<Expression<Func<WinkelmandItem, bool>>>()))
                .Returns(new List<WinkelmandItem> { DummyData.GetDummyWinkelmandItem });
            var agentMock = new PcSBestellenAgentMock();
            var dtoMapperMock = new Mock<IWinkelmandItemDTOMapper>(MockBehavior.Strict);
            dtoMapperMock.Setup(dtopmapper => dtopmapper.MapDTOToEntity(It.IsAny<SchemaNS.WinkelmandItem>())).Returns(DummyData.GetDummyWinkelmandItem);

            IPcSWinkelenService handler = new PcSWinkelenServiceHandler(dataMapperMock.Object, null, dtoMapperMock.Object, agentMock, winkelmandItemMapperMock.Object);

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
