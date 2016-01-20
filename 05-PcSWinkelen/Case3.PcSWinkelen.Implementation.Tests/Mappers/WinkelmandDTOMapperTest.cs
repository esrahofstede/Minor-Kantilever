using System;
using Case3.PcSWinkelen.Implementation.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Case3.PcSWinkelen.Implementation.Tests.Mappers
{
    /// <summary>
    /// Testclass for testing the winkelmand to DTO mapper functionality
    /// </summary>
    [TestClass]
    public class WinkelmandDTOMapperTest
    {
        [TestMethod]
        public void DTOToEntityTest()
        {
            //Arrange
            IWinkelmandItemDTOMapper mapper = new WinkelmandItemDTOMapper();

            //Act
            var result = mapper.MapDTOToEntity(DummyData.GetDummyDTOWinkelmandItem);

            //Assert
            Assert.AreNotEqual(DummyData.GetDummyDTOWinkelmandItem.Product.Id, result.ID);
            Assert.AreEqual(DummyData.GetDummyDTOWinkelmandItem.Aantal, result.Aantal);
            Assert.AreEqual(DummyData.GetDummyDTOWinkelmandItem.Product.LeverancierNaam, result.LeverancierNaam);
            Assert.AreEqual(DummyData.GetDummyDTOWinkelmandItem.Product.LeveranciersProductId, result.LeveranciersProductId);
            Assert.AreEqual(DummyData.GetDummyDTOWinkelmandItem.Product.Naam, result.Naam);
            Assert.AreEqual(DummyData.GetDummyDTOWinkelmandItem.Product.Prijs, result.Prijs);
            Assert.AreEqual(DummyData.GetDummyDTOWinkelmandItem.SessieId, result.SessieID);
            Assert.AreEqual(DummyData.GetDummyDTOWinkelmandItem.Product.Id, result.ProductID);
        }

        [TestMethod]
        public void DTOToEntityCheckNullTest()
        {
            //Arrange
            IWinkelmandItemDTOMapper mapper = new WinkelmandItemDTOMapper();

            //Act
            var result = mapper.MapDTOToEntity(null);

            //Assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void EntityToDTOTest()
        {
            //Arrange
            IWinkelmandItemDTOMapper mapper = new WinkelmandItemDTOMapper();

            //Act
            var result = mapper.MapEntityToDTO(DummyData.GetDummyWinkelmandItem);

            //Assert
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.ProductID, result.Product.Id);
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.Aantal, result.Aantal);
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.LeverancierNaam, result.Product.LeverancierNaam);
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.LeveranciersProductId, result.Product.LeveranciersProductId);
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.Naam, result.Product.Naam);
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.Prijs, result.Product.Prijs);
            Assert.AreEqual(DummyData.GetDummyWinkelmandItem.SessieID, result.SessieId);
        }

        [TestMethod]
        public void EntityToDTOCheckNullTest()
        {
            //Arrange
            IWinkelmandItemDTOMapper mapper = new WinkelmandItemDTOMapper();

            //Act
            var result = mapper.MapEntityToDTO(null);

            //Assert
            Assert.AreEqual(null, result);
        }
    }
}
