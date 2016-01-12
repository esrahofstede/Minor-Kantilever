using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.Agent.Exceptions;
using Case3.PcSWinkelen.Schema.FoutenNS;
using Case3.PcSWinkelen.SchemaNS;

namespace Case3.PcSWinkelen.Agent.Tests.Managers
{
    [TestClass]
    public class CatalogusManagerTest
    {

        private List<Product> _products = new List<Product>()
        {
            new Product() {
                Id = 1,
                AfbeeldingURL = "9200000015506874.jpg",
                Beschrijving = "Mooie fietsbel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00"),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00"),
                Prijs = 150.00M,
                Naam = "Fietsbel",
                LeverancierNaam = "Gazelle",
                LeveranciersProductId = "G001"
            },
            new Product() {
                Id = 2,
                AfbeeldingURL = "zadels.jpg",
                Beschrijving = "Mooie zadel",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00"),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00"),
                Prijs = 200.00M,
                Naam = "Zadel",
                LeverancierNaam = "Batavus",
                LeveranciersProductId = "B001"
            },
            new Product() {
                Id = 3,
                AfbeeldingURL = "toeter-600x600.jpg",
                Beschrijving = "Mooie Toeter",
                LeverbaarTot = DateTime.Parse("2016-02-10 10:30:00"),
                LeverbaarVanaf = DateTime.Parse("2016-01-06 16:00:00"),
                Prijs = 150.00M,
                Naam = "Toeter",
                LeverancierNaam = "Sparta",
                LeveranciersProductId = "S001"
            },
        };

        [TestMethod]
        public void CreateCatalogusManagerInstance()
        {
            //Arrange
            CatalogusManager catalogusManager = new CatalogusManager();

            //Act
            /*try
            {
                int voorraad = catalogusManager.GetVoorraadWithProductsList();
            }
            catch()


            catalogusManager.GetVoorraadWithProductsList()*/

            //Assert
            Assert.IsNotNull(catalogusManager);
        }

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

        [TestMethod]
        [ExpectedException(typeof(ProductVoorraadNotFoundException))]
        public void CreateCatalogusManagerMockInstanceThrowException()
        {
            //Arrange
            Mock<IBSCatalogusBeheerAgent> catalogusBeheerAgentMock = new Mock<IBSCatalogusBeheerAgent>(MockBehavior.Strict);
            catalogusBeheerAgentMock.Setup(p => p.GetProducts()).Returns(_products);
            catalogusBeheerAgentMock.Setup(p => p.GetProducts(1, 20)).Returns(new List<Product>() { new Product() { Id = 4, LeveranciersProductId = "A001" } });

            Mock<IBSVoorraadBeheerAgent> voorraadBeheerAgentMock = new Mock<IBSVoorraadBeheerAgent>(MockBehavior.Strict);
            voorraadBeheerAgentMock.Setup(p => p.GetProductVoorraad(4, "A001")).Throws(new ProductVoorraadNotFoundException("BSVoorraadBeheer", "Product niet gevonden.", 1, FoutErnst.Waarschuwing));

            CatalogusManager catalogusManager = new CatalogusManager(catalogusBeheerAgentMock.Object, voorraadBeheerAgentMock.Object);

            //Act
            IEnumerable<CatalogusProductItem> newProducts = catalogusManager.GetVoorraadWithProductsList(1, 20);

            //Assert
                //ExpectedException(typeof(ProductVoorraadNotFoundException))
        }

    }
}
