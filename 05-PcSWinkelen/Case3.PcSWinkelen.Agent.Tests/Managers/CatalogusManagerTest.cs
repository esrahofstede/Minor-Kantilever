using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

using System.Linq;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.SchemaNS;
using Case3.PcSWinkelen.Agent.Exceptions;
using Case3.PcSWinkelen.Schema.FoutenNS;
using System.Globalization;

namespace Case3.PcSWinkelen.Agent.Tests.Managers
{
    /// <summary>
    /// Class which tests the functionalities of the CatalogusManager class
    /// </summary>
    [TestClass]
    public class CatalogusManagerTest
    {

        private List<Product> _products = new List<Product>()
        {
            new Product() {
                Id = 1,
                AfbeeldingURL = "9200000015506874.jpg",
                Beschrijving = "Mooie fietsbel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                Prijs = 150.00M,
                Naam = "Fietsbel",
                LeverancierNaam = "Gazelle",
                LeveranciersProductId = "G001"
            },
            new Product() {
                Id = 2,
                AfbeeldingURL = "zadels.jpg",
                Beschrijving = "Mooie zadel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                Prijs = 200.00M,
                Naam = "Zadel",
                LeverancierNaam = "Batavus",
                LeveranciersProductId = "B001"
            },
            new Product() {
                Id = 3,
                AfbeeldingURL = "toeter-600x600.jpg",
                Beschrijving = "Mooie Toeter",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00", CultureInfo.InvariantCulture),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00", CultureInfo.InvariantCulture),
                Prijs = 150.00M,
                Naam = "Toeter",
                LeverancierNaam = "Sparta",
                LeveranciersProductId = "S001"
            },
        };


        [TestMethod]
        public void CreateCatalogusManagerMockInstance()
        {
            //Arrange
            Mock<IBSCatalogusBeheerAgent> catalogusBeheerAgentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
       
            catalogusBeheerAgentMock.Setup(p => p.GetProducts()).Returns(_products);
            catalogusBeheerAgentMock.Setup(p => p.GetProducts(1, 20)).Returns(_products);

            Mock<IBSVoorraadBeheerAgent> voorraadBeheerAgentMock = new Mock<IBSVoorraadBeheerAgent>(MockBehavior.Strict);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(1, "G001")).Returns(1);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(2, "B001")).Returns(2);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(3, "S001")).Returns(3);

            CatalogusManager catalogusManager = new CatalogusManager(catalogusBeheerAgentMock.Object, voorraadBeheerAgentMock.Object);

            //Act
            IEnumerable<CatalogusProductItem> newProducts = catalogusManager.GetVoorraadWithProductsList(1, 20);


            //Assert
            Assert.IsNotNull(catalogusManager);
            Assert.IsInstanceOfType(newProducts, typeof(IEnumerable<CatalogusProductItem>));
        }

        /// <summary>
        /// This method checks if the catalogusmanager doesn't add a product to the list if it is leverbaar. Even though there is no voorraad.
        /// </summary>
        [TestMethod]
        public void VerifyProductVoorraadIs0WhenVoorraadNotFoundButIsLeverbaarTot2050()
        {
            //Arrange
            Mock<IBSCatalogusBeheerAgent> catalogusBeheerAgentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            catalogusBeheerAgentMock.Setup(p => p.GetProducts(1, 20)).Returns(new List<Product>() { new Product() { Id = 4, LeveranciersProductId = "A001", LeverbaarTot = new DateTime(2050,5,5) } });

            Mock<IBSVoorraadBeheerAgent> voorraadBeheerAgentMock = new Mock<IBSVoorraadBeheerAgent>(MockBehavior.Strict);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(4, "A001")).Throws(new ProductVoorraadNotFoundException("BSVoorraadBeheer", "Product niet gevonden.", 1, FoutErnst.Waarschuwing));

            CatalogusManager catalogusManager = new CatalogusManager(catalogusBeheerAgentMock.Object, voorraadBeheerAgentMock.Object);

            //Act
            IEnumerable<CatalogusProductItem> newProducts = catalogusManager.GetVoorraadWithProductsList(1, 20);

            //Assert
            Assert.AreEqual(0, newProducts.First().Voorraad);
        }

        /// <summary>
        /// This method checks if the catalogusmanager doesn't add a product to the list if it is not leverbaar anymore.
        /// </summary>
        [TestMethod]
        public void VerifyProductListIs0WhenVoorraadNotFoundWhenNotLeverbaar()
        {
            //Arrange
            Mock<IBSCatalogusBeheerAgent> catalogusBeheerAgentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            catalogusBeheerAgentMock.Setup(p => p.GetProducts(1, 20)).Returns(new List<Product>() { new Product() { Id = 4, LeveranciersProductId = "A001", LeverbaarTot = new DateTime(1900, 5, 5) } });

            Mock<IBSVoorraadBeheerAgent> voorraadBeheerAgentMock = new Mock<IBSVoorraadBeheerAgent>(MockBehavior.Strict);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(4, "A001")).Throws(new ProductVoorraadNotFoundException("BSVoorraadBeheer", "Product niet gevonden.", 1, FoutErnst.Waarschuwing));

            CatalogusManager catalogusManager = new CatalogusManager(catalogusBeheerAgentMock.Object, voorraadBeheerAgentMock.Object);

            //Act
            IEnumerable<CatalogusProductItem> newProducts = catalogusManager.GetVoorraadWithProductsList(1, 20);

            //Assert
            Assert.AreEqual(0, newProducts.Count());
        }

        [TestMethod]
        public void CheckReturnWithEmptyListAsInput()
        {
            //Arrange
            Mock<IBSCatalogusBeheerAgent> catalogusBeheerAgentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            catalogusBeheerAgentMock.Setup(p => p.GetProducts()).Returns(new List<Product>());
            catalogusBeheerAgentMock.Setup(p => p.GetProducts(1, 20)).Returns(new List<Product>());

            Mock<IBSVoorraadBeheerAgent> voorraadBeheerAgentMock = new Mock<IBSVoorraadBeheerAgent>(MockBehavior.Strict);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(1, "G001")).Returns(1);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(2, "B001")).Returns(2);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(3, "S001")).Returns(3);

            CatalogusManager catalogusManager = new CatalogusManager(catalogusBeheerAgentMock.Object, voorraadBeheerAgentMock.Object);

            //Act
            IEnumerable<CatalogusProductItem> newProducts = catalogusManager.GetVoorraadWithProductsList(1, 20);

            //Assert
            Assert.IsNotNull(catalogusManager);
            Assert.IsInstanceOfType(newProducts, typeof(IEnumerable<CatalogusProductItem>));
            Assert.AreEqual(0, newProducts.Count());

        }
    }
}
