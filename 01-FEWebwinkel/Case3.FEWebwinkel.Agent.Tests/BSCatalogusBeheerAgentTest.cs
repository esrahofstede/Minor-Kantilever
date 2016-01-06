using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Case3.FEWebwinkel.Schema.Product;
using Case3.FEWebwinkel.Agent.Tests.Mocks;
using System.Linq;

namespace Case3.FEWebwinkel.Agent.Tests
{
    [TestClass]
    public class BSCatalogusBeheerAgentTest
    {
        [TestMethod]
        public void CreateInstance()
        {
            // Arrange

            // Act
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Assert
            Assert.IsNotNull(bSCatalogusBeheerAgent);
        }

        [TestMethod]
        public void FindProductsReturnsList()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            var products = bSCatalogusBeheerAgent.GetProducts();

            // Assert
            Assert.IsInstanceOfType(products, typeof(List<Product>));
        }

        [TestMethod]
        public void FindProductsReturnsListCount3()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            List<Product> products = bSCatalogusBeheerAgent.GetProducts();

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(3, products.Count);
        }

        [TestMethod]
        public void FindProductsIsProduct1ReallyProduct1()
        {
            // Arrange
            BSCatalogusBeheerAgent bSCatalogusBeheerAgent = new BSCatalogusBeheerAgent(new CatalogusBeheerMock());

            // Act
            List<Product> products = bSCatalogusBeheerAgent.GetProducts();
            Product firstProduct = products.First();

            // Assert
            Assert.IsNotNull(firstProduct);
            Assert.AreEqual(1, firstProduct.Id);
            Assert.AreEqual("Fietsbel", firstProduct.Naam);
            Assert.AreEqual("G001", firstProduct.LeveranciersProductId);
            Assert.AreEqual("Gazelle", firstProduct.LeverancierNaam);
        }


        // Arrange

        // Act

        // Assert



    }
}
