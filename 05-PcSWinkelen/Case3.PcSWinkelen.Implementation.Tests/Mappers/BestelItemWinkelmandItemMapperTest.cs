using System;
using System.Collections.Generic;
using System.Linq;
using Case3.PcSBestellen.SchemaNS;
using Case3.PcSWinkelen.Entities;
using Case3.PcSWinkelen.Implementation.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.PcSWinkelen.Implementation.Tests.Mappers
{
    [TestClass]
    public class BestelItemWinkelmandItemMapperTest
    {
        [TestMethod]
        public void MapBestelItemToWinkelmandItemTest()
        {
            //Arrange
            IBestelItemWinkelmandItemMapper mapper = new BestelItemWinkelmandItemMapper();

            //Act
            var result = mapper.MapBestelItemToWinkelmandItem(DummyData.GetDummyBestelItem);

            //Assert
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.Aantal, result.Aantal);
        }

        [TestMethod]
        public void MapBestelItemToWinkelmandItemCheckNullTest()
        {
            //Arrange
            IBestelItemWinkelmandItemMapper mapper = new BestelItemWinkelmandItemMapper();

            //Act
            var result = mapper.MapBestelItemToWinkelmandItem(null);

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void MapBestelItemsToWinkelmandItemsTest()
        {
            //Arrange
            IBestelItemWinkelmandItemMapper mapper = new BestelItemWinkelmandItemMapper();

            //Act
            var result = mapper.MapBestelItemsToWinkelmandItems(new List<BestelItemPcS> { DummyData.GetDummyBestelItem });

            //Assert
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.Aantal, result.First().Aantal);
        }

        [TestMethod]
        public void MapWinkelmandItemToBestelItemTest()
        {
            //Arrange
            IBestelItemWinkelmandItemMapper mapper = new BestelItemWinkelmandItemMapper();

            //Act
            var result = mapper.MapWinkelmandItemToBestelItem(DummyData.GetDummyWinkelmandItem);

            //Assert
            Assert.AreEqual(DummyData.GetDummyBestelItem.Product.Id, result.Product.Id);
        }

        [TestMethod]
        public void MapWinkelmandItemToBestelItemCheckNullTest()
        {
            //Arrange
            IBestelItemWinkelmandItemMapper mapper = new BestelItemWinkelmandItemMapper();

            //Act
            var result = mapper.MapWinkelmandItemToBestelItem(null);

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void MapWinkelmandItemsToBestelItemsTest()
        {
            //Arrange
            IBestelItemWinkelmandItemMapper mapper = new BestelItemWinkelmandItemMapper();

            //Act
            var result = mapper.MapWinkelmandItemsToBestelItems(new List<WinkelmandItem> {DummyData.GetDummyWinkelmandItem});

            //Assert
            Assert.AreEqual(DummyData.GetDummyBestelItem.Product.Id, result.First().Product.Id);
        }
    }
}
